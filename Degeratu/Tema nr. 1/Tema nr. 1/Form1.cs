using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema_nr._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox1.Text); //coordonata x a primului punct
            int y1 = int.Parse(textBox2.Text); //coordonata y a primului punct
            int x2 = int.Parse(textBox3.Text); //coordonata x a celui de-al doilea punct
            int y2 = int.Parse(textBox4.Text); //coordonata y a celui de-al doilea punct
            int p = int.Parse(textBox5.Text); //grosimea liniei
            float dx, dy, x, y, m, n;
            dy = y2 - y1;
            dx = x2 - x1;
            m = dy / dx;
            n = dx / dy;
            y = y1;
            x = x1;

            Bitmap b = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            for (int j = 0; j < p; j++)
            {
                if (x2 > y2)
                {
                    y = y1 + j;
                    for (int i = x1; i <= x2; i++)
                    {
                        b.SetPixel(i, (int)y, Color.Black);
                        y += m;
                    }
                }
                else
                {
                    x = x1 + j;
                    for (int i = y1; i <= y2; i++)
                    {
                        b.SetPixel((int)x, i, Color.Black);
                        x += n;
                    }
                } 
            }

            pictureBox1.Image = b;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
