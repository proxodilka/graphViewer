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
    
    public class WFCanvas
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
        bool noAxis = true;
        PointF center;
        PictureBox field;
        Bitmap img;
        Graphics graph;

        public Curves Curves;
        public Lines Lines;
        public Circles Circles;
        public Texts Texts;
        
        public WFCanvas(PictureBox _field)
        {
            h = _field.Height;
            w = _field.Width;

            field = _field;
            center = new PointF(w / 2.0f, h / 2.0f);

            scale = 15;

            img = new Bitmap(w, h);
            graph = Graphics.FromImage(img);

            WFCanvasContext context = new WFCanvasContext(this);

            Curves = new Curves(context);
            Lines = new Lines(context);
            Circles = new Circles(context);
            Texts = new Texts(context);

            render();
        }

        public void setScale(int value)
        {
            scale = value;
            render();
        }

        private void drawAxis()
        {
            graph.DrawLine(new Pen(Color.Black), 0, center.Y, center.X * 2, center.Y); //OX
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
            
            field.Image = img;
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
        }
    }
}
