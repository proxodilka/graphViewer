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
        bool noAxis = false, isMousePressed=false;
        PointF center, baseCenter;
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
            baseCenter = new PointF(w / 2.0f, h / 2.0f);

            scale = 15;

            img = new Bitmap(w, h);
            graph = Graphics.FromImage(img);
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


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
            //graph.Dispose();
            //field.Dispose();
            //img.Dispose();
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

        public void resetCenter()
        {
            center = new PointF(w / 2.0f, h / 2.0f);
        }

        private void onFieldHover(object sender, EventArgs e)
        {
            field.Cursor = Cursors.Hand; 
        }

        Point prev=new Point(0,0);

        private void onFieldMouseMove(object sender, MouseEventArgs e)
        {
            if (isMousePressed)
            {
                //Console.WriteLine($"mouse :{e.Location}");
                //Console.WriteLine($"center :{center}");
                Point cure = e.Location;
                if (!Object.Equals(prev,cure))
                {
                    Point delta = new Point(prev.X - cure.X, prev.Y - cure.Y);
                    //Console.WriteLine($"delta: {delta}");
                    center = new PointF(center.X-delta.X, center.Y-delta.Y);
                    //Console.WriteLine($"center: {center}");
                    render();
                    prev = cure;
                }
                
            }
            else
            {
                prev = e.Location;
            }
        }

        private void onFieldMouseUp(object sender, MouseEventArgs e)
        {
            isMousePressed = false;
        }

        private void onFieldMouseDown(object sender, MouseEventArgs e)
        {
            isMousePressed = true;
            //prev = new Point(0, 0);
        }

        private void onFieldWheel(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"center: {center}");
            Console.WriteLine($"location: {e.Location}");
            PointF delta = new PointF((baseCenter.X - e.X)/scale, (baseCenter.Y - e.Y)/scale);
            Console.WriteLine($"delta: {delta}");

            //
            //center = new PointF(baseCenter.X+baseCenter.X-e.X, baseCenter.Y+baseCenter.Y-e.Y);
            //center = e.Location;
            //center = new PointF(e.X/scale, e.Y/scale);
            if (e.Delta > 0)
            {
                setScale(scale + 1);
                
            }
            else
            {
                setScale(scale - 1);
            } 
            
        }
    }
}
