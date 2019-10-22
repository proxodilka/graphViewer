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
       
        private void validateButtons()
        {
            //resetButton.Enabled = graphVisual.isCanvasDirty;
            ChangeVertValue_ValueChanged(changeVertValue, new EventArgs());
            traversalStartVertex_ValueChanged(traversalStartVertex, new EventArgs());
            FromEdgeValue_ValueChanged(fromEdgeValue, new EventArgs());
            ToEdgeValue_ValueChanged(toEdgeValue, new EventArgs());
            validateFromToGroup();
        }

        private bool validateButton(int value, Button button)
        {
            if (!graph.hasVertex(value))
            {
                button.Enabled = false;
                return false;
            }
            else
            {
                button.Enabled = true;
                return true;
            }
        }

        private void validateFromToGroup()
        {
            int fromValue = (int)fromEdgeValue.Value, toValue = (int)toEdgeValue.Value;
            bool fromRes = validateButton(fromValue, addEdge), toRes = validateButton(toValue, addEdge),
                 hasEdgeRes = graph.hasEdge(fromValue, toValue);

            addEdge.Enabled = fromRes && toRes;
            deleteEdge.Enabled = fromRes && toRes && hasEdgeRes;
        }
    }
}
