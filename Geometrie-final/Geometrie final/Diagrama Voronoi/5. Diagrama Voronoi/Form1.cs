using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSPoint = System.Drawing.Point;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace _5.Diagrama_Voronoi
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Bitmap background;
        Graphics g;
        Random seeder;
        Voronoi voroObject;
        static int siteCount = 20;

        public Form1()
        {
            InitializeComponent();
            seeder = new Random();
            pictureBox1.AutoSize = true;
            bitmap = new Bitmap(570, 370);

            background = new Bitmap(570, 370);
            Graphics g2 = Graphics.FromImage(background);
            g2.Clear(Color.White);
            g2 = null;

            g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.White);
            pictureBox1.Image = bitmap;
            this.AutoSize = true;

            voroObject = new Voronoi(0.1);
        }

        void spreadPoints()
        {
            g.Clear(Color.White);

            List<PointF> sites = new List<PointF>();
            int seed = seeder.Next();
            Random rand = new Random(seed);

            for (int i = 0; i < siteCount; i++)
            {
                sites.Add(new PointF((float)(rand.NextDouble() * 570), (float)(rand.NextDouble() * 370)));
            }

            for (int i = 0; i < sites.Count; i++)
            {
                g.FillEllipse(Brushes.Blue, sites[i].X - 1.5f, sites[i].Y - 1.5f, 3, 3);
            }

            List<GraphEdge> ge;
            ge = MakeVoronoiGraph(sites, bitmap.Width, bitmap.Height);

            for (int i = 0; i < ge.Count; i++)
            {
                try
                {
                    CSPoint p1 = new CSPoint((int)ge[i].x1, (int)ge[i].y1);
                    CSPoint p2 = new CSPoint((int)ge[i].x2, (int)ge[i].y2);
                    g.DrawLine(Pens.Black, p1.X, p1.Y, p2.X, p2.Y);
                }
                catch
                {
                    string s = "\nP " + i + ": " + ge[i].x1 + ", " + ge[i].y1 + " || " + ge[i].x2 + ", " + ge[i].y2;
                }
            }
            pictureBox1.Image = bitmap;
        }

        List<GraphEdge> MakeVoronoiGraph(List<PointF> sites, int width, int height)
        {
            double[] xVal = new double[sites.Count];
            double[] yVal = new double[sites.Count];
            for (int i = 0; i < sites.Count; i++)
            {
                xVal[i] = sites[i].X;
                yVal[i] = sites[i].Y;
            }
            return voroObject.generateVoronoi(xVal, yVal, 0, width, 0, height);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            spreadPoints();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            siteCount = (int)(numericUpDown1.Value);
            spreadPoints();
        }
    }
}
