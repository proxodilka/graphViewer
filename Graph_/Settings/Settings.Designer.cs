namespace Graph_
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.settingsLabel = new System.Windows.Forms.Label();
            this.languageLabel = new System.Windows.Forms.Label();
            this.languagesComboBox = new System.Windows.Forms.ComboBox();
            this.isCreateNewFileCheckBox = new System.Windows.Forms.CheckBox();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // settingsLabel
            // 
            resources.ApplyResources(this.settingsLabel, "settingsLabel");
            this.settingsLabel.Name = "settingsLabel";
            // 
            // languageLabel
            // 
            resources.ApplyResources(this.languageLabel, "languageLabel");
            this.languageLabel.Name = "languageLabel";
            // 
            // languagesComboBox
            // 
            this.languagesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languagesComboBox.FormattingEnabled = true;
            this.languagesComboBox.Items.AddRange(new object[] {
            resources.GetString("languagesComboBox.Items"),
            resources.GetString("languagesComboBox.Items1")});
            resources.ApplyResources(this.languagesComboBox, "languagesComboBox");
            this.languagesComboBox.Name = "languagesComboBox";
            // 
            // isCreateNewFileCheckBox
            // 
            resources.ApplyResources(this.isCreateNewFileCheckBox, "isCreateNewFileCheckBox");
            this.isCreateNewFileCheckBox.Name = "isCreateNewFileCheckBox";
            this.isCreateNewFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveSettingsButton
            // 
            resources.ApplyResources(this.saveSettingsButton, "saveSettingsButton");
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.isCreateNewFileCheckBox);
            this.Controls.Add(this.languagesComboBox);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.settingsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.ComboBox languagesComboBox;
        private System.Windows.Forms.CheckBox isCreateNewFileCheckBox;
        private System.Windows.Forms.Button saveSettingsButton;
    }
}