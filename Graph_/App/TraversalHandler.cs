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
        async private void StartTraversal_Click(object sender, EventArgs e)
        {
            if (!onAnimation)
            {
                int value = (int)traversalStartVertex.Value;
                List<int> path = null;

                if (isDfs.Checked) path = graphAlgo.dfs(value);
                else if (isBfs.Checked) path = graphAlgo.bfs(value);

                changeOnAnimationState();
                await graphVisual.animate(path);
                changeOnAnimationState();
            }
            else
            {
                graphVisual.stopAnimation();
                graphVisual.reset();
                updateActiveVertex();
            }
        }

        private void updateActiveVertex()
        {
            graphVisual.setActive((int)traversalStartVertex.Value);
        }

        private void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (onAnimation) { e.Cancel = true; return; }
            if (tabControl.SelectedIndex == traversalTabIndex) { updateActiveVertex(); }
            else { graphVisual.setActive(false); }
        }

        private void TraversalStartVertex_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
            {
                updateActiveVertex();
            }
        }
    }
}
