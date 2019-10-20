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
        private void newFile()
        {

            fileName = "New graph.txt";
            currentFilePath = fileName;

            isModified = false;
            hasPath = false;
            graph = new Graph();
            graphVisual = new GraphVisual(plot, graph);
            graphAlgo = new GraphAlgo(graph);

            subscribe();

            appState = "ready";
            handleAppState();
            updateInputBounds();

        }

        private void openFile(string filePath)
        {
            currentFilePath = filePath;

            hasPath = true;
            isModified = false;
            StreamReader fileStream = new StreamReader(currentFilePath);
            string firstLine = fileStream.ReadLine();

            string[] type = detectType(firstLine).Split(' ');

            if (type.Length == 1)
            {
                if (type[0] == "undetected_type") return;
                else if (type[0] == "adjacency_matrix") { int[][] adjacencyMatrix = parseMatrix(fileStream); graph = new Graph(adjacencyMatrix); }
                else if (type[0] == "adjacency_list") { graph = new Graph(parseList(fileStream)); }
                else return;
            }
            else if (type.Length == 3)
            {
                if (type[0] == "adjacency_matrix") { int[][] adjacencyMatrix = parseMatrix(fileStream, int.Parse(type[2])); graph = new Graph(adjacencyMatrix); }
                else return;
            }

            fileStream.Close();

            subscribe();

            graphVisual = new GraphVisual(plot, graph);
            graphAlgo = new GraphAlgo(graph);
            appState = "ready";
            handleAppState();
            updateInputBounds();
        }

        private void saveFile(string filePath)
        {
            StreamWriter fileStream = new StreamWriter(filePath);

            fileStream.WriteLine("type : adjacency_list");
            fileStream.WriteLine($"vertices_number : {graph.verticesNumber}");
            fileStream.WriteLine($"edges_number : {graph.edgesNumber}");

            fileStream.Write(graph.getAsList());

            fileStream.Close();

            isModified = false;
            hasPath = true;
            appState = "ready";
            handleAppState();
            updateInputBounds();
        }

        private string getFileName()
        {
            int lastSlashPosition = currentFilePath.LastIndexOf("\\");
            return currentFilePath.Substring(lastSlashPosition + 1, currentFilePath.Length - lastSlashPosition - 1);
        }

        private bool handleExit()
        {
            if (!isModified) return true;
            DialogResult result = MessageBox.Show($"Вы хотите сохранить изменения в файле {currentFilePath}?", title,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            switch (result)
            {
                case DialogResult.Cancel: return false;
                case DialogResult.Yes: SaveFileOption_Click(this, new EventArgs()); break;
            }

            return true;
        }
    }
}
