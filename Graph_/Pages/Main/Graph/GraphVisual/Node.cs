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
    public class Node
    {
        int id;
        public string title { get; set; }
        public Circle Cirle { get { return circle; } }

        public float nodeSize { get { return circle.r; } set { circle.r = value; text.fontSize = value; } }

        Circle circle;
        Text text;

        public Node(int _id, string _title, PointF initialCoords, float nodeSize = 1)
        {
            id = _id;
            circle = new Circle(initialCoords, nodeSize, true, false);
            circle.fillColor = Color.White;
            text = new Text(_title, circle.getCenterAsMutable(), nodeSize, Color.Black);
        }

        public void draw(WFCanvas plot, bool isNodeActive, bool isNodeMarked, Color color)
        {
            if (isNodeActive)
                circle.isActive = true;
            else
                circle.isActive = false;

            if (isNodeMarked)
                circle.fillColor = color;
            else
                circle.fillColor = Color.White;

            plot.Circles.addCircle(circle);

            text.Color = Colors.getTextColorByBackground(circle.fillColor);

            plot.Texts.addText(text);
        }

        public bool isPointIn(PointF point)
        {
            return circle.isPointIn(point);
        }

        public PointF Center
        {
            get
            {
                return circle.Center;
            }
            set
            {
                circle.setNewCenter(value);
            }
        }

        public int ID { get { return id; } }
        public MutablePoint MutableCenter { get { return circle.getCenterAsMutable(); } }

    }
}
