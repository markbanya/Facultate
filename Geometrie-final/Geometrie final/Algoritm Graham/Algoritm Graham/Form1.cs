using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritm_Graham
{
    public partial class Form1 : Form
    {
        private Boolean signal;
        private List<PointF> mypoints;
        private int count;
        private int index = 0;
        private int[] finalPointArray;// for  write it on a string finalpoints[i]==1 if the point is in the convex hull
        private Graphics g;
        private double[] angle;
        private int[] pointName;
        public Form1()
        {
            InitializeComponent();
            signal = false;
            mypoints = new List<PointF>();
            pointName = new int[1000];

            count = 0;
            g = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
            signal = true;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (signal)
            {
                mypoints.Add(new PointF(e.X, e.Y));

                DrawPointWithText(new PointF(e.X, e.Y), Brushes.White, Pens.Black, true);

                pointName[count] = count + 1;
                count++;

            }
        }
        private void findSmallestY()
        {

            float minY = mypoints[0].Y;
            float minX = mypoints[0].X;
            int indice = 0;
            for (int i = 1; i < count; i++)
            {

                if (minY < mypoints[i].Y)
                {
                    minY = mypoints[i].Y;
                    minX = mypoints[i].X;
                    indice = i;
                }
                else
                {
                    if(minY==mypoints[i].Y&&mypoints[i].X<minX)
                    {
                        minY = mypoints[i].Y;
                        minX = mypoints[i].X;
                        indice = i;
                    }
                }

            }
            index = indice;


        }
        private int Orientation(int m, int n, int i)
        {


            if (((mypoints[n].X - mypoints[m].X) * (mypoints[i].Y - mypoints[m].Y)) - ((mypoints[n].Y - mypoints[m].Y)) * (mypoints[i].X - mypoints[m].X) > 0)
                return 1;
            else
                return -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            signal = false;
            button1.Enabled = false;


            //calculate smallesy Y
            findSmallestY();

            //Generate Angle array

            createAngleArray();

            //Sort angle array
            sortAngleArray();

            //find smallest polygon

            GrahamScan();


            button2.Enabled = false;

            string final = " " + pointName[0];

            for (int i = 1; i < count; i++)
            {
                if (finalPointArray[i] == 1)
                {

                    final = final + " , " + " " + " " + pointName[i] + " ";
                }
            }


            label2.Text = "Punctele infasuratorii convexe sunt:" + " (" + final + " )";
        }
        private void GrahamScan()
        {

            int clockwise = 1;
            int countclockwise = -1;
            int l = 0, m = 1, i = 2;

            finalPointArray = new int[count];
            //take two point
            finalPointArray[l] = 1;
            finalPointArray[m] = 1;
            Pen redPen;
            SolidBrush blueBrush = new SolidBrush(Color.White);

            redPen = new Pen(Color.Red, 2);

            //draw line
            g.DrawLine(redPen, mypoints[0], mypoints[1]);
            foreach (PointF p in mypoints)
            {
                DrawPointWithText(new PointF(p.X, p.Y), Brushes.White, Pens.Black);
            }

            while (true)
            {
                System.Threading.Thread.Sleep(2000);
                //if last point traversed
                if ((Orientation(m, l, i) == clockwise) && (i == count - 1))
                {
                    finalPointArray[i] = 1;
                    redPen = new Pen(Color.Red, 2);

                    g.DrawLine(redPen, mypoints[m], mypoints[i]);
                    DrawAllPoints(mypoints);
                    System.Threading.Thread.Sleep(2000);
                    g.DrawLine(redPen, mypoints[i], mypoints[0]);
                    DrawAllPoints(mypoints);
                    string str = "";
                    for (int j = 0; j < count; j++)
                    {
                        if (finalPointArray[j] == 1)
                        {
                            str = str + "    " + Convert.ToString(j);
                        }
                    }
                    DrawAllPoints(mypoints);
                    redPen = new Pen(Color.White, 2);
                    DrawAllPoints(mypoints);
                    break;
                }


                //three points take left turn then draw two lines
                if (Orientation(m, l, i) == clockwise)
                {
                    label2.Text = ("Intoarcere la stanga intre punctele: ( " + pointName[m] + " , " + pointName[l] + " , " + pointName[i] + "  )");
                    label2.Refresh();
                    redPen = new Pen(Color.Red, 2);

                    g.DrawLine(redPen, mypoints[m], mypoints[i]);
                    DrawAllPoints(mypoints);
                    finalPointArray[i] = 1;
                    l = m;
                    m = i;
                    i++;
                }

                //if three points take right turn then remove the line and middle point and move one step back
                else
                if (Orientation(m, l, i) == countclockwise)
                {

                    label2.Text = ("Intoarcere la dreapta intre punctele: ( " + pointName[m] + " , " + pointName[l] + " , " + pointName[i] + "  )");
                    label2.Refresh();
                    redPen = new Pen(Color.Red, 2);
                    g.DrawLine(redPen, mypoints[m], mypoints[i]);
                    DrawAllPoints(mypoints);
                    System.Threading.Thread.Sleep(2000);
                    redPen = new Pen(Color.White, 2);
                    g.DrawLine(redPen, mypoints[m], mypoints[i]);
                    DrawAllPoints(mypoints);
                    g.DrawString(" " + pointName[m], new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.DarkBlue), new PointF(mypoints[m].X + 5, mypoints[m].Y + 5));
                    g.DrawLine(redPen, mypoints[l], mypoints[m]);
                    DrawAllPoints(mypoints);
                    g.DrawString(" " + pointName[l], new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.DarkBlue), new PointF(mypoints[l].X + 5, mypoints[l].Y + 5));
                    redPen = new Pen(Color.Red, 2);
                    DrawPointWithText(mypoints[m], Brushes.White, Pens.Black);
                    DrawPointWithText(mypoints[l], Brushes.White, Pens.Black);
                    DrawPointWithText(mypoints[i], Brushes.White, Pens.Black);

                    finalPointArray[m] = 0;
                    m = l;
                    l = letestBefore(l);
                }

            }

        }

        private int letestBefore(int l)
        {
            int i = 0;
            for (i = l - 1; i > 0; i--)
            {
                if (finalPointArray[i] == 1)
                    break;
            }
            return i;

        }



        private void sortAngleArray()
        {
            double temp;
            int tmp = 0;
            PointF ptemp = new PointF();

            for (int i = (count - 1); i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (angle[j - 1] > angle[j])
                    {
                        temp = angle[j - 1];
                        angle[j - 1] = angle[j];
                        angle[j] = temp;

                        ptemp = mypoints[j - 1];
                        mypoints[j - 1] = mypoints[j];
                        mypoints[j] = ptemp;

                        tmp = pointName[j - 1];
                        pointName[j - 1] = pointName[j];
                        pointName[j] = tmp;

                    }
                }
            }
        }

        private void createAngleArray()
        {
            angle = new double[count];
            double value;

            for (int i = 0; i < count; i++)
            {
                if (i == index)
                {
                    value = 0;
                }
                else
                {
                    value = PolarAngle(mypoints[i].X - mypoints[index].X, mypoints[index].Y - mypoints[i].Y);
                }

                angle[i] = value;
            }

        }
        public double PolarAngle(double px, double py)
        {
            double angle = 0.0;
            //Calculate the angle
            angle = System.Math.Atan(System.Math.Abs(py) / System.Math.Abs(px));

            // Convert to degrees
            angle = angle * 180 / System.Math.PI;

            if (px < 0)
                angle = 180 - angle;

            return angle;
        }

        private void DrawPointWithText(PointF pt, Brush brush, Pen pen, bool text = false)
        {
            const int raza = 3;
            g.FillEllipse(brush, pt.X - raza, pt.Y - raza, 2 * raza, 2 * raza);
            g.DrawEllipse(pen, pt.X - raza, pt.Y - raza, 2 * raza, 2 * raza);
            if (text)
                g.DrawString(" " + (count + 1), new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.DarkBlue), new PointF(pt.X + 5, pt.Y + 5));
        }
        private void DrawAllPoints(List<PointF> l)
        {
            foreach (PointF item in l)
            {
                DrawPointWithText(item, Brushes.White, Pens.Black);
            }
        }
    }
}
