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
    public delegate void WFCanvasEventDelegate(object sender, MouseEventArgs e);
    public partial class WFCanvas
    {
        public event WFCanvasEventDelegate onClick;
        public event WFCanvasEventDelegate onMouseMove;
        public class WFCanvasContext
        {
            WFCanvas ContextProvider;
            public int h { get { return ContextProvider.h; } }
            public int w { get { return ContextProvider.w; } }
            public int scale { get { return ContextProvider.scale; } }
            public Graphics graph { get { return ContextProvider.graph; } }
            public PointF center { get { return ContextProvider.center; } }

            public PictureBox field { get { return ContextProvider.field; } }

            public bool isMousePressed { get { return ContextProvider.isMousePressed; } }

            public bool onMouse { get { return ContextProvider.childControleMouse; } set { ContextProvider.childControleMouse = value; } }
            public bool mouseRestricted { get { return ContextProvider.restrintChildControleMouse; } }

            public Point prevMousePosition { get { return ContextProvider.prev; } }

            public PointF translatePointToCanvasCoords(PointF relatedCoords)
            {
                return ContextProvider.translateRelatedCoordsToCurrentCenter(relatedCoords);
            }

            public WFCanvasContext(WFCanvas _ContextProvider)
            {
                ContextProvider = _ContextProvider;
            }
        }

        int h, w, scale;
        bool noAxis = true, isMousePressed=false, scalable, childControleMouse, restrintChildControleMouse;
        PointF center, baseCenter;
        PictureBox field;
        Bitmap img;
        Graphics graph;

        public int minScale = 1, maxScale = 9999999;
        public Curves Curves;
        public Lines Lines;
        public Circles Circles;
        public Texts Texts;
        public Polygons Polygons;

        private void init()
        {
            //img?.Dispose();
            //graph?.Dispose();
            img = new Bitmap(w, h);
            graph = Graphics.FromImage(img);
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        public WFCanvas(PictureBox _field, bool _scalable=true)
        {
            h = _field.Height;
            w = _field.Width;

            field = _field;
            center = new PointF(w / 2.0f, h / 2.0f);
            baseCenter = new PointF(w / 2.0f, h / 2.0f);
            childControleMouse = false;
            restrintChildControleMouse = false;

            scale = 15;
            scalable = _scalable;

            init();

            WFCanvasContext context = new WFCanvasContext(this);

            Curves = new Curves(context);
            Lines = new Lines(context);
            Circles = new Circles(context);
            Texts = new Texts(context);
            Polygons = new Polygons(context);

            field.MouseHover += onFieldHover;
            field.MouseDown += onFieldMouseDown;
            field.MouseUp += onFieldMouseUp;
            field.MouseMove += onFieldMouseMove;
            field.MouseWheel += onFieldWheel;
            field.SizeChanged += onSizeChanged;

            render();
        }

        private void onSizeChanged(object sender, EventArgs e)
        {
            Console.WriteLine("size changed");
            h = field.Height;
            w = field.Width;

            //center = new PointF(w / 2.0f, h / 2.0f);
            baseCenter = new PointF(w / 2.0f, h / 2.0f);
            init();
            render();
        }

        public void setScale(int value)
        {
            scale = value < minScale ? minScale : value;
            scale = scale > maxScale ? maxScale : scale;
            //scale = 1;
            render();
        }

        private void drawAxis()
        {
            graph.DrawLine(new Pen(Color.Black), 0, center.Y, w, center.Y); //OX
            graph.DrawLine(new Pen(Color.Black), center.X, 0, center.X, w); //OY
        }


        public void render()
        {
            clear();
            if (!noAxis) drawAxis();

            Curves.draw();
            Lines.draw();
            Circles.draw();
            Texts.draw();
            Polygons.draw();

            field.Refresh();
        }

        public void clear()
        {
            graph.Clear(Color.Transparent);
            field.Image = img;
            
        }

        public void reset()
        {
            
            clear();
            Curves.clear();
            Lines.clear();
            Circles.clear();
            Texts.clear();
            Polygons.clear();
        }

        public void resetCenter()
        {
            center = new PointF(w / 2.0f, h / 2.0f);
        }

        public void setCenter(PointF newCenter)
        {
            center = translateRelatedCoords(newCenter);
        }
        public PointF getCurrentCenterCoords(bool noScale=false)
        {
            int _scale = noScale ? 1 : scale;
            return new PointF((baseCenter.X-center.X)/_scale, -(baseCenter.Y- center.Y)/_scale);
        }

        public PointF translateCoords(PointF PictureBoxCoords)
        {
            return new PointF((PictureBoxCoords.X - center.X) / scale, -(PictureBoxCoords.Y - center.Y) / scale);
        }

        public PointF translateRelatedCoords(PointF relatedCoords, int? _customScale = null)
        {
            int customScale = _customScale ?? scale;
            return new PointF((-relatedCoords.X * customScale + baseCenter.X), (baseCenter.Y + relatedCoords.Y * customScale));
        }

        public PointF _translateRelatedCoords(PointF relatedCoords, int? _customScale = null)
        {
            int customScale = _customScale ?? scale;
            return new PointF((relatedCoords.X * customScale + baseCenter.X), (baseCenter.Y - relatedCoords.Y * customScale));
        }

        public PointF translateRelatedCoordsToCurrentCenter(PointF relatedCoords, int? _customScale = null)
        {
            int customScale = _customScale ?? scale;
            PointF e = baseCenter;
            PointF delta = new PointF((center.X - e.X) / scale, (center.Y - e.Y) / scale);
            if (customScale < scale) { delta.X = -delta.X; delta.Y = -delta.Y; }
            PointF _center = new PointF(center.X + Math.Abs(customScale - scale) * delta.X, center.Y + Math.Abs(customScale - scale) * delta.Y);
            return new PointF((relatedCoords.X * customScale + _center.X), (_center.Y - relatedCoords.Y * customScale));
        }

        public void setScaleWithCorrection(int value)
        {
            PointF e = baseCenter;
            PointF delta = new PointF((center.X - e.X) / scale, (center.Y - e.Y) / scale);
            if (value < scale) { delta.X = -delta.X; delta.Y = -delta.Y; }
            center = new PointF(center.X + Math.Abs(value-scale)*delta.X, center.Y + Math.Abs(value - scale) * delta.Y);
            scale = value < minScale ? minScale : value;
            scale = scale > maxScale ? maxScale : scale;
 
            render();
        }


        public int W { get { return w; } }
        public int H { get { return h; } }

        public Bitmap GetBitmap { get { return img; } }

    }
}
