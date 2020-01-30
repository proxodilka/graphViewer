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
        bool isModified = false, hasPath=false, onAnimation=false, onTSP=false, isTabControlBlocked=false;
        int traversalTabIndex = 2;
        int TSPTabIndex = 3;

        WFCanvas canvas;
        GraphVisual graphVisual;
        MainWindow mainWindow;
        Graph graph;
        GraphAlgo graphAlgo;
        CancellationTokenSource TSPcancellationToken;

        List<Dictionary<int, Dictionary<int, double>>> history;

        private void MakeGraphComplete_Click(object sender, EventArgs e)
        {
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

        void debugFeatures()
        {
            var g = graph.get();
            foreach(var pair in g)
            {
                foreach(double pair2 in pair.Value.Values)
                {
                    if (pair2 <= 0)
                    {
                        Console.WriteLine("error!!!!");
                    }
                }
            }
        }

        private void CentrateButton_Click(object sender, EventArgs e)
        {
            graphVisual.centrate();
            debugFeatures();
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

        private void clearCanvasButton_Click(object sender, EventArgs e)
        {
            graphVisual.reset();
        }


        void setWeightsByCoords()
        {
            Dictionary<int, PointF> coords = graphVisual.getNodesCoords();
            Dictionary<int, Dictionary<int, double>> graphInfo = graph.get(),
                                                     duplicate = new Dictionary<int, Dictionary<int, double>>();

            foreach (var vertex in graphInfo)
            {
                duplicate[vertex.Key] = new Dictionary<int, double>();
                foreach (var adjacencyVertex in vertex.Value)
                {
                    PointF first = coords[vertex.Key], second = coords[adjacencyVertex.Key];
                    duplicate[vertex.Key][adjacencyVertex.Key] = Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));
                    if (duplicate[vertex.Key][adjacencyVertex.Key] == 0)
                    {
                        duplicate[vertex.Key][adjacencyVertex.Key] = 0.0001f;
                    }
                }
            }

            graph.rewriteGraph(duplicate);
            graphVisual.setNodesCoords(coords);
        }

        private void setWeightsByCoordsButton_Click(object sender, EventArgs e)
        {
            setWeightsByCoords();
        }

        private void resetNodeSizeButton_Click(object sender, EventArgs e)
        {
            scallerTrackBar.Value = 10;
        }

        private void scallerTrackBar_ValueChanged(object sender, EventArgs e)
        {
            graphVisual.setNodeSize((sender as TrackBar).Value / 10.0f);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            graphVisual.reset();
        }

        private void edgesAtCircleButton_Click(object sender, EventArgs e)
        {
            graphVisual.resetNodesCoords();
        }

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
        
        public MainWindow()
        {
            initLanguage();
            InitializeComponent();

            mainWindow = this;
            KeyPreview = true;
            this.DoubleBuffered = true;
            canvas = new WFCanvas(plot);
            graph = new Graph();
            graphVisual = new GraphVisual(canvas, graph);
            graphAlgo = new GraphAlgo(graph);
            history = new List<Dictionary<int, Dictionary<int, double>>>();

            subscribe();
            handleAppState();
            if (Properties.Settings.Default.CreateFileAtStartup) newFile();
        }

        

    }
}
