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
        private List<Tuple<Color, Tuple<string, float, float>>> texts;

        public Texts(WFCanvas.WFCanvasContext context)
        {
            this.context = context;
            this.texts = new List<Tuple<Color, Tuple<string, float, float>>>();
        }

        public int addText(string text, float x = 0, float y = 0, Color? _color=null)
        {
            Color color = _color ?? Color.Black;
            texts.Add(new Tuple<Color, Tuple<string, float, float>>(color, 
                      new Tuple<string, float, float>(text, x, y)));

            return texts.Count() - 1;
        }

        public void draw()
        {
            foreach (var textProps in texts)
            {
                int fontSize = 1 * context.scale;

                Color color = textProps.Item1;
                var _text = textProps.Item2;

                string text = _text.Item1;
                float x = _text.Item2 * context.scale + context.center.X;
                float y = context.center.Y - _text.Item3 * context.scale;

                Rectangle textArea = new Rectangle((int)x - fontSize * text.Length / 2, (int)y - fontSize / 2, fontSize * text.Length, fontSize);

                StringFormat alignCenter = new StringFormat();
                alignCenter.Alignment = StringAlignment.Center;
                alignCenter.LineAlignment = StringAlignment.Center;

                Font font = new Font("arial", fontSize<=0?0.000001f:fontSize, GraphicsUnit.Pixel);

                context.graph.DrawString(text, font, new SolidBrush(color), textArea, alignCenter);

                //DEBUG: graph.DrawRectangle(new Pen(Color.Red), textArea);
            }
        }

        public void clear()
        {
            texts.Clear();
        }
    }
}
