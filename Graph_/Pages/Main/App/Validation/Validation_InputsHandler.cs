using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Graph_
{
    public partial class MainWindow : Form
    {
        private void ChangeVertValue_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)(sender as NumericUpDown).Value;
            validateButton(value, deleteVertex);
        }
        private void traversalStartVertex_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown valueContainer = (sender as NumericUpDown);

            int value = (int)valueContainer.Value;
            
            validateButton(value, startTraversal);
            //Console.WriteLine(value);
            if (tabControl.SelectedIndex == traversalTabIndex) { graphVisual.setActive(value); }
        }

        private void FromEdgeValue_ValueChanged(object sender, EventArgs e)
        {
            validateFromToGroup();
        }

        private void ToEdgeValue_ValueChanged(object sender, EventArgs e)
        {
            validateFromToGroup();
        }
    }
}
