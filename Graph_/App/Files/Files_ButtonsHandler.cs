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
        private void OpenFileOption_Click(object sender, EventArgs e)
        {
            if (!closingFile()) return;
            if (openGraphFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFile(openGraphFileDialog.FileName);
            }
        }

        private void SaveAsFileOption_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = fileName;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;
            //saveFileDialog.AddExtension = "txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = saveFileDialog.FileName;
                saveFile(currentFilePath);
            }
        }
        private void SaveFileOption_Click(object sender, EventArgs e)
        {
            if (!hasPath)
            {
                SaveAsFileOption_Click(sender, e);
                return;
            }
            saveFile(currentFilePath);
        }
        private void NewFileOption_Click(object sender, EventArgs e)
        {
            if (!closingFile()) return;
            newFile();
        }

        private void ExitOption_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
