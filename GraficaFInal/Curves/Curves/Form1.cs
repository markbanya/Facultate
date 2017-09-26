using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Curves
{
    public partial class Form1 : Form
    {
        private List<double> ptList = new List<double>();
        private BezierCurve bc = new BezierCurve();

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ptList.Add(e.X);
            ptList.Add(e.Y);

            g.DrawRectangle(px, new Rectangle(e.X, e.Y, 1, 1));
            
        }

        Pen px = new Pen(Brushes.Red);
        Pen newpx = new Pen(Brushes.Magenta);
        Graphics g;
        private void button1_Click(object sender, EventArgs e)
        {
            // how many points do you need on the curve?
            const int POINTS_ON_CURVE = 1000;

            double[] ptind = new double[ptList.Count];
            double[] p = new double[POINTS_ON_CURVE];
            ptList.CopyTo(ptind, 0);

            bc.Bezier2D(ptind, (POINTS_ON_CURVE) / 2, p);

            //pictureBox1.Refresh();
            // draw points
            for (int i = 1; i != POINTS_ON_CURVE-1; i += 2)
            {
                g.DrawRectangle(newpx, new Rectangle((int)p[i + 1], (int)p[i], 1, 1));
                g.Flush();
                Application.DoEvents();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = Graphics.FromHwnd(pictureBox1.Handle);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}