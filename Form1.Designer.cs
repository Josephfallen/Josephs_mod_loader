namespace NN_ModLoaderGUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage modsTabPage;
        private System.Windows.Forms.TabPage settingsTabPage;
        private System.Windows.Forms.TabPage creditsTabPage;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ListView modsListView;
        private System.Windows.Forms.Button enableModButton;
        private System.Windows.Forms.Button uploadModButton;
        private System.Windows.Forms.Button deleteModButton; // Add delete button
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.TextBox pakFolderTextBox;
        private System.Windows.Forms.Label pakFolderLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label creditsLabel;
        private System.Windows.Forms.Label creditsTextLabel;
        private System.Windows.Forms.Label contributorsLabel;
        private System.Windows.Forms.Label librariesLabel;

        // Add version and description labels
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label descriptionLabel;

        // Dispose method
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
            modsListView = new ListView();
            enableModButton = new Button();
            uploadModButton = new Button();
            deleteModButton = new Button(); // Initialize delete button
            settingsTabPage = new TabPage();
            pakFolderTextBox = new TextBox();
            saveSettingsButton = new Button();
            pakFolderLabel = new Label();
            titleLabel = new Label();
            creditsTabPage = new TabPage();
            creditsLabel = new Label();
            creditsTextLabel = new Label();
            contributorsLabel = new Label();
            librariesLabel = new Label();

            // Initialize versionLabel and descriptionLabel
            versionLabel = new Label();
            descriptionLabel = new Label();

            tabControl.SuspendLayout();
            modsTabPage.SuspendLayout();
            settingsTabPage.SuspendLayout();
            creditsTabPage.SuspendLayout();
            SuspendLayout();

            // 
            // deleteModButton
            // 
            deleteModButton.Location = new Point(430, 150); // Position below the other buttons
            deleteModButton.Name = "deleteModButton";
            deleteModButton.Size = new Size(150, 35);
            deleteModButton.TabIndex = 6;
            deleteModButton.Text = "Delete Mod";
            deleteModButton.UseVisualStyleBackColor = true;
            deleteModButton.Click += deleteModButton_Click;

            // 
            // versionLabel
            // 
            versionLabel.AutoSize = true;
            versionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            versionLabel.Location = new Point(10, 460);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(150, 19);
            versionLabel.TabIndex = 6;
            versionLabel.Text = "Version: Not Available";

            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            descriptionLabel.Location = new Point(10, 485);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(200, 19);
            descriptionLabel.TabIndex = 7;
            descriptionLabel.Text = "Description: Not Available";

            // 
            // tabControl
            // 
            tabControl.Controls.Add(modsTabPage);
            tabControl.Controls.Add(settingsTabPage);
            tabControl.Controls.Add(creditsTabPage);
            tabControl.Location = new Point(12, 50);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1124, 537);
            tabControl.TabIndex = 0;
            tabControl.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            // 
            // modsTabPage
            // 
            modsTabPage.Controls.Add(statusLabel);
            modsTabPage.Controls.Add(modsListView);
            modsTabPage.Controls.Add(enableModButton);
            modsTabPage.Controls.Add(uploadModButton);
            modsTabPage.Controls.Add(deleteModButton); // Add delete button to modsTabPage
            modsTabPage.Controls.Add(versionLabel); // Add to modsTabPage
            modsTabPage.Controls.Add(descriptionLabel); // Add to modsTabPage
            modsTabPage.Location = new Point(4, 29);
            modsTabPage.Name = "modsTabPage";
            modsTabPage.Padding = new Padding(10);
            modsTabPage.Size = new Size(1116, 504);
            modsTabPage.TabIndex = 0;
            modsTabPage.Text = "Mods";
            modsTabPage.UseVisualStyleBackColor = true;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            statusLabel.Location = new Point(10, 15);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(50, 19);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "Status:";

            // 
            // modsListView
            // 
            modsListView.Location = new Point(10, 50);
            modsListView.Name = "modsListView";
            modsListView.Size = new Size(400, 400);
            modsListView.TabIndex = 3;
            modsListView.View = View.Details;
            modsListView.Columns.Add("Name", 150);
            modsListView.Columns.Add("Description", 200);
            modsListView.Columns.Add("Version", 50);
            modsListView.FullRowSelect = true;

            // 
            // enableModButton
            // 
            enableModButton.Location = new Point(430, 50);
            enableModButton.Name = "enableModButton";
            enableModButton.Size = new Size(150, 35);
            enableModButton.TabIndex = 4;
            enableModButton.Text = "Enable Mod";
            enableModButton.UseVisualStyleBackColor = true;
            enableModButton.Click += enableModButton_Click;

            // 
            // uploadModButton
            // 
            uploadModButton.Location = new Point(430, 100);
            uploadModButton.Name = "uploadModButton";
            uploadModButton.Size = new Size(150, 35);
            uploadModButton.TabIndex = 5;
            uploadModButton.Text = "Upload Mod";
            uploadModButton.UseVisualStyleBackColor = true;
            uploadModButton.Click += uploadModButton_Click;

            // 
            // deleteModButton
            // 
            deleteModButton.Location = new Point(430, 150);
            deleteModButton.Name = "deleteModButton";
            deleteModButton.Size = new Size(150, 35);
            deleteModButton.TabIndex = 6;
            deleteModButton.Text = "Delete Mod";
            deleteModButton.UseVisualStyleBackColor = true;
            deleteModButton.Click += deleteModButton_Click; // Handle button click

            // 
            // settingsTabPage
            // 
            settingsTabPage.Controls.Add(pakFolderTextBox);
            settingsTabPage.Controls.Add(saveSettingsButton);
            settingsTabPage.Controls.Add(pakFolderLabel);
            settingsTabPage.Location = new Point(4, 29);
            settingsTabPage.Name = "settingsTabPage";
            settingsTabPage.Padding = new Padding(10);
            settingsTabPage.Size = new Size(1116, 504);
            settingsTabPage.TabIndex = 1;
            settingsTabPage.Text = "Settings";
            settingsTabPage.UseVisualStyleBackColor = true;

            // 
            // pakFolderTextBox
            // 
            pakFolderTextBox.Location = new Point(10, 50);
            pakFolderTextBox.Name = "pakFolderTextBox";
            pakFolderTextBox.PlaceholderText = "Enter the path to your .pak files...";
            pakFolderTextBox.Size = new Size(700, 25);
            pakFolderTextBox.TabIndex = 1;

            // 
            // saveSettingsButton
            // 
            saveSettingsButton.Location = new Point(10, 90);
            saveSettingsButton.Name = "saveSettingsButton";
            saveSettingsButton.Size = new Size(150, 35);
            saveSettingsButton.TabIndex = 2;
            saveSettingsButton.Text = "Save Settings";
            saveSettingsButton.UseVisualStyleBackColor = true;
            saveSettingsButton.Click += saveSettingsButton_Click;

            // 
            // pakFolderLabel
            // 
            pakFolderLabel.AutoSize = true;
            pakFolderLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            pakFolderLabel.Location = new Point(10, 20);
            pakFolderLabel.Name = "pakFolderLabel";
            pakFolderLabel.Size = new Size(160, 19);
            pakFolderLabel.TabIndex = 0;
            pakFolderLabel.Text = "Pak Folder Path Settings:";

            // 
            // creditsTabPage
            // 
            creditsTabPage.Controls.Add(creditsLabel);
            creditsTabPage.Controls.Add(creditsTextLabel);
            creditsTabPage.Controls.Add(contributorsLabel);
            creditsTabPage.Controls.Add(librariesLabel);
            creditsTabPage.Location = new Point(4, 29);
            creditsTabPage.Name = "creditsTabPage";
            creditsTabPage.Padding = new Padding(10);
            creditsTabPage.Size = new Size(1116, 504);
            creditsTabPage.TabIndex = 2;
            creditsTabPage.Text = "Credits";
            creditsTabPage.UseVisualStyleBackColor = true;

            // 
            // creditsLabel
            // 
            creditsLabel.AutoSize = true;
            creditsLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            creditsLabel.Location = new Point(10, 10);
            creditsLabel.Name = "creditsLabel";
            creditsLabel.Size = new Size(88, 25);
            creditsLabel.TabIndex = 0;
            creditsLabel.Text = "Credits:";

            // 
            // contributorsLabel
            // 
            contributorsLabel.AutoSize = true;
            contributorsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            contributorsLabel.Location = new Point(10, 50);
            contributorsLabel.Name = "contributorsLabel";
            contributorsLabel.Size = new Size(150, 21);
            contributorsLabel.TabIndex = 1;
            contributorsLabel.Text = "Lead Developer: Joseph";

            // 
            // librariesLabel
            // 
            librariesLabel.AutoSize = true;
            librariesLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            librariesLabel.Location = new Point(10, 100);
            librariesLabel.Name = "librariesLabel";
            librariesLabel.Size = new Size(150, 21);
            librariesLabel.TabIndex = 2;
            librariesLabel.Text = "Libraries: Newtonsoft.Json";

            // 
            // creditsTextLabel
            // 
            creditsTextLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            creditsTextLabel.Location = new Point(10, 150);
            creditsTextLabel.Name = "creditsTextLabel";
            creditsTextLabel.Size = new Size(1100, 300);
            creditsTextLabel.TabIndex = 3;


            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Location = new Point(12, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(252, 32);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Joseph's Mod Loader";

            // 
            // MainForm
            // 
            ClientSize = new Size(1150, 600);
            Controls.Add(titleLabel);
            Controls.Add(tabControl);
            Name = "MainForm";
            Text = "Joseph's Mod Loader";
            Load += MainForm_Load;
            tabControl.ResumeLayout(false);
            modsTabPage.ResumeLayout(false);
            modsTabPage.PerformLayout();
            settingsTabPage.ResumeLayout(false);
            settingsTabPage.PerformLayout();
            creditsTabPage.ResumeLayout(false);
            creditsTabPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
