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
    public class Polygon
    {
        string mode;
        List<PointF> polygon;
        List<MutablePoint> mutablePolygon;
        Color fillColor;

        public string Mode { get { return mode; } }
        public List<PointF> Shape { get
            {
                if (mode == "static")
                {
                    return polygon;
                }
                List<PointF> translatedPoints = new List<PointF>();
                foreach(MutablePoint point in mutablePolygon)
                {
                    translatedPoints.Add(point.value);
                }
                return translatedPoints;
            } 
        }

        public Color Color { get { return fillColor; } }

        public Polygon(List<PointF> points)
        {
            polygon = points;
            fillColor = Color.Transparent;
            mode = "static";
        }

        public Polygon(List<PointF> points, Color _fillColor) : this(points)
        {
            fillColor = _fillColor;
            mode = "static";
        }

        public Polygon(List<MutablePoint> points)
        {
            mutablePolygon = points;
            fillColor = Color.Transparent;
            mode = "mutable";
        }

        public Polygon(List<MutablePoint> points, Color _fillColor) : this(points)
        {
            fillColor = _fillColor;
            mode = "mutable";
        }


    }
}
