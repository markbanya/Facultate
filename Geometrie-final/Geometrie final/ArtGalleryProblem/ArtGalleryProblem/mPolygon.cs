using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ArtGalleryProblem
{
    public enum VertexType
    {
        ErrorPoint,
        ConvexPoint,
        ConcavePoint
    }
    public enum PolygonDirection
    {
        Unknown,
        Clockwise,
        Count_Clockwise
    }

    class mPolygon
    {
        #region members , constructor
        private Point[] vertices; 

        public mPolygon(Point[] points) 
        {
            if (points.Length < 3) 
                return;

            vertices = new Point[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                vertices[i] = points[i];
            }
        }
        #endregion

        #region misc. functions
        public override string ToString() 
        {
            return "{" + vertices[0] + "," + vertices[1] + "," + vertices[2];
        }
        #endregion

        #region geometric functions

        public Boolean is_vertex(Point p) 
        {
            if (vertex_index(p) != -1)
                return true;
            else
                return false;
        }

        public int vertex_index(Point p) 
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                if (vertices[i] == p)
                {
                    return i;
                }
            }
            return -1;
        }

        public VertexType vertex_type(Point p) 
        {
            if (is_vertex(p)) 
            {
                Point curr_point = p;   
                Point next_point = get_next_point(p); 
                Point prev_point = get_prev_point(p); 

                Double area = PolygonArea(new Point[] { prev_point, curr_point, next_point }); 

                if (area < 0)                       
                    return VertexType.ConvexPoint;
                else if (area > 0)                  
                    return VertexType.ConcavePoint;
            }

            return VertexType.ErrorPoint; 
        }

        public Point get_prev_point(Point p) 
        {
            int v_index;
            v_index = vertex_index(p);      
            if (v_index == -1)              
                return new Point(-1, -1);  
            else            
            {
                if (v_index == 0)                          
                    return vertices[vertices.Length - 1];   
                else
                    return vertices[v_index - 1];           
            }
        }

        public Point get_next_point(Point p)
        {
            int v_index;
            v_index = vertex_index(p);
            if (v_index == -1)
                return new Point(-1, -1); 
            else
            {
                if (v_index == vertices.Length - 1)         
                    return vertices[0];                     
                else
                    return vertices[v_index + 1];           
            }
        }

        public static double PolygonArea(Point[] points)    
        {
            double area = 0;
            int j;

            for (int i = 0; i < points.Length; i++)
            {
                j = (i + 1) % points.Length;
                area += (points[i].X * points[j].Y);
                area -= (points[i].Y * points[j].X);
            }

            area /= 2;
            return area;
        }

        public static PolygonDirection get_direction(Point[] points) 
        {
            if (points.Length < 3)
                return PolygonDirection.Unknown;    

            int len = points.Length;
            int j, k, count = 0;

            for (int i = 0; i < len; i++)   
            {
                
                j = (i + 1) % len;  
                k = (i + 2) % len;  

                
                double cross_product = (points[j].X - points[i].X) * (points[k].Y - points[j].Y);
                cross_product = cross_product - ((points[j].Y - points[i].Y) * (points[k].X - points[j].X));

                if (cross_product > 0)  
                    count++;             
                else
                    count--;            
            }

            if (count < 0)             
                return PolygonDirection.Count_Clockwise;    
            else if (count > 0)         
                return PolygonDirection.Clockwise;         
            else 
                return PolygonDirection.Unknown; 
        }

        public static void reverse_direction(ref Point[] points)  
        {
            int lenght = points.Length;
            Point[] tmp = new Point[lenght];    

            for (int i = 0; i < lenght; i++)   
                tmp[i] = points[i];

            for (int i = 0; i < lenght; i++)    
                points[i] = tmp[lenght - i - 1];
        }

        #endregion
    }
}
