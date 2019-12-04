using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace matrixComponent
{
    public delegate void MatrixEventListener(object sender, EventArgs e);
    public partial class Matrix : Panel
    {
        public event MatrixEventListener onMatrixChanged;

        Panel matrixRoot;
        List<List<TextBox>> textBoxesMatrix;
        List<string> titles;
        int margin = 10;
        int n, m;

        public Matrix(int n, int m)
        {
            InitializeComponent();
            this.n = n;
            this.m = m;
            textBoxesMatrix = new List<List<TextBox>>();
            matrixRoot = new Panel() { AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
            this.Controls.Add(matrixRoot);
            this.AutoSize = true;
            this.BackColor = Color.Transparent;
            titles = new List<string>();
            createMatrix(n, m);
            fillMatrix(true);
            render();
        }

        public Matrix(double [,] matrix) : this(matrix.GetLength(0), matrix.GetLength(1))
        {
            fillMatrix(matrix);
            render();
        }

        public Matrix(double[,] matrix, List<string> titles) : this(matrix)
        {
            this.titles = titles;
            render();
        }

        public double[,] getMatrix()
        {
            double[,] ans = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ans[i, j] = double.Parse(textBoxesMatrix[i][j].Text, CultureInfo.CreateSpecificCulture("en-us"));
                }
            }

            return ans;
        }

        TextBox createTextBox()
        {
            TextBox textBox = new TextBox();
            textBox.TextChanged += onTextChange;
            textBox.Leave += (object sender, EventArgs e) => { onMatrixChanged?.Invoke(this, new EventArgs()); };
            return textBox;
        }

        void createMatrix(int n, int m)
        {
            textBoxesMatrix.Clear();
            this.n = n;
            this.m = m;
            for (int i = 0; i < n; i++)
            {
                List<TextBox> row = new List<TextBox>();
                for (int j = 0; j < m; j++)
                {
                    row.Add(createTextBox());
                }
                textBoxesMatrix.Add(row);
            }
        }

        public void setMatrix(double[,] matrix, bool withoutRender = false)
        {
            createMatrix(matrix.GetLength(0), matrix.GetLength(1));
            fillMatrix(matrix);
            if (!withoutRender) render();
        }

        public void setMatrix(double[,] matrix, List<string> titles)
        {
            setMatrix(matrix, true);
            this.titles = titles;
            render();
        }

        void fillMatrix(double[,] matrix)
        {
            titles.Clear();
            for (int i = 0; i < n; i++)
            {
                titles.Add((i + 1).ToString());
                for (int j = 0; j < m; j++)
                {
                    textBoxesMatrix[i][j].Text = matrix[i, j].ToString();
                }
            }
        }

        void fillMatrix(bool isEmpty = false)
        {
            titles.Clear();
            for (int i = 0; i < n; i++)
            {
                titles.Add((i + 1).ToString());
                for (int j = 0; j < m; j++)
                {
                    textBoxesMatrix[i][j].Text = "0";
                }
            }
        }

        public void increase()
        {
            foreach (List<TextBox> textBoxes in textBoxesMatrix)
            {
                TextBox textBox = createTextBox();
                textBox.Text = "0";
                textBoxes.Add(textBox);
            }
            n++; m++;
            List<TextBox> newRow = new List<TextBox>();
            for (int i = 0; i < m; i++)
            {
                TextBox textBox = createTextBox();
                textBox.Text = "0";
                newRow.Add(textBox);
            }
            textBoxesMatrix.Add(newRow);
            render();
            onMatrixChanged?.Invoke(this, new EventArgs());
        }

        public void decrease()
        {
            if (!(n != 0 && m != 0))
                return;
            foreach (List<TextBox> textBoxes in textBoxesMatrix)
            {
                textBoxes.RemoveAt(textBoxes.Count - 1);
            }
            textBoxesMatrix.RemoveAt(textBoxesMatrix.Count - 1);
            n--; m--;
            render();
            onMatrixChanged?.Invoke(this, new EventArgs());
        }

        void clear()
        {
            matrixRoot.Controls.Clear();
            matrixRoot.Refresh();
        }
        public void render()
        {
            Point point = new Point(margin, margin);
            TextBox SampleTextBox = new TextBox();
            Label SampleLabel = new Label();
            matrixRoot.Location = new Point(0, 0);
            matrixRoot.Width = (margin + 2 + SampleTextBox.Width) * m;
            matrixRoot.Height = (margin + 2 + SampleTextBox.Height) * n;
            matrixRoot.Controls.Clear();

            point.X += SampleLabel.Width / 2;
            for (int j = 0; j < m; j++)
            {
                Label label = new Label() { Text = titles[j], Location = point };
                matrixRoot.Controls.Add(label);
                point.X += margin + SampleTextBox.Width;
            }
            point.X = margin;
            point.Y += SampleTextBox.Height;

            for (int i = 0; i < n; i++)
            {
                Label label = new Label() { Text = titles[i], Location = point };
                matrixRoot.Controls.Add(label);
                point.X += 2 * margin;
                for (int j = 0; j < m; j++)
                {
                    textBoxesMatrix[i][j].Location = point;

                    matrixRoot.Controls.Add(textBoxesMatrix[i][j]);
                    textBoxesMatrix[i][j].BringToFront();
                    point.X += margin + textBoxesMatrix[i][j].Width;
                }
                point.Y += margin + SampleTextBox.Height;
                point.X = margin;
            }
            matrixRoot.Visible = true;
            this.Visible = true;
            matrixRoot.Refresh();
            this.Refresh();
        }

        void handleInput(TextBox textBox)
        {
            int currentCursorPosition = textBox.SelectionStart;
            textBox.Text = textBox.Text.Replace(',', '.');

            Regex mask = new Regex(@"[^\d-.]"); //все символы, которые не цифра и не '-'
            textBox.Text = mask.Replace(textBox.Text, ""); //удаляем все символы, подходящие под маску

            textBox.SelectionStart = currentCursorPosition;
            textBox.SelectionLength = 0;
        }
        void onTextChange(object sender, EventArgs e)
        {
            handleInput((sender as TextBox));
            //onMatrixChanged?.Invoke(this, new EventArgs());
        }
    }
}
