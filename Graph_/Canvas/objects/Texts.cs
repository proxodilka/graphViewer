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
    public class Texts
    {
        WFCanvas.WFCanvasContext context;
        private List<Tuple<string, float, float>> texts;

        public Texts(WFCanvas.WFCanvasContext context)
        {
            this.context = context;
            this.texts = new List<Tuple<string, float, float>>();
        }

        public int addText(string text, float x = 0, float y = 0)
        {
            texts.Add(new Tuple<string, float, float>(text, x, y));
            return texts.Count() - 1;
        }

        public void draw()
        {
            foreach (Tuple<string, float, float> _text in texts)
            {
                int fontSize = 1 * context.scale;

                string text = _text.Item1;
                float x = _text.Item2 * context.scale + context.center.X;
                float y = context.center.Y - _text.Item3 * context.scale;

                Rectangle textArea = new Rectangle((int)x - fontSize * text.Length / 2, (int)y - fontSize / 2, fontSize * text.Length, fontSize);

                StringFormat alignCenter = new StringFormat();
                alignCenter.Alignment = StringAlignment.Center;
                alignCenter.LineAlignment = StringAlignment.Center;

                Font font = new Font("arial", fontSize, GraphicsUnit.Pixel);

                context.graph.DrawString(text, font, Brushes.Black, textArea, alignCenter);

                //DEBUG: graph.DrawRectangle(new Pen(Color.Red), textArea);
            }
        }

        public void clear()
        {
            texts.Clear();
        }
    }
}
