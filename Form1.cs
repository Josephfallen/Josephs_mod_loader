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
            if (modsListView.SelectedItems.Count == 0)
            {
                statusLabel.Text = "Please select a mod to enable or disable.";
                return;
            }

            string selectedMod = modsListView.SelectedItems[0].Text;
            bool isDisabled = selectedMod.EndsWith("[DISABLED]");
            string modFileName = isDisabled ? selectedMod.Replace(" [DISABLED]", "") : selectedMod;

            string sourceFolder = isDisabled ? Path.Combine(paksFolder, "Disabled_mods") : paksFolder;
            string destinationFolder = isDisabled ? paksFolder : Path.Combine(paksFolder, "Disabled_mods");

            try
            {
                string modPath = isDisabled
                    ? Path.Combine(sourceFolder, modFileName + ".d")
                    : Path.Combine(sourceFolder, modFileName);
                string modTargetPath = isDisabled
                    ? Path.Combine(destinationFolder, modFileName)
                    : Path.Combine(destinationFolder, modFileName + ".d");

                if (!File.Exists(modPath))
                {
                    statusLabel.Text = $"Mod file not found: {modPath}";
                    return;
                }

                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                File.Move(modPath, modTargetPath);

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
                                string disabledFileWithD = isDisabled ? disabledFilePath : disabledFilePath + ".d";
                                if (!isDisabled && disabledFileWithD.EndsWith(".d"))
                                {
                                    disabledFileWithD = disabledFileWithD.Substring(0, disabledFileWithD.Length - 2);
                                }
                                File.Move(associatedFilePath, disabledFileWithD);
                            }
                        }
                    }
                }

                modsListView.Items.Remove(modsListView.SelectedItems[0]);
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
            modsListView.Items.Clear();

            string[] modFiles = Directory.GetFiles(paksFolder, "*.pak", SearchOption.TopDirectoryOnly);
            foreach (string modFile in modFiles)
            {
                string modFileName = Path.GetFileName(modFile);
                string modInfoPath = Path.Combine(paksFolder, Path.GetFileNameWithoutExtension(modFileName) + "-info.json");

                if (File.Exists(Path.Combine(paksFolder, modFileName + ".d")))
                {
                    modsListView.Items.Add(new ListViewItem(modFileName + " [DISABLED]"));
                }
                else
                {
                    modsListView.Items.Add(new ListViewItem(modFileName));
                }

                if (File.Exists(modInfoPath))
                {
                    string jsonContent = File.ReadAllText(modInfoPath);
                    ModInfo modInfo = JsonConvert.DeserializeObject<ModInfo>(jsonContent);

                    if (modInfo != null)
                    {
                        // Display mod info in UI
                        descriptionLabel.Text = $"Description: {modInfo.Description}";
                        versionLabel.Text = $"Version: {modInfo.Version}";
                    }
                }
            }

            string disabledModsFolder = Path.Combine(paksFolder, "Disabled_mods");
            if (Directory.Exists(disabledModsFolder))
            {
                string[] disabledModFiles = Directory.GetFiles(disabledModsFolder, "*.d", SearchOption.TopDirectoryOnly);
                foreach (string disabledModFile in disabledModFiles)
                {
                    string disabledModFileName = Path.GetFileName(disabledModFile);
                    string modInfoPath = Path.Combine(disabledModsFolder, Path.GetFileNameWithoutExtension(disabledModFileName.Replace(".d", "")) + "-info.json");

                    modsListView.Items.Add(new ListViewItem(disabledModFileName.Replace(".d", "") + " [DISABLED]"));

                    if (File.Exists(modInfoPath))
                    {
                        string jsonContent = File.ReadAllText(modInfoPath);
                        ModInfo modInfo = JsonConvert.DeserializeObject<ModInfo>(jsonContent);

                        if (modInfo != null)
                        {
                            // Display mod info in UI
                            descriptionLabel.Text = $"Description: {modInfo.Description}";
                            versionLabel.Text = $"Version: {modInfo.Version}";
                        }
                    }
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
