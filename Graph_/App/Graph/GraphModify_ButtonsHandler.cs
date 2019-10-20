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
        private void AddVertex_Click(object sender, EventArgs e)
        {
            int value = (int)changeVertValue.Value;
            graph.addVertex();
        }

        private void DeleteVertex_Click(object sender, EventArgs e)
        {
            int value = (int)changeVertValue.Value;
            graph.removeVertex(value);
        }

        private void AddEdge_Click(object sender, EventArgs e)
        {
            graph.addEdge((int)fromEdgeValue.Value, (int)toEdgeValue.Value);
        }
        private void DeleteEdge_Click(object sender, EventArgs e)
        {
            graph.removeEdge((int)fromEdgeValue.Value, (int)toEdgeValue.Value);
        }
    }
}
