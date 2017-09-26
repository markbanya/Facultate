using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acoperire_complexe_in_plan
{
    public partial class Form1 : Form
    {
        public Graphics G;
        public List<Point> PuncteInPlan;// toate varfurile
        public int n;// numarul punctelor
        public List<Point> PuncteExtreme;
        





        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            G = this.CreateGraphics();
            PuncteInPlan = new List<Point>(n);
            PuncteExtreme = new List<Point>(n+1);
            label1.Text = "Numar de varfuri extreme:";
            button3.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = false;
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            button2.Enabled = true;
            button1.Enabled = false;
            Pen pen = new Pen(Color.Black, 5);
            Random rng = new Random();
          
            for (int i = 0; i < n ; i++)
            {
                int x = rng.Next(50, 600);
                int y = rng.Next(100, 300);
                Point punct = new Point(x, y);
                PuncteInPlan.Add(punct);
            }
            for (int i = 0; i < n; i++)
            {
                G.DrawEllipse(pen, PuncteInPlan[i].X, PuncteInPlan[i].Y, 3, 3);
                


            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;
            button3.Enabled = false;
            Pen pen1 = new Pen(Color.White, 5);
            for (int i = 0; i < n; i++)
            {
                G.DrawRectangle(pen1, PuncteInPlan[i].X, PuncteInPlan[i].Y, 3, 3);
                
            }
            PuncteInPlan.Clear();
            PuncteExtreme.Clear();
            Invalidate();
            
            label1.Text = "Numar de varfuri extreme:";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = true;
            Point pctMaxim;
            pctMaxim = new Point(661, 0);
            pctMaxim = PuncteInPlan.Where<Point>(p => p.Y == PuncteInPlan.Max(max => max.Y)).First();
            Pen pen2 = new Pen(Color.Red, 5);
            //PuncteExtreme.Add(pctMaxim);
            Point PunctFinal;
            do
            {
                PuncteExtreme.Add(pctMaxim);
                PunctFinal = PuncteInPlan[0];
                for (int i = 1; i < PuncteInPlan.Count; i++)
                {
                    if ((pctMaxim == PunctFinal) || (Orientare(pctMaxim, PunctFinal, PuncteInPlan[i]) == -1))
                    {
                        PunctFinal = PuncteInPlan[i];
                    }
                }
                pctMaxim = PunctFinal;
            } while (PunctFinal != PuncteExtreme[0]);
            Pen pen = new Pen(Color.Red, 3);
            int pct = PuncteExtreme.Count;
            for (int i = 0; i < PuncteExtreme.Count-1; i++)
            {
                G.DrawLine(pen, PuncteExtreme[i].X, PuncteExtreme[i].Y,PuncteExtreme[i+1].X,PuncteExtreme[i+1].Y);

            }
            G.DrawRectangle(pen2, PuncteExtreme[0].X, PuncteExtreme[0].Y, 3, 3);
            G.DrawLine(pen, PuncteExtreme[0].X, PuncteExtreme[0].Y, PuncteExtreme[pct-1].X, PuncteExtreme[pct-1].Y);
            label1.Text = label1.Text + pct.ToString();
        }

        public static int Orientare(Point pctMaxim, Point punctFinal, Point point)
        {
            int orientare = (punctFinal.X - pctMaxim.X) * (point.Y - pctMaxim.Y) - (point.X - pctMaxim.X) * (punctFinal.Y - pctMaxim.Y);
            if (orientare > 0)
            {
                return -1;//Orientarea se face spre stanga;
            }
            else
            {
                return 1;//Orientarea se face spre dreapta;
            }
            //return 0;//Orientarea este colineara;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                n = int.Parse(textBox1.Text);
                button1.Enabled = true;
            }
        }
    }
}
