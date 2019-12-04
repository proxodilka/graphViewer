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
using Graph_.Pages.Main.App.Localization;
using System.Threading;

namespace Graph_
{
    public partial class MainWindow : Form
    {

        private void TSP_startGreedyButton_Click(object sender, EventArgs e)
        {
            //changeOnTSPState((sender as Button));
            var ans = graphAlgo.TSP_Greedy((int)TSPStartVertex.Value);
            TSPAnswerHandler(GreedySolutionLabel, ans);
            //changeOnTSPState((sender as Button));
        }

        private async void TSP_startBFSButton_Click(object sender, EventArgs e)
        {
            if (!onTSP)
            {
                changeOnTSPState((sender as Button));
                TSPcancellationToken = new CancellationTokenSource();
                await graphAlgo.TSP_BFS((int)TSPStartVertex.Value, (ans) => TSPAnswerHandler(BFSSolutionLabel, ans), TSPcancellationToken.Token);
                changeOnTSPState((sender as Button));
            }
            else
            {
                TSPcancellationToken.Cancel();
            }
        }

        private async void startTSPButton_Click(object sender, EventArgs e)
        {

            if (!onTSP)
            {
                changeOnTSPState((sender as Button));
                TSPcancellationToken = new CancellationTokenSource();
                await graphAlgo.TSP_BNB((int)TSPStartVertex.Value, (ans) => TSPAnswerHandler(BNBSolutionLabel, ans), TSPcancellationToken.Token);
                changeOnTSPState((sender as Button));
            }
            else
            {
                TSPcancellationToken.Cancel();
            }
        }

        void TSPAnswerHandler(Label target, Tuple<double, List<int>> answer)
        {
            if (target.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    target.Text = $"Weight: {Math.Round(answer.Item1, 6)} | Path: {string.Join("-", answer.Item2)}";
                    Console.WriteLine($"Weight: {answer.Item1} | Path: {string.Join("-", answer.Item2)}");
                    graphVisual.setPath(answer.Item2);
                }));
            }
            else
            {
                target.Text = $"Weight: {answer.Item1} | Path: {string.Join("-", answer.Item2)}";
                graphVisual.setPath(answer.Item2);
            }
            
        }
    }
}
