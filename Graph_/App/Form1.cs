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
        string title = "GraphViewer";
        string currentFilePath="", fileName="";
        string appState = "setup";
        bool isModified = false, hasPath=false, onAnimation=false;
        int traversalTabIndex = 2;

        GraphVisual graphVisual;
        MainWindow mainWindow;
        Graph graph;
        GraphAlgo graphAlgo;

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closingFile()) e.Cancel=true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            graphVisual.reset();
        }

        
        public MainWindow()
        {
            mainWindow = this;
            InitializeComponent();
            handleAppState();
            newFile();
            //openFile(@"C:\Users\len\Documents\1.txt");
        }

        

    }
}
