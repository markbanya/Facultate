using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _4.TriangularePoligonMonoton
{
    public class Triangle : Polygon
    {
        public Triangle(PointF p0, PointF p1, PointF p2)
        {
            Points = new PointF[] { p0, p1, p2 };
        }
    }
}
