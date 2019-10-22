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
        string unknownFileError = "Неизвестный тип файла",
               parseError = "Не могу распарсить граф, проверьте файл.";
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
             
            StreamReader fileStream = new StreamReader(filePath);
            string firstLine = fileStream.ReadLine();

            string[] type = detectType(firstLine).Split(' ');
            bool fileOk = tryToParseGraph(fileStream, type);
            
            fileStream.Close();

            if (fileOk)
            {
                hasPath = true;
                isModified = false;
                currentFilePath = filePath;
                graphVisual = new GraphVisual(plot, graph);
                graphAlgo = new GraphAlgo(graph);
                subscribe();

                appState = "ready";
                handleAppState();
                updateInputBounds();
            }
            
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

        private void showError(Exception e, string errorType)
        {
            string lineN = e.Data["lineN"].ToString(),
                   type = e.Data["type"].ToString(),
                   line = e.Data["line"].ToString();

            onError(errorType, $"Тип = {type}\n" +
                                $"Ошибка в строке = {lineN}\n" +
                                $"Строка = \"{line}\"");
        }

        private void onError(params string[] text)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
                result += text[i];
            MessageBox.Show(result, "Ошибка открытия файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
