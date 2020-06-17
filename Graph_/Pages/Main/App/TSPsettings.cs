using Graph_.Pages.Main.App.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_
{
    public partial class TSPsettings : Form
    {
        public TSPsettings()
        {
            InitializeComponent();
            migration.Checked = true;
            befor_frst_migration_txtbx.Text = "1000";
            rnd_pop_txtbx.Text = "10";
            greedy_pop_txtbx.Text = "3";
        }

        private void befor_frst_migration_txtbx_TextChanged(object sender, EventArgs e)
        {
             handleInput((sender as TextBox), true, true);
        }

        void handleInput(TextBox textBox, bool positive = false, bool isInt = false)
        {

            int currentCursorPosition = textBox.SelectionStart;
            textBox.Text = textBox.Text.Replace(',', '.');

            Regex mask;
            if (positive)
            {
                mask = new Regex(@"(\d*).?(\d*)");
            }
            else
            {
                mask = new Regex(@"-?(\d*).?(\d*)");
            }
            Match match = mask.Match(textBox.Text);
            string dot = textBox.Text.IndexOf(".") == -1 ? "" : ".";

            if (match == Match.Empty)
            {
                textBox.Text = "";
            }
            else
            {
                GroupCollection groups = match.Groups;
                if (isInt)
                {
                    textBox.Text = groups[1].Value;
                }
                else
                {
                    textBox.Text = groups[1].Value + dot + groups[2].Value;
                }
            }
            textBox.SelectionStart = currentCursorPosition;
            textBox.SelectionLength = 0;
        }

        private void rnd_pop_txtbx_TextChanged(object sender, EventArgs e)
        {
            handleInput((sender as TextBox), true, true);
        }

        private void greedy_pop_txtbx_TextChanged(object sender, EventArgs e)
        {
            handleInput((sender as TextBox), true, true);
        }
        
        public Dictionary<string, int> get_value ()
        {
            Dictionary<string, int> val = new Dictionary<string, int>();
            if (migration.Checked == true)
            {
                val["migration"] = 1;
            }
            else
            {
                val["migration"] = 0;
            }
            if (befor_frst_migration_txtbx.Text == "")
            {
                befor_frst_migration_txtbx.Text = "0";
            }
            if (rnd_pop_txtbx.Text == "")
            {
                rnd_pop_txtbx.Text = "0";
            }
            if (greedy_pop_txtbx.Text == "")
            {
                greedy_pop_txtbx.Text = "0";
            }
            val["should_migrate"] = Convert.ToInt32(befor_frst_migration_txtbx.Text);
            val["num_rnd"] = Convert.ToInt32(rnd_pop_txtbx.Text);
            val["num_greedy"] = Convert.ToInt32(greedy_pop_txtbx.Text);
            return val;

        }
    }
}
