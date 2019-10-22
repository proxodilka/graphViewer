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
using Graph_.Canvas;
using Graph_.GraphVisual_;

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

        private void MakeGraphComplete_Click(object sender, EventArgs e)
        {
            int goingToAdd = graph.verticesNumber + (graph.verticesNumber * (graph.verticesNumber - 1)) / 2 - graph.edgesNumber;


            //DialogResult result = MessageBox.Show($"Сейчас в граф будет добавлено {goingToAdd} вершин. " +
            //                    $"Это может занять продолжительное время," +
            //                    $" продолжить?", "Сделать граф полным?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (/*result == DialogResult.Yes*/true)
                graph.makeGraphComplete();
        }

        private void ClearEdges_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить все ребра в графе?",
                                  "Очистить граф?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
                graph.clearEdges();
        }

        private void Plot_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            Console.WriteLine("dragging");
        }

        private void Plot_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            Console.WriteLine("dragging");
            
        }

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
            KeyPreview = true;
            InitializeComponent();
            handleAppState();
            newFile();
            openFile(@"C:\Users\len\Documents\bfs_vs_dfs.txt");
            //Colors colorManager = new Colors();


            //Console.WriteLine(colorManager.calcContrastRatio(Color.White, Color.Green));
            //Console.WriteLine(colorManager.calcContrastRatio(Color.Black, Color.Green));
            //openFile(@"C:\Users\len\Documents\1.txt");
        }

        

    }
}
