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

namespace Graph_
{
    public partial class Circles
    {
        private void onMouseDown(object sender, MouseEventArgs e)
        {
            int scale = context.scale;
            foreach (Circle circle in circles.Values)
            {
                PointF convertedCoords = new PointF((e.X - context.center.X) / scale, -(e.Y - context.center.Y) / scale);
                if (circle.isPointIn(convertedCoords))
                {
                    circle.Dragging = true;
                    context.onMouse = true;
                    draggedCircle = circle;
                    break;
                }
            }
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            context.onMouse = false;
            if (draggedCircle != null)
            {
                draggedCircle.Dragging = false;
                draggedCircle = null;
            }
        }

        private void onDragging(object sender, MouseEventArgs e)
        {
            if (!context.isMousePressed || !context.onMouse || draggedCircle==null)
                return;
            int scale = context.scale;
            PointF convertedCoords = new PointF((e.X - context.center.X) / scale, -(e.Y - context.center.Y) / scale);
            draggedCircle.setNewCenter(convertedCoords);
        }
    }
}
