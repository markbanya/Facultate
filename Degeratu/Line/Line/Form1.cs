using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Line
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap b;
        Graphics g;
        private void Form1_Load(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            g = Graphics.FromImage(b);

            Line(50, 50, 200, 100, Color.Red);
            Line(150,100, 200, 100, Color.Black);
            Line(80, 120, 200, 100, Color.Green);
            Line(50, 180, 300, 200, Color.Blue);
            
            pictureBox1.Image = b;
        }
        public void Line (int x0, int y0 ,int x1, int y1, Color color)
        {
            int x;
            float dx, dy, y, m;
            dy = y1 - y0;
            dx = x1 - y0;
            m = dy / dx;
            y = y0;
            for ( x = x0 ; x < x1; x++)
            {
                b.SetPixel(x,(int)(y +0.5),color);
                b.SetPixel(x, (int)(y), color);
                //b.SetPixel(x, (int)(y + 10), color);
                y += m;
            }
        }
    }
}
