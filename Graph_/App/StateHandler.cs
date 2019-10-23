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
using Graph_.GraphVisual_;

namespace Graph_
{
    public partial class MainWindow : Form
    {
        private bool closingFile()
        {
            bool allowToClose;
            graphVisual.stopAnimation();
            allowToClose = handleExit();

            return allowToClose;
        }
        private void changeOnAnimationState()
        {
            onAnimation = !onAnimation;

            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab.Enabled = !onAnimation);
            }
            tabControl.TabPages[traversalTabIndex].Enabled = true;

            traversalStartVertex.Enabled = !onAnimation;
            isDfs.Enabled = !onAnimation;
            isBfs.Enabled = !onAnimation;
            isConnectedComponents.Enabled = !onAnimation;
            resetButton.Enabled = !onAnimation;

            if (onAnimation)
            {
                startTraversal.Text = "Стоп";
            }
            else
            {
                startTraversal.Text = "Старт";
            }

        }
        private void updateInputBounds(object sender = null, GraphEventArgs e = null)
        {
            int maxVertexNumber = graph.getMaxVertexNumber();
            int minVertexNumber = graph.getMinVertexNumber();

            changeVertValue.Maximum = maxVertexNumber;
            traversalStartVertex.Maximum = maxVertexNumber;
            fromEdgeValue.Maximum = maxVertexNumber;
            toEdgeValue.Maximum = maxVertexNumber;

            changeVertValue.Minimum = minVertexNumber;
            traversalStartVertex.Minimum = minVertexNumber;
            fromEdgeValue.Minimum = minVertexNumber;
            toEdgeValue.Minimum = minVertexNumber;

            validateButtons();
        }

        private void updateInfo(object sender = null, GraphEventArgs e = null)
        {
            fileName = getFileName();
            string fileNameTitle = fileName + (isModified ? "*" : "");
            mainWindow.Text = $"{fileNameTitle} - {title}";
            filePathLabel.Text = currentFilePath;
            vertexValue.Text = $"Vertices: {graph?.verticesNumber}";
            edgesValue.Text = $"Edges: {graph?.edgesNumber}";
            if (isModified) { filePathLabel.Text += "*"; }
        }

        private void handleAppState()
        {
            switch (appState)
            {
                case "setup":
                    {
                        tabControl.Enabled = false;
                        centrateButton.Enabled = false;
                        currentFilePath = "";
                        break;
                    }
                case "ready":
                    {
                        centrateButton.Enabled = true;
                        tabControl.Enabled = true;
                        break;
                    }
            }
            updateInfo();
        }

        private void subscribe()
        {
            graph.vertexModified += onModify;
            graph.vertexModified += updateInfo;
            graph.vertexModified += updateInputBounds;

            graph.edgeModified += onModify;
            graph.edgeModified += updateInfo;
            graph.edgeModified += updateInputBounds;

            graphVisual.didUpdate += onGraphicsUpdate;
            onGraphicsUpdate(graphVisual);
        }

        private void onModify(object sender, GraphEventArgs e)
        {
            isModified = true;
        }

        private void onGraphicsUpdate(object sender)
        {
            Console.WriteLine("onRender");
            resetButton.Enabled = (sender as GraphVisual).isCanvasDirty;
        }
    }
}
