using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using matrixComponent;

namespace Graph_
{
    public delegate void SettingsEventListener(object sender, int[,] e);
    public partial class GraphWeightSettings : Form
    {
        public event SettingsEventListener syncEvent;

        Point margin;
        Matrix matrixComponent;
        Graph graph;
        public GraphWeightSettings(Graph graph)
        {
            InitializeComponent();
            this.graph = graph;
            graph.vertexModified += (object sender, GraphEventArgs e) => { updateMatrix((sender as Graph).getAsMatrix()); };
            graph.edgeModified += (object sender, GraphEventArgs e) => { updateMatrix((sender as Graph).getAsMatrix()); };
            margin = new Point(4, 40);
            matrixComponent = new Matrix(graph.getAsMatrix());
            matrixComponent.Location = margin;
            matrixComponent.onMatrixChanged += (object sender, EventArgs e) => { syncEvent?.Invoke(this, matrixComponent.getMatrix()); };
            this.Controls.Add(matrixComponent);
        }

        public void updateMatrix(int[,] matrix)
        {
            matrixComponent.setMatrix(matrix);
        }

        private void increaseMatrixButton_Click(object sender, EventArgs e)
        {
            matrixComponent.increase();
        }

        private void decreaseMatrixButton_Click(object sender, EventArgs e)
        {
            matrixComponent.decrease();
        }

        private void syncButton_Click(object sender, EventArgs e)
        {
            syncEvent?.Invoke(this, matrixComponent.getMatrix());
        }
    }
}
