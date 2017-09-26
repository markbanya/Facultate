using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace ArtGalleryProblem
{
    public enum vertex_color
    {
        Empty=0,
        Red=1,
        Green=2,
        Blue=3
    }

    class mPolygonShape
    {
        #region consturctor, members
        public Point[] input_vertices;       
        private Point[] updated_vertices;    
        ArrayList ears = new ArrayList();    
        public Point[][] polygons;           
        public vertex_color[] vertex_colors; 
        public Boolean[] animated;           

        public System.Windows.Forms.ListBox lb; 
        
        public mPolygonShape(Point[] vertices) 
        {
            if (vertices.Length < 3) 
                return;

            input_vertices = new Point[vertices.Length];       
            vertex_colors = new vertex_color[vertices.Length]; 
            for (int i = 0; i < vertices.Length; i++)
            {
                input_vertices[i] = vertices[i];              
                vertex_colors[i] = vertex_color.Empty;         
            }

            update_vertices();  
        }
        #endregion

        #region vertice processing

        private void update_vertices()  
        {
            updated_vertices = new Point[input_vertices.Length];
            for (int i = 0; i < input_vertices.Length; i++)
                updated_vertices[i] = input_vertices[i];

            if (mPolygon.get_direction(updated_vertices) == PolygonDirection.Clockwise) 
            {
                mPolygon.reverse_direction(ref updated_vertices); 
                mPolygon.reverse_direction(ref input_vertices);
            }
        }

        private void update_vertices(Point p)   
        {                                       
            ArrayList temp_points = new ArrayList();    

            for (int i = 0; i < updated_vertices.Length; i++) 
            {
                if (p == updated_vertices[i])   
                {
                    mPolygon poly = new mPolygon(updated_vertices); 
                    Point curr_point = p;
                    Point next_point = poly.get_next_point(p);  
                    Point prev_point = poly.get_prev_point(p);  

                    Point[] ear = new Point[3]; 
                    ear[0] = prev_point;        
                    ear[1] = curr_point;        
                    ear[2] = next_point;        

                    ears.Add(ear);              
                }
                else                          
                {
                    temp_points.Add(updated_vertices[i]);  
                }
            }

            if ((updated_vertices.Length - temp_points.Count) == 1) 
            {
                updated_vertices = new Point[updated_vertices.Length - 1];  
                for (int i = 0; i < temp_points.Count; i++)
                {
                    updated_vertices[i] = (Point)temp_points[i];    
                }

            }
        }

        #endregion

        #region coloring

        public vertex_color get_color_index(string s) 
        {
            if (s.ToLower() == "red")
                return vertex_color.Red;
            else if (s.ToLower() == "blue")
                return vertex_color.Blue;
            else if (s.ToLower() == "green")
                return vertex_color.Green;
            else return vertex_color.Empty;
        }

        public vertex_color get_minumum_color()  
        {                                       
            int red_count = count_colors(vertex_color.Red);
            int blue_count = count_colors(vertex_color.Blue);
            int green_count = count_colors(vertex_color.Green);

            int min = red_count;
            vertex_color min_color = vertex_color.Red;

            if (blue_count < min)
            {
                min = blue_count;
                min_color = vertex_color.Blue;
            }

            if (green_count < min)
            {
                min = green_count;
                min_color = vertex_color.Green;
            }

            return min_color;
        }

        public int count_colors(vertex_color c) 
        {
            int count = 0;
            for (int i = 0; i < vertex_colors.Length; i++)
            {
                if (vertex_colors[i] == c)
                    count++;
            }

            return count;
        }

        public void traverse() 
        {
            int last_poly = polygons.Length - 1; 
            lb.Items.Add("[p" + last_poly + "] Last Polygon: \t" + polygons[last_poly][0] + polygons[last_poly][1] + polygons[last_poly][2]); 

            
            vertex_colors[get_index(polygons[last_poly][0])] = vertex_color.Red;
            lb.Items.Add("[s" + get_index(polygons[last_poly][0]) + "] Assigned color:\tRed");
            vertex_colors[get_index(polygons[last_poly][1])] = vertex_color.Blue;
            lb.Items.Add("[s" + get_index(polygons[last_poly][1]) + "] Assigned color:\tBlue");
            vertex_colors[get_index(polygons[last_poly][2])] = vertex_color.Green;
            lb.Items.Add("[s" + get_index(polygons[last_poly][2]) + "] Assigned color:\tGreen");

            colorize(0); 
        }

        public void colorize(int i) 
        {
            int next = i + 1;
            if (next < input_vertices.Length) 
            {
                colorize(next);
            }
            lb.Items.Add("[c" + i + "] Colorizing point \t" + i + " " + input_vertices[i]); 
            find_polygons(input_vertices[i]); 
        }

        public void find_polygons(Point p) 
        {
            int v0_index, v1_index, v2_index;

            for (int i = polygons.Length - 1; i > -1; i--) 
            {
                if ((p == polygons[i][0]) || (p == polygons[i][1]) || (p == polygons[i][2])) 
                {
                    lb.Items.Add("[p" + i + "] Polygon: \t\t" + polygons[i][0].ToString() + polygons[i][1].ToString() + polygons[i][2].ToString()); 

                    for (int j = 0; j < 3; j++) 
                    {                           
                        v0_index = get_index(polygons[i][j]);          
                        v1_index = get_index(polygons[i][(j + 1) % 3]); 
                        v2_index = get_index(polygons[i][(j + 2) % 3]); 

                        if (vertex_colors[v0_index] == vertex_color.Empty) 
                        {
                            vertex_colors[v0_index] = find_color(vertex_colors[v1_index], vertex_colors[v2_index]); 
                            lb.Items.Add("[s" + v0_index + "] Assigned color: \t" + str_color(vertex_colors[v0_index]) + " {" + str_color(vertex_colors[v1_index]) + " ," + str_color(vertex_colors[v2_index]) + "} " + polygons[i][j]); // debug message
                        }
                    }

                }
            }
        }

        public string str_color(vertex_color c) 
        {
            string r = "";
            switch (c)
            {
                case vertex_color.Empty:
                    r = "EMPTY";
                    break;
                case vertex_color.Red:
                    r = "RED";
                    break;
                case vertex_color.Green:
                    r = "GREEN";
                    break;
                case vertex_color.Blue:
                    r = "BLUE";
                    break;
                default:
                    break;
            }

            return r;
        }

        public vertex_color find_color(vertex_color c1, vertex_color c2) 
        {
            if (c1 == vertex_color.Red)             
            {
                if (c2 == vertex_color.Blue)        
                    return vertex_color.Green;     

                else if (c2 == vertex_color.Green)  
                    return vertex_color.Blue;       
            }
            else if (c1 == vertex_color.Blue)       
            {
                if (c2 == vertex_color.Red)         
                    return vertex_color.Green;      

                else if (c2 == vertex_color.Green)  
                    return vertex_color.Red;        
            }
            else if (c1 == vertex_color.Green)      
            {       
                if (c2 == vertex_color.Red)         
                    return vertex_color.Blue;       

                else if (c2 == vertex_color.Blue)   
                    return vertex_color.Red;       
            }

            return vertex_color.Empty;              
        }

        public int get_index(Point p) 
        {
            for (int i = 0; i < input_vertices.Length; i++)
            {
                if (p == input_vertices[i])
                    return i;
            }

            return -1;
        }

        #endregion

        #region triangulation

        public void triangulate()   
        {
            mPolygon poly = new mPolygon(updated_vertices); 
            Boolean finished = false; 

            if (updated_vertices.Length == 3) 
                finished = true;

            Point p = new Point();

            while (finished == false)   
            {
                int i = 0;
                Boolean not_found = true;   
                while (not_found && (i < updated_vertices.Length)) 
                {
                    p = updated_vertices[i];    
                    if (is_ear(p))              
                        not_found = false;      
                    else
                        i++;                    
                }

                update_vertices(p);             
                poly = new mPolygon(updated_vertices);  
                if (updated_vertices.Length == 3)   
                    finished = true;               
            }

            
            polygons = new Point[ears.Count + 1][]; 
            for (int i = 0; i < ears.Count; i++)
            {
                Point[] points = (Point[])ears[i];  
                polygons[i] = new Point[3];
                polygons[i][0] = points[0];
                polygons[i][1] = points[1];
                polygons[i][2] = points[2];
            }

            
            polygons[ears.Count] = new Point[updated_vertices.Length]; 
            for (int i = 0; i < updated_vertices.Length; i++)
            {
                polygons[ears.Count][i] = updated_vertices[i];
            }
        }

        private Boolean is_ear(Point p) 
        {
            mPolygon m = new mPolygon(updated_vertices); 

            if (m.is_vertex(p) == true) 
            {
                if (m.vertex_type(p) == VertexType.ConvexPoint) 
                {
                    Point curr_point = p;   
                    Point prev_point = m.get_prev_point(p); 
                    Point next_point = m.get_next_point(p); 

                    for (int i = updated_vertices.GetLowerBound(0); i < updated_vertices.GetUpperBound(0); i++) 
                    {
                        Point pt = updated_vertices[i];
                        if (!(is_points_equal(pt, curr_point) || is_points_equal(pt, prev_point) || is_points_equal(pt, next_point)))
                        {   
                            if (is_point_in_triangle(new Point[] { prev_point, curr_point, next_point }, pt)) 
                                return false;  
                        }
                    }
                }
                else 
                    return false; 

                return true;    
            }
            return false; 
        }

        private Boolean is_point_in_triangle(Point[] triangle, Point p) 
        {
            if (triangle.Length != 3) 
                return false;

            for (int i = triangle.GetLowerBound(0); i < triangle.GetUpperBound(0); i++) 
            {
                if (is_points_equal(p,triangle[i])) 
                    return true;
            }
        
            
            mLineSegment l1 = new mLineSegment(triangle[0], triangle[1]);
            mLineSegment l2 = new mLineSegment(triangle[1], triangle[2]);
            mLineSegment l3 = new mLineSegment(triangle[2], triangle[0]);

            if (is_point_in_line(p, l1) || is_point_in_line(p, l2) || is_point_in_line(p, l3)) 
                return true;

           
            double area0 = mPolygon.PolygonArea(new Point[] { triangle[0], triangle[1], p });
            double area1 = mPolygon.PolygonArea(new Point[] { triangle[1], triangle[2], p });
            double area2 = mPolygon.PolygonArea(new Point[] { triangle[2], triangle[0], p });

            if ((area0 > 0) && (area1 > 0) && (area2 > 0))
                return true;
            else if ((area0 < 0) && (area1 < 0) && (area2 < 0))
                return true;

            
            return false;
        }

        private Boolean is_point_in_line(Point p, mLineSegment line) 
        {
            double Ax, Ay, Bx, By, Cx, Cy;
            Bx = line.end_point.X;
            By = line.end_point.Y;
            Ax = line.start_point.X;
            Ay = line.start_point.Y;
            Cx = p.X;
            Cy = p.Y;

            double line_lenght = line.get_lenght();

            double s = Math.Abs(((Ay - Cy) * (Bx - Ax) - (Ax - Cx) * (By - Ay)) / (line_lenght * line_lenght));

            if (Math.Abs(s - 0) < 0.00001) 
            {
                if (is_points_equal(p, line.start_point) || is_points_equal(p, line.end_point))
                    return true;
                else if ((Cx < line.get_x_max()) && (Cx > line.get_x_min()) && (Cy < line.get_y_max()) && (Cy > line.get_y_min()))
                    return true;
            }

           
            return false;
        }

        public bool is_points_equal(Point p1, Point p2) 
        {
            double dDeff_X = Math.Abs(p1.X - p2.X);
            double dDeff_Y = Math.Abs(p1.Y - p2.Y);

            if ((dDeff_X < 0.00001) && (dDeff_Y < 0.00001)) 
                return true;
            else
                return false;
        }

        #endregion

    }
}
