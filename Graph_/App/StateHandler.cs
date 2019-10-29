﻿using System;
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
using Graph_.Localization;

namespace Graph_
{
    public partial class MainWindow : Form
    {
        bool makingEdgeOnCanvas = false;
        int MakingEdgeOnCanvasFromVertex = -1;
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
                startTraversal.Text = titles.StopTitle;
            }
            else
            {
                startTraversal.Text = titles.StartTitle;
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
            vertexValue.Text = $"{titles.verticesTitle} {graph?.verticesNumber}";
            edgesValue.Text = $"{titles.edgesTitle} {graph?.edgesNumber}";
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
                        plot.Enabled = false;
                        saveAsFileOption.Enabled = false;
                        saveFileOption.Enabled = false;
                        currentFilePath = "";
                        break;
                    }
                case "ready":
                    {
                        centrateButton.Enabled = true;
                        tabControl.Enabled = true;
                        plot.Enabled = true;
                        saveAsFileOption.Enabled = true;
                        saveFileOption.Enabled = true;
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

            canvas.onClick += onCanvasClick;
        }

        private void onCanvasClick(object sender, MouseEventArgs e)
        {
            PointF coords = canvas.translateCoords(e.Location);
            int clickedNode = graphVisual.getNodeByCoords(coords);
            Tuple<int, int> clickedEdge = graphVisual.getEdgeByCoords(coords);

            if (clickedEdge!=null && e.Button == MouseButtons.Right) //click on existing edge (removing this edge)
            {
                graph.removeEdge(clickedEdge.Item1, clickedEdge.Item2);
            }
            else if (clickedNode==-1 && makingEdgeOnCanvas) //click on empty field while making edge
            {
                graphVisual.unbindLineFromVertex(MakingEdgeOnCanvasFromVertex);

                makingEdgeOnCanvas = false;
                MakingEdgeOnCanvasFromVertex = -1;
                return;
            }
            else if (e.Button == MouseButtons.Left && clickedNode == -1) //left click on empty field (creating new vertex)
            {
                int newVertexNumber = graph.addVertex();
                graphVisual.setNodeCoords(newVertexNumber, coords);

            }
            else if (e.Button == MouseButtons.Right && clickedNode != -1) //right click on existing vertex (removing this vertex)
            {
                graph.removeVertex(clickedNode);
            }
            else if (e.Button == MouseButtons.Left && clickedNode != -1) //left click on existing vertex (trying to make new edge)
            {
                if (makingEdgeOnCanvas)
                {
                    graph.addEdge(MakingEdgeOnCanvasFromVertex, clickedNode);
                    graphVisual.unbindLineFromVertex(MakingEdgeOnCanvasFromVertex);

                    makingEdgeOnCanvas = false;
                    MakingEdgeOnCanvasFromVertex = -1;
                }
                else
                {
                    makingEdgeOnCanvas = true;
                    MakingEdgeOnCanvasFromVertex = clickedNode;

                    graphVisual.bindLineToVertex(clickedNode);
                }
            }


        }

        private void onModify(object sender, GraphEventArgs e)
        {
            isModified = true;
            history.Add(graph.get());

            undoButton.Enabled = true;
            if (history.Count > 20)
            {
                history.RemoveAt(0);
            }
        }

        private void onGraphicsUpdate(object sender)
        {
            Console.WriteLine("onRender");
            resetButton.Enabled = (sender as GraphVisual).isCanvasDirty;
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (history.Count == 1) return;
            history.RemoveAt(history.Count - 1);

            var nodesCoordinates = graphVisual.getNodesCoords();
            graph.rewriteGraph(history.Last());
            graphVisual.setNodesCoords(nodesCoordinates);

            history.RemoveAt(history.Count - 1);
        }
    }
}
