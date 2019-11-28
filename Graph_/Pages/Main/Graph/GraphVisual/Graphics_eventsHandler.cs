using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Graph_.Canvas;

namespace Graph_.GraphVisual_
{
    public partial class GraphVisual
    {
        
        private void onVertexAdded(object sender, GraphEventArgs e)
        {
            int vertexNumber = e.Vertices[0];
            nodes.Add(vertexNumber, new Node(vertexNumber, vertexNumber.ToString(), plot.getCurrentCenterCoords()));
            render();
        }

        private void onVertexRemoved(object sender, GraphEventArgs e)
        {
            nodes.Remove(e.Vertices[0]);
            render();
        }

        private void onRewrite(object sender, GraphEventArgs e)
        {
            reset(true);
            nodes.Clear();
            int ind = 0;
            foreach (int vertexNumber in e.Vertices)
            {
                //if (!nodes.ContainsKey(vertexNumber))
                nodes.Add(vertexNumber, new Node(vertexNumber, vertexNumber.ToString(), getCoordsByN(ind)));
                ind++;
            }
            render(true);
        }

        private void onEdgesChanged(object sender, GraphEventArgs e)
        {
            render();
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            PointF convertedCoords = plot.translateCoords(e.Location);
            mouseCoords.onChange(convertedCoords);

            if (hasBindedLines)
            {
                render();
            }
        }
    }
}
