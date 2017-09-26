using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema_nr._2
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MidpointLine(int x0, int y0, int x1, int y1, Color c)
        {
            int dx = x1 - x0;
            int dy = y1 - y0;
            int d = 2 * dy - dx;
            int incrE = 2 * dy;
            int incrNE = 2 * (dy - dx);
            int x = x0;
            int y = y0;

            b.SetPixel(x, y, c);

            while (x < x1)
            {
                if (d <= 0)
                    d += incrE;
                else
                {
                    d += incrNE;
                    y++;
                }
                x++;
                b.SetPixel(x, y, c);
            }
        }

        private void vertical(int x1, int y1, int x2, int y2, Color c)
        {
            if (x1 == x2)
            {
                int y = Math.Min(y1, y2);
                int x = x1;
                while (y <= Math.Max(y1, y2))
                {
                    b.SetPixel(x, y, c);
                    y += 1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //patrat
            MidpointLine(50, 50, 200, 50, Color.Black);
            vertical(200, 50, 200, 200, Color.Black);
            vertical(50, 50, 50, 200, Color.Black);
            MidpointLine(50, 200, 200, 200, Color.Black);
            pictureBox1.Image = b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dreptunghi
            MidpointLine(300, 50, 550, 50, Color.Blue);
            vertical(550, 50, 550, 200, Color.Blue);
            vertical(300, 50, 300, 200, Color.Blue);
            MidpointLine(300, 200, 550, 200, Color.Blue);
            pictureBox1.Image = b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //triunghi
            MidpointLine(200, 300, 350, 400, Color.Red);
            MidpointLine(200, 300, 500, 400, Color.Red);
            MidpointLine(350, 400, 500, 400, Color.Red);
            pictureBox1.Image = b;
        }
    }
}
