using Graph_.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_
{
    public partial class Settings : Form
    {
        List<CultureInfo> languagesList;
        public Settings()
        {
            languagesList = new List<CultureInfo>() {
                CultureInfo.CreateSpecificCulture("en"),
                CultureInfo.CreateSpecificCulture("ru")
            };

            InitializeComponent();
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CreateFileAtStartup = isCreateNewFileCheckBox.Checked;
            if (Properties.Settings.Default.Language != (languagesComboBox.SelectedItem as CultureInfo).Name)
            {
                Properties.Settings.Default.Language = (languagesComboBox.SelectedItem as CultureInfo).Name;
                MessageBox.Show(titles.savingChangesMessage, titles.settingsTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Properties.Settings.Default.Save();


            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            CultureInfo userCulture = CultureInfo.CreateSpecificCulture(Properties.Settings.Default.Language);

            languagesComboBox.DataSource = languagesList;
            languagesComboBox.DisplayMember = "NativeName";
            languagesComboBox.SelectedItem = userCulture;

            isCreateNewFileCheckBox.Checked = Properties.Settings.Default.CreateFileAtStartup;
        }
    }
}
