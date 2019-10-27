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
using Graph_.Localization;

namespace Graph_
{
    public partial class MainWindow : Form
    {
        string unknownFileError = "1",
               parseError = titles.parseError;
        private void newFile()
        {

            fileName = "New graph.txt";
            currentFilePath = fileName;

            history.Clear();
            graph.rewriteGraph();
            graphVisual.init();

            appState = "ready";
            isModified = false;
            hasPath = false;
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
                history.Clear();
                history.Add(graph.get());
                hasPath = true;
                isModified = false;
                currentFilePath = filePath;
                graphVisual.init();

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
            DialogResult result = MessageBox.Show($"{titles.saveFileRequest} {currentFilePath}?", title,
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
            MessageBox.Show(result, titles.fileErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
