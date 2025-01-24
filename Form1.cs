using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NN_ModLoaderGUI
{
    public partial class MainForm : Form
    {
        private string paksFolder; // Path to the Paks folder

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            LoadMods();
        }

        // Load Paks folder path from settings file
        private void LoadSettings()
        {
            if (File.Exists("pakFolderSetting.txt"))
            {
                paksFolder = File.ReadAllText("pakFolderSetting.txt").Trim();
                if (Directory.Exists(paksFolder))
                {
                    pakFolderTextBox.Text = paksFolder;
                    statusLabel.Text = "Paks folder loaded.";
                }
                else
                {
                    statusLabel.Text = "Saved Paks folder path does not exist.";
                }
            }
            else
            {
                statusLabel.Text = "No saved Paks folder path found.";
            }
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            string pakFolderPath = pakFolderTextBox.Text.Trim();

            if (string.IsNullOrEmpty(pakFolderPath) || !Directory.Exists(pakFolderPath))
            {
                statusLabel.Text = "Invalid Paks folder path.";
                return;
            }

            try
            {
                File.WriteAllText("pakFolderSetting.txt", pakFolderPath);
                paksFolder = pakFolderPath;
                statusLabel.Text = "Paks folder path saved successfully!";
                LoadMods();
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Error saving Paks folder path: {ex.Message}";
            }
        }

        private void uploadModButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(paksFolder) || !Directory.Exists(paksFolder))
            {
                statusLabel.Text = "Paks folder is not set or does not exist.";
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "ZIP Files|*.zip";
                openFileDialog.Title = "Select a Mod ZIP File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string zipFilePath = openFileDialog.FileName;

                    try
                    {
                        ZipFile.ExtractToDirectory(zipFilePath, paksFolder);
                        statusLabel.Text = $"Mod uploaded and extracted from {Path.GetFileName(zipFilePath)}";
                        LoadMods();
                    }
                    catch (Exception ex)
                    {
                        statusLabel.Text = $"Error extracting mod: {ex.Message}";
                    }
                }
            }
        }

        private void enableModButton_Click(object sender, EventArgs e)
        {
            if (modsListBox.SelectedIndex == -1)
            {
                statusLabel.Text = "Please select a mod to enable or disable.";
                return;
            }

            string selectedMod = modsListBox.SelectedItem.ToString();
            bool isDisabled = selectedMod.EndsWith("[DISABLED]");
            string modFileName = isDisabled ? selectedMod.Replace(" [DISABLED]", "") : selectedMod;

            string sourceFolder = isDisabled ? Path.Combine(paksFolder, "Disabled_mods") : paksFolder;
            string destinationFolder = isDisabled ? paksFolder : Path.Combine(paksFolder, "Disabled_mods");

            try
            {
                // If the mod is disabled, it will have the ".pak.d" extension in the Disabled_mods folder
                string modPath = isDisabled ? Path.Combine(sourceFolder, modFileName + ".d") : Path.Combine(sourceFolder, modFileName);
                string modTargetPath = isDisabled ? Path.Combine(destinationFolder, modFileName) : Path.Combine(destinationFolder, modFileName + ".d");

                // Check if the mod file exists in the source folder
                if (!File.Exists(modPath))
                {
                    statusLabel.Text = $"Mod file not found: {modPath}";
                    return;
                }

                // Create the destination folder if it doesn't exist
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                // Move the mod file
                File.Move(modPath, modTargetPath);

                // Handle associated files if mod info exists
                string modInfoPath = Path.Combine(sourceFolder, Path.GetFileNameWithoutExtension(modFileName) + "-info.json");
                if (File.Exists(modInfoPath))
                {
                    string targetModInfoPath = Path.Combine(destinationFolder, Path.GetFileNameWithoutExtension(modFileName) + "-info.json");
                    File.Move(modInfoPath, targetModInfoPath);

                    string jsonContent = File.ReadAllText(targetModInfoPath);
                    ModInfo modInfo = JsonConvert.DeserializeObject<ModInfo>(jsonContent);

                    if (modInfo?.AssociatedFiles != null)
                    {
                        foreach (var associatedFile in modInfo.AssociatedFiles)
                        {
                            string associatedFilePath = Path.Combine(sourceFolder, associatedFile);
                            string disabledFilePath = Path.Combine(destinationFolder, associatedFile);

                            if (File.Exists(associatedFilePath))
                            {
                                // Append .pak.d when moving associated files to "Disabled_mods"
                                string disabledFileWithD = isDisabled ? disabledFilePath : disabledFilePath + ".d";
                                if (!isDisabled && disabledFileWithD.EndsWith(".d"))
                                {
                                    disabledFileWithD = disabledFileWithD.Substring(0, disabledFileWithD.Length - 7); // Remove ".pak.d" when enabling
                                }
                                File.Move(associatedFilePath, disabledFileWithD);
                            }
                        }
                    }
                }

                // Remove the selected mod from the list and reload
                modsListBox.Items.Remove(selectedMod);
                LoadMods();

                statusLabel.Text = $"{(isDisabled ? "Enabled" : "Disabled")} mod: {modFileName}";
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Error toggling mod: {ex.Message}";
            }
        }

        private void LoadMods()
        {
            // Clear the existing items in the list box
            modsListBox.Items.Clear();

            // Load enabled mods from the paks folder
            string[] modFiles = Directory.GetFiles(paksFolder, "*.pak", SearchOption.TopDirectoryOnly);
            foreach (string modFile in modFiles)
            {
                string modFileName = Path.GetFileName(modFile);
                // Check if the mod is already disabled by checking if it has the .pak.d extension
                if (File.Exists(Path.Combine(paksFolder, modFileName + ".d")))
                {
                    modsListBox.Items.Add(modFileName + " [DISABLED]");
                }
                else
                {
                    modsListBox.Items.Add(modFileName);
                }
            }

            // Load disabled mods from the Disabled_mods folder
            string disabledModsFolder = Path.Combine(paksFolder, "Disabled_mods");
            if (Directory.Exists(disabledModsFolder))
            {
                string[] disabledModFiles = Directory.GetFiles(disabledModsFolder, "*.d", SearchOption.TopDirectoryOnly);
                foreach (string disabledModFile in disabledModFiles)
                {
                    string disabledModFileName = Path.GetFileName(disabledModFile);
                    modsListBox.Items.Add(disabledModFileName.Replace(".d", "") + " [DISABLED]");
                }
            }
        }

        public class ModInfo
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Version { get; set; }
            public List<string> AssociatedFiles { get; set; }
        }
    }
}
