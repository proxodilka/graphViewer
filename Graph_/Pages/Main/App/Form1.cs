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
using Graph_.Properties;
using System.Threading;
using System.Globalization;
using Graph_.Pages.Main.App.Localization;

namespace Graph_
{
    public partial class MainWindow : Form
    {
        string title = "GraphViewer";
        string currentFilePath="", fileName="";
        string appState = "setup";
        bool isModified = false, hasPath=false, onAnimation=false;
        int traversalTabIndex = 2;

        WFCanvas canvas;
        GraphVisual graphVisual;
        MainWindow mainWindow;
        Graph graph;
        GraphAlgo graphAlgo;

        List<Dictionary<int, HashSet<int>>> history;

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
            DialogResult result = MessageBox.Show(titles.clearGraphRequest,
                                  titles.clearGraphTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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

        private void CentrateButton_Click(object sender, EventArgs e)
        {
            graphVisual.centrate();
        }

        private void settingsOption_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();
            settingsForm.ShowDialog();
        }


        private void setWeightButton_Click(object sender, EventArgs e)
        {
            GraphWeightSettings graphWeightSettings = new GraphWeightSettings(graph);
            graphWeightSettings.syncEvent += onRewriteMatrix;
            graphWeightSettings.FormClosed += (object _sender, FormClosedEventArgs _e) => { setWeightButton.Enabled = isWeightedCheckBox.Checked; graphWeightSettingsOpened = false; };
            graphWeightSettings.Show();
            graphWeightSettingsOpened = true;
            setWeightButton.Enabled = false;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closingFile()) e.Cancel=true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            graphVisual.reset();
        }

        private void edgesAtCircleButton_Click(object sender, EventArgs e)
        {
            graphVisual.resetNodesCoords();
        }

        void onRewriteMatrix(object sender, int[,] matrix)
        {
            var nodesCoordinates = graphVisual.getNodesCoords();
            graph.rewriteGraph(matrix);
            graphVisual.setNodesCoords(nodesCoordinates, true); 
        }

        private void startTSPButton_Click(object sender, EventArgs e)
        {
            graphAlgo.TSP_BFS((int)TSPStartVertex.Value);
        }

        //private void traversalStartVertex_ValueChanged(object sender, EventArgs e)
        //{

        //}

        //private void TraversalStartVertex_KeyUp(object sender, KeyEventArgs e)
        //{

        //}

        private void initLanguage()
        {

            string userLang = Properties.Settings.Default.Language;
            if (userLang == "auto")
            {
                userLang = Thread.CurrentThread.CurrentCulture.Name;
                Properties.Settings.Default.Language = userLang;
                Properties.Settings.Default.Save();
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(userLang);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(userLang);

            Console.WriteLine(Thread.CurrentThread.CurrentCulture.NativeName);
        }

        private void tests()
        {
            PointF x = new PointF(0, 0);
            PointF a = x;
            PointF b = x;
            a.X = 20;
            //int xa = 100000000009;
            //Console.WriteLine(xa);
        }
        
        public MainWindow()
        {
            initLanguage();
            //tests();
            InitializeComponent();

            mainWindow = this;
            KeyPreview = true;
            this.DoubleBuffered = true;
            canvas = new WFCanvas(plot);
            graph = new Graph();
            graphVisual = new GraphVisual(canvas, graph);
            graphAlgo = new GraphAlgo(graph);
            history = new List<Dictionary<int, HashSet<int>>>();

            subscribe();
            handleAppState();
            if (Properties.Settings.Default.CreateFileAtStartup) newFile();
            //Console.WriteLine(Resources.Culture);
            //Properties.Settings.Default.CreateFileAtStartup = false;
            //Properties.Settings.Default.Save();
            //openFile(@"C:\Users\len\Documents\center_test.txt");
            //Colors colorManager = new Colors();


            //Console.WriteLine(colorManager.calcContrastRatio(Color.White, Color.Green));
            //Console.WriteLine(colorManager.calcContrastRatio(Color.Black, Color.Green));
            openFile(@"C:\Users\rp-re\OneDrive\Документы\1.txt");
        }

        

    }
}
