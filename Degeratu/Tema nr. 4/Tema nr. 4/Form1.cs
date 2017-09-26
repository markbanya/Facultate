using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema_nr._4
{
    public partial class Form1 : Form
    {
        public Graphics g;
        public Bitmap b;

        public Form1()
        {
            InitializeComponent();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //minge de volei
            int r = 38 * 4;

            for (int i = 0; i <= r; i++) 
            {
                DrawBall(200, 200, r - i, Color.Orchid);
            }
            pictureBox1.Image = b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //minge de tenis de camp
            int r = 38 * 2;

            for (int i = 0; i <= r; i++)
            {
                DrawBall(200 + (38 * 6), 200 + (38 * 2), r - i, Color.GreenYellow);
            }

            pictureBox1.Image = b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //minge de tenis de masa
            int r = 38;

            for (int i = 0; i <= r; i++)
            {
                DrawBall(200 + (38 * 9), 200 + (38 * 3), r - i, Color.Yellow);
            }

            pictureBox1.Image = b;
        }

        public void DrawBall(int x, int y, int r, Color c)
        {
            int A = 0;
            int B = r;
            int d = 1 - r;
            DrawPoints(x, y, A, B, c);
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
                DrawPoints(x, y, A, B, c);
            }
        }

        public void DrawPoints(int x, int y, int A, int B, Color c)
        {
            b.SetPixel(x + A, y + B, c);
            b.SetPixel(x - A, y + B, c);
            b.SetPixel(x - A, y - B, c);
            b.SetPixel(x + A, y - B, c);
            b.SetPixel(x + B, y + A, c);
            b.SetPixel(x - B, y + A, c);
            b.SetPixel(x - B, y - A, c);
            b.SetPixel(x + B, y - A, c);
        }
    }
}
