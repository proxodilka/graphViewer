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
    public class Polygons
    {
        WFCanvas.WFCanvasContext context;
        List<Polygon> polygons;

        public Polygons(WFCanvas.WFCanvasContext _context)
        {
            polygons = new List<Polygon>();
            context = _context;
        }

        public int addPolygon(Polygon polygon)
        {
            polygons.Add(polygon);
            return polygons.Count - 1;
        }

        public int addPolygon(List<PointF> shape)
        {
            return addPolygon(new Polygon(shape));
        }

        public int addPolygon(List<MutablePoint> shape)
        {
            return addPolygon(new Polygon(shape));
        }

        public int addPolygon(List<PointF> shape, Color color)
        {
            return addPolygon(new Polygon(shape, color));
        }

        public int addPolygon(List<MutablePoint> shape, Color color)
        {
            return addPolygon(new Polygon(shape, color));
        }

        public void draw()
        {
            foreach(Polygon polygon in polygons)
            {
                List<PointF> coords = translateListOfPoints(polygon.Shape);
                context.graph.DrawPolygon(new Pen(polygon.Color==Color.Transparent?Color.Black:polygon.Color), coords.ToArray());
                context.graph.FillPolygon(new SolidBrush(polygon.Color), coords.ToArray());
            }
        }

        public void clear()
        {
            polygons.Clear();
        }

        List<PointF> translateListOfPoints(List<PointF> relatedPoints)
        {
            List<PointF> absoluteCoords = new List<PointF>();

            foreach(PointF relatedPoint in relatedPoints)
            {
                absoluteCoords.Add(context.translatePointToCanvasCoords(relatedPoint));
            }

            return absoluteCoords;
        }
    }
}
