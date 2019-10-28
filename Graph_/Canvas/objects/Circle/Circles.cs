using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_
{
    public partial class Circles
    {
        WFCanvas.WFCanvasContext context;
        private Dictionary<int, Circle> circles;
        Circle draggedCircle;

        public Circles(WFCanvas.WFCanvasContext context)
        {
            this.context = context;
            this.circles = new Dictionary<int, Circle>();

            context.field.MouseDown += onMouseDown;
            context.field.MouseUp += onMouseUp;
            context.field.MouseMove += onDragging;
        }

        public int addCircle(float r, float x = 0, float y = 0, Color? _color = null)
        {
            
            Color color = _color ?? Color.Black;
            circles.Add(getId(), new Circle(x, y, r));

            return circles.Count() - 1;
        }

        public int addCircle(Circle circle, int? _customId=null)
        {
            int customId = _customId ?? getId();

            circles.Add(customId, circle);
            return circles.Count() - 1;
        }

        public bool changeCircle(int id, float r, float x = 0, float y = 0, Color? _color = null)
        {
            if (id >= circles.Count())
            {
                return false;
            }

            Color color = _color ?? circles[id].borderColor;
            Circle circle = new Circle(x, y, r);
            circle.borderColor = color;

            circles[id] = circle;
            return true;
        }

        public bool changeCircle(int id, Circle circle)
        {
            if (id >= circles.Count())
            {
                return false;
            }

            circles[id] = circle;
            return true;
        }


        public void draw()
        {
            int scale = context.scale;
            PointF center = context.center;
            int basePenWidth = 3;

            foreach (var pair in circles)
            {
                Circle circle = pair.Value;
                RectangleF rect = circle.getAsRectangle();

                

                rect.X = rect.X * scale + center.X;
                rect.Y = center.Y - rect.Y * scale;

                rect.Width *= scale;
                rect.Height *= scale;

                //if (rect.X < 0 && rect.Y < 0 && rect.X + rect.Width < 0 && rect.Y + rect.Height < 0 ||
                //    rect.X < 0 && rect.Y < 0 && rect.X + rect.Width < 0 && rect.Height < 0)
                //{
                //    Console.WriteLine("drawing canceled");
                //    continue;
                //}
                Pen pen = new Pen(circle.isActive?circle.activeColor:circle.borderColor,
                                  circle.isActive?basePenWidth*2:basePenWidth);
                context.graph.DrawEllipse(pen, rect);

                if (circle.isFilled)
                {
                    Brush br = new SolidBrush(circle.fillColor);
                    context.graph.FillEllipse(br, rect);
                }
                
            }
        }

        public Circle getCircle(int id)
        {
            return circles[id];
        }

        public void clear()
        {
            circles.Clear();
        }

        private int getId()
        {
            return Guid.NewGuid().ToString("N").GetHashCode();
        }
    }
}
