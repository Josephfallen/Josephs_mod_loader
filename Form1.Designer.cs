namespace NN_ModLoaderGUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage modsTabPage;
        private System.Windows.Forms.TabPage settingsTabPage;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ListBox modsListBox;
        private System.Windows.Forms.Button enableModButton;
        private System.Windows.Forms.Button uploadModButton;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.TextBox pakFolderTextBox;
        private System.Windows.Forms.Label pakFolderLabel;

        // Dispose method (no changes here)
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            modsTabPage = new TabPage();
            statusLabel = new Label();
            modsListBox = new ListBox();
            enableModButton = new Button();
            uploadModButton = new Button();
            settingsTabPage = new TabPage();
            pakFolderTextBox = new TextBox();
            saveSettingsButton = new Button();
            pakFolderLabel = new Label();
            tabControl.SuspendLayout();
            modsTabPage.SuspendLayout();
            settingsTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(modsTabPage);
            tabControl.Controls.Add(settingsTabPage);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1124, 537);
            tabControl.TabIndex = 0;
            // 
            // modsTabPage
            // 
            modsTabPage.Controls.Add(statusLabel);
            modsTabPage.Controls.Add(modsListBox);
            modsTabPage.Controls.Add(enableModButton);
            modsTabPage.Controls.Add(uploadModButton);
            modsTabPage.Location = new Point(4, 24);
            modsTabPage.Name = "modsTabPage";
            modsTabPage.Padding = new Padding(3);
            modsTabPage.Size = new Size(1116, 509);
            modsTabPage.TabIndex = 0;
            modsTabPage.Text = "Mods";
            modsTabPage.UseVisualStyleBackColor = true;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(9, 43);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(39, 15);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "Status";
            // 
            // modsListBox
            // 
            modsListBox.FormattingEnabled = true;
            modsListBox.ItemHeight = 15;
            modsListBox.Location = new Point(6, 66);
            modsListBox.Name = "modsListBox";
            modsListBox.Size = new Size(240, 124);
            modsListBox.TabIndex = 3;
            // 
            // enableModButton
            // 
            enableModButton.Location = new Point(6, 206);
            enableModButton.Name = "enableModButton";
            enableModButton.Size = new Size(75, 23);
            enableModButton.TabIndex = 4;
            enableModButton.Text = "Enable Mod";
            enableModButton.UseVisualStyleBackColor = true;
            enableModButton.Click += enableModButton_Click;
            // 
            // uploadModButton
            // 
            uploadModButton.Location = new Point(171, 206);
            uploadModButton.Name = "uploadModButton";
            uploadModButton.Size = new Size(75, 23);
            uploadModButton.TabIndex = 5;
            uploadModButton.Text = "Upload Mod";
            uploadModButton.UseVisualStyleBackColor = true;
            uploadModButton.Click += uploadModButton_Click;
            // 
            // settingsTabPage
            // 
            settingsTabPage.Controls.Add(pakFolderTextBox);
            settingsTabPage.Controls.Add(saveSettingsButton);
            settingsTabPage.Controls.Add(pakFolderLabel);
            settingsTabPage.Location = new Point(4, 24);
            settingsTabPage.Name = "settingsTabPage";
            settingsTabPage.Padding = new Padding(3);
            settingsTabPage.Size = new Size(752, 509);
            settingsTabPage.TabIndex = 1;
            settingsTabPage.Text = "Settings";
            settingsTabPage.UseVisualStyleBackColor = true;
            // 
            // pakFolderTextBox
            // 
            pakFolderTextBox.Location = new Point(6, 22);
            pakFolderTextBox.Name = "pakFolderTextBox";
            pakFolderTextBox.Size = new Size(659, 23);
            pakFolderTextBox.TabIndex = 1;
            // 
            // saveSettingsButton
            // 
            saveSettingsButton.Location = new Point(6, 48);
            saveSettingsButton.Name = "saveSettingsButton";
            saveSettingsButton.Size = new Size(75, 23);
            saveSettingsButton.TabIndex = 2;
            saveSettingsButton.Text = "Save";
            saveSettingsButton.UseVisualStyleBackColor = true;
            saveSettingsButton.Click += saveSettingsButton_Click;
            // 
            // pakFolderLabel
            // 
            pakFolderLabel.AutoSize = true;
            pakFolderLabel.Location = new Point(9, 9);
            pakFolderLabel.Name = "pakFolderLabel";
            pakFolderLabel.Size = new Size(122, 15);
            pakFolderLabel.TabIndex = 0;
            pakFolderLabel.Text = "Enter Pak Folder Path:";
            // 
            // MainForm
            // 
            ClientSize = new Size(1148, 561);
            Controls.Add(tabControl);
            Name = "MainForm";
            Text = "Joseph's Mod Loader";
            Load += MainForm_Load;
            tabControl.ResumeLayout(false);
            modsTabPage.ResumeLayout(false);
            modsTabPage.PerformLayout();
            settingsTabPage.ResumeLayout(false);
            settingsTabPage.PerformLayout();
            ResumeLayout(false);
        }
    }
}
