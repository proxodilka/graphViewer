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
    
    public partial class WFCanvas
    {

        public class WFCanvasContext
        {
            WFCanvas ContextProvider;
            public int h { get { return ContextProvider.h; } }
            public int w { get { return ContextProvider.w; } }
            public int scale { get { return ContextProvider.scale; } }
            public Graphics graph { get { return ContextProvider.graph; } }
            public PointF center { get { return ContextProvider.center; } }

            public WFCanvasContext(WFCanvas _ContextProvider)
            {
                ContextProvider = _ContextProvider;
            }
        }

        int h, w, scale;
        bool noAxis = true, isMousePressed=false, scalable;
        PointF center, baseCenter;
        PictureBox field;
        Bitmap img;
        Graphics graph;

        public int minScale = 1, maxScale = 9999999;
        public Curves Curves;
        public Lines Lines;
        public Circles Circles;
        public Texts Texts;
        
        private void init()
        {
            img?.Dispose();
            graph?.Dispose();
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

            scale = 15;
            scalable = _scalable;

            init();


            field.MouseHover += onFieldHover;
            field.MouseDown += onFieldMouseDown;
            field.MouseUp += onFieldMouseUp;
            field.MouseMove += onFieldMouseMove;
            field.MouseWheel += onFieldWheel;

            WFCanvasContext context = new WFCanvasContext(this);

            Curves = new Curves(context);
            Lines = new Lines(context);
            Circles = new Circles(context);
            Texts = new Texts(context);

            render();
        }

        public void setScale(int value)
        {
            scale = value < minScale ? minScale : value;
            scale = scale > maxScale ? maxScale : scale;
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
            //graph.Dispose();
            //field.Dispose();
            //img.Dispose();
            if (!noAxis) drawAxis();

            Curves.draw();
            Lines.draw();
            Circles.draw();
            Texts.draw();

            //field.Image = img;
            field.Refresh();
        }

        public void clear()
        {
            //init();
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
        }

        public void resetCenter()
        {
            center = new PointF(w / 2.0f, h / 2.0f);
        }

        

        
    }
}
