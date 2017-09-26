using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Graphics g;
        public Bitmap b;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            DrawCircle(300, 210, 152);

            pictureBox1.Image = b;
        }

        public void DrawCircle(int x, int y, int r)
        {
            int A = 0;
            int B = r;
            int d = 1 - r;
            DrawPoints(x, y, A, B);
            while (A < B)
            {
                if (d < 0)
                {
                    d += 2 * A + 2;
                }
                else
                {
                    d += 2 * (A - B) + 5;
                    B--;
                }
                A++;
                DrawPoints(x, y, A, B);
            }
        }

        public void DrawPoints(int x, int y, int A, int B)
        {
            b.SetPixel(x + A, y + B, Color.Green);
            b.SetPixel(x - A, y + B, Color.Orange);
            b.SetPixel(x - A, y - B, Color.SteelBlue);
            b.SetPixel(x + A, y - B, Color.Red);
            b.SetPixel(x + B, y + A, Color.Yellow);
            b.SetPixel(x - B, y + A, Color.Purple);
            b.SetPixel(x - B, y - A, Color.Pink);
            b.SetPixel(x + B, y - A, Color.Blue);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
