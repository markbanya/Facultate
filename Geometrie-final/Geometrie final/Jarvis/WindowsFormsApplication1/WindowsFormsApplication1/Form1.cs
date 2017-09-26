using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JarvisMarch
{
    //bana, 2008
    //Representation of Jarvis March algorithm implemented in C#
    //Cost: O(nh) ahol n vertex number,h number of vertices of convex hull
    

    public partial class Form1 : Form
    {
        public Graphics G;
        public List<Point> PointList; //all vertices
        const int MaxPointsNumber = 10; //num of points
        int minPoint, maxPoint, currPoint;
        private int[] usedPoints; //the indices of vertices of convex hull from PointList list
        private int n; //number of vertices of convex hull
        List<Point> Lines;
        
  

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Lines = new List<Point>();

            G = this.CreateGraphics();
            PointList = new List<Point>(MaxPointsNumber);
            usedPoints = new int[1000];
            InitializationUsedPoints();
        }

        private void InitializationUsedPoints()
        {
            for (int i = 0; i < 1000; i++)
            {
                usedPoints[i] = -1;
            }
        }

        private void JarvisMarch()
        {
            int maxAngle = 0, minAngle = 0;
            maxPoint = 0;

            for (int k = 0; k < PointList.Count; k++)  // searching max point on Y axis, left marching
            {
                if (PointList[k].Y > PointList[maxPoint].Y)
                    maxPoint = k;
            }
            DrawPoints(maxPoint, -1);

            
            minPoint = 0;

            for (int j = 0; j < PointList.Count; j++) //searching min point on Y axis, left or right marching
            {
                if (PointList[j].Y < PointList[minPoint].Y)
                    minPoint = j;
            }

           addUsedPoint(minPoint); //add point to convex list
           currPoint = minPoint;
           DrawPoints(currPoint,-1);
           Pen myPen;

           while (currPoint != maxPoint) //from min point left marching
           {
               maxAngle = currPoint;
               for (int y = 0; y < MaxPointsNumber; y++) //taking every point
               {
                   myPen = new Pen(System.Drawing.Color.Red, 1);
                   DrawLine(PointList[currPoint], PointList[y], myPen);
                   
                   //checking all point
                   if ((findAngle(PointList[currPoint].X, PointList[currPoint].Y, PointList[maxAngle].X, PointList[maxAngle].Y) < findAngle(PointList[currPoint].X, PointList[currPoint].Y, PointList[y].X, PointList[y].Y) && (notUsed(y) || y == maxPoint)) && (findAngle(PointList[currPoint].X, PointList[currPoint].Y, PointList[y].X, PointList[y].Y) <= 270))
                   {
                       maxAngle = y;
                   }
                   System.Threading.Thread.Sleep(500);
                   

                   myPen = new Pen(System.Drawing.Color.White, 1);
                   DrawLine(PointList[currPoint], PointList[y], myPen);
                   DrawAllPoint();        
               }
               myPen = new Pen(System.Drawing.Color.Red, 2);
               DrawLines(currPoint, maxAngle, myPen);

               currPoint = maxAngle;
               addUsedPoint(currPoint);
           }
               currPoint = minPoint;
               //DEBUG MessageBox.Show("right marching start..");
               while (currPoint != maxPoint) //right convex hull checking
               {
                   minAngle = maxPoint;

                   for (int y = 0; y < MaxPointsNumber; y++) //searching for largest edge
                   {

                       myPen = new Pen(System.Drawing.Color.Red, 1);
                       DrawLine(PointList[currPoint], PointList[y], myPen);

                       if (findAngle(PointList[currPoint].X, PointList[currPoint].Y, PointList[minAngle].X, PointList[minAngle].Y) > findAngle(PointList[currPoint].X, PointList[currPoint].Y, PointList[y].X, PointList[y].Y) && (notUsed(y) || y == maxPoint) && findAngle(PointList[currPoint].X, PointList[currPoint].Y, PointList[y].X, PointList[y].Y) >= 90)
                       {
                           minAngle = y;
                       }

                       System.Threading.Thread.Sleep(500);


                       myPen = new Pen(System.Drawing.Color.White, 1);
                       DrawLine(PointList[currPoint], PointList[y], myPen);
                       DrawAllPoint();
                   }
                   myPen = new Pen(System.Drawing.Color.Red, 2);
                   DrawLines(currPoint, minAngle, myPen);
                   currPoint = minAngle;               
                   addUsedPoint(currPoint); 
               }
        }

        private void DrawLines(int a,int b, Pen myPen)
        {
            DrawLine(PointList[a], PointList[b], myPen);
            Lines.Add(new Point(PointList[a].X,PointList[a].Y));
            Lines.Add(new Point(PointList[b].X, PointList[b].Y));
        }

        private void ClearAllLine()
        {
            Pen P = new Pen(System.Drawing.Color.White, 2);
            for (int i = 0; i < Lines.Count-1; i++)
            {
                G.DrawLine(P, Lines[i], Lines[i + 1]);
            }
        }

        bool notUsed(int y)
        {
            for (int i = 0; i < MaxPointsNumber; i++) //point added yet to convex hull
                if (y == usedPoints[i])
                    return false;

            return true;
        }

        double findAngle(double x1, double y1, double x2, double y2)
        {
            double deltaX = x2 - x1;
            double deltaY = y2 - y1;

            if (deltaX == 0 && deltaY == 0) //same vertex
                return 0;

            double angle = Math.Atan(deltaY / deltaX) * (180.0 / 3.141592);
            
            //0�-360� - which quarter ?
            if (deltaX >= 0 && deltaY >= 0)
                angle = 90 + angle;
            else if (deltaX >= 0 && deltaY < 0)
                angle = 90 + angle;
            else if (deltaX < 0 && deltaY > 0)
                angle = 270 + angle;
            else if (deltaX < 0 && deltaY <= 0)
                angle = 270 + angle;

            return angle;
        }

        void DrawLine(Point a,Point b,Pen myPen)
        {
            G.DrawLine(myPen, a, b);
        }

        void addUsedPoint(int index)
        {
            n++;
            int i = 0;
            while (usedPoints[i] != -1) 
                i++;

            usedPoints[i] = index;
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "RandomPoints")
            {
                RandomPoints();                
                DrawPoints(-1,-1);
                button2.Enabled = true;
                button1.Text = "Clear";
            }
            else if (button1.Text == "Clear")
            {
                ClearDraw();
                PointList.Clear();
                usedPointsClear();
                ClearAllLine();
                button2.Enabled = false;
                button1.Text = "RandomPoints";
                Invalidate();
            }

            
        }

        private void usedPointsClear()
        {
            for (int i = 0; i < MaxPointsNumber; i++)
            {
                usedPoints[i] = -1;
            }
        }
        private void RandomPoints()
        {
            Random random = new Random(); 
            for (int i = 0; i < MaxPointsNumber; i++)
            {
                usedPoints[i] = -1;
                int x = random.Next(50,600);
                int y = random.Next(100,300);
                Point point = new Point(x,y);
                PointList.Add(point);
            }
        }
        private void ClearDraw()
        {
            Pen myPen = new Pen(System.Drawing.Color.White, 3);
            for (int i = 0; i < MaxPointsNumber; i++)
            {
                G.DrawRectangle(myPen, PointList[i].X, PointList[i].Y, 3, 3);
            }
        }

        private void DrawPoints(int index1,int index2)
        {
            if (index1 == -1 && index2 ==-1)
            {
                Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                for (int i = 0; i < MaxPointsNumber; i++)
                {
                    G.DrawRectangle(myPen, PointList[i].X, PointList[i].Y, 3, 3);
                }
            }
            if (index1 != -1 && index2 == -1)
            {
                Pen myPen = new Pen(System.Drawing.Color.Green, 3);
                G.DrawRectangle(myPen, PointList[index1].X, PointList[index1].Y, 3, 3);
            }
        }

        private void DrawAllPoint()
        {
            Pen myPen = new Pen(System.Drawing.Color.Red, 3);
            for (int i = 0; i < MaxPointsNumber; i++)
            {
                G.DrawRectangle(myPen, PointList[i].X, PointList[i].Y, 3, 3);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {            
                button2.Enabled = false;
                button1.Enabled = false;
                JarvisMarch();
                button1.Enabled = true;
        }


    }

}