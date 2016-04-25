using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{    
    class Node
    {        
        private Point Vertex1;
        private Point vertex2;
        private Point vertex3;
        private Point vertex4;
        private Point center;
        public bool isVisited;    
        public Point Center { get { return center; } set { center = value; } }
        public String NodeName { set; get; }
        public List<Node> InNodes { get; set; }
        public List<Node> OutNodes { get; set; }
        public bool IsRoot { get; set; }
        public bool IsSink { get; set; }

        public Node(Point center)
        {
            InNodes = new List<Node>();
            OutNodes = new List<Node>();
            this.Center = center;
            Vertex1 = new Point(Center.X - 5, Center.Y);
            vertex2 = new Point(Center.X , Center.Y - 5);
            vertex3 = new Point(Center.X + 5, Center.Y);
            vertex4 = new Point(Center.X, Center.Y + 5);
        }

        public void Draw(Graphics g)
        {
            if (IsRoot)
            {
                g.FillEllipse(Brushes.DarkGreen, Vertex1.X, vertex2.Y, 10, 10);
            }
            else if(IsSink)
            {
                g.FillEllipse(Brushes.DarkRed, Vertex1.X, vertex2.Y, 10, 10);
            }
            g.DrawEllipse(Pens.Black, Vertex1.X, vertex2.Y, 10, 10);
            if (NodeName != null)
            {
                g.DrawString(NodeName, new Font(new FontFamily("arial"), 10), Brushes.Black, vertex4.X - 2, vertex4.Y + 10);
            }
            
  
        }

        public bool Contain(Point x)
        {
            double distance = Math.Sqrt(Math.Pow(x.X - vertex2.X, 2) + Math.Pow(x.Y - Vertex1.Y, 2));
            return (distance < (vertex2.X - Vertex1.X));
        }

        public void Drag(Point prevPoint, Point lastPoint)
        {
            if (prevPoint == null || lastPoint == null) return;
            int dx = lastPoint.X - prevPoint.X;
            int dy = lastPoint.Y - prevPoint.Y;
            Vertex1.X += dx;
            vertex2.X += dx;
            vertex3.X += dx;
            vertex4.X += dx;
            Vertex1.Y += dy;
            vertex2.Y += dy;
            vertex3.Y += dy;
            vertex4.Y += dy;
            center.X += dx;
            center.Y += dy;
        }

        public void Update(Node x)
        {
            if (InNodes.Contains(x)) InNodes.Remove(x);
            if (OutNodes.Contains(x)) OutNodes.Remove(x);
        }

    }
}
