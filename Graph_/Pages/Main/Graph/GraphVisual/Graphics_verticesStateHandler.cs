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
        public void setNodeSize(float newSize)
        {
            foreach(Node node in nodes.Values)
            {
                node.nodeSize = newSize;
            }
            render();
        }

        public void setActive(int vertexNumber, bool rerender = true)
        {
            activeVertices.Clear();
            activeVertices.Add(vertexNumber);
            hasActiveVertex = true;
            if (rerender) render();
        }

        public void markVertex(int vertexNumber, int color = 1, bool rerender = true)
        {
            markedVertices[vertexNumber] = colors.getColor(color - 1);
            if (rerender) render();
        }

        public void setActive(bool x)
        {
            activeVertices.Clear();
            if (hasActiveVertex) render();
            hasActiveVertex = false;
        }


        public void bindLineToVertex(int vertexNumber)
        {
            if (!nodes.ContainsKey(vertexNumber))
                return;

            Line line = new Line(nodes[vertexNumber].MutableCenter, mouseCoords, Color.Gray);
            bindedLines.Add(vertexNumber, line);
            hasBindedLines = true;
        }

        public void unbindLineFromVertex(int vertexNumber)
        {
            bindedLines.Remove(vertexNumber);
            if (bindedLines.Count == 0)
            {
                hasBindedLines = false;
            }
            render();
        }
    }
}
