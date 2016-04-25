using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Shapes;


namespace WindowsFormsApplication1
{
    class Line
    {
        private Node start;
        private Node end;
        private String gain;
        public Node Start { get { return start; } set { start = value; } }
        public Node End { get { return end; } set { end = value;}}
        public String Gain { get { return gain;} set { gain = value; } }
        public Line(Node start, Node end)
        {
            this.start = start;
            this.end = end;
        }

        public void Draw(Graphics g)
        {
            if (start == end)
            {
                /* Point[] points = {
                 new Point(start.Center.X, start.Center.Y),
                     new Point(start.Center.X - 2, start.Center.Y - 1),
                     new Point(start.Center.X - 1, start.Center.Y - 1),
                     new Point(start.Center.X - 1, start.Center.Y - 2),
                     new Point(start.Center.X + 1, start.Center.Y - 2),
                     new Point(start.Center.X + 1, start.Center.Y + 1),
                     new Point(start.Center.X + 2, start.Center.Y + 1) };
                 g.FillPolygon(Brushes.Green, points);*/
                Point textPoint;
                Point third = CalculateBezierePoint(start.Center, end.Center, true, out textPoint);
                Point Control1 = Start.Center;
                Control1.Y -= 35;
                Control1.X += 10;
                Point Control2 = Start.Center;
                Control2.Y -= 35;
                Control2.X -= 10;
                Point temp = end.Center;
                temp.X -= 5;
                textPoint.Y -= 25;
                g.DrawString(this.gain, new Font(new FontFamily("arial"), 10), Brushes.Black, textPoint);
               
                g.DrawBezier(Pens.Blue, start.Center, Control1, Control2, temp);
            }
            else
            {
                if (Math.Min(start.Center.X, end.Center.X)==start.Center.X)
                {
                    //g.DrawLine(Pens.Blue, start.Center, end.Center);
                    Point textPoint;
                    Point third = CalculateBezierePoint(start.Center, end.Center, true, out textPoint);
                    g.DrawBezier(Pens.Green, start.Center, third, third, end.Center);
                     g.DrawString(this.gain, new Font(new FontFamily("arial"), 10), Brushes.Black,textPoint);
                }
                else
                {
                    //Point control1 = new Point((start.Center.X + end.Center.X) / 2, Math.Min(start.Center.Y, end.Center.Y) - 15);
                    //Point control2 = new Point((start.Center.X + end.Center.X) / 2, Math.Min(start.Center.Y, end.Center.Y) - 18);
                    Point textPoint;
                    Point third = CalculateBezierePoint(start.Center, end.Center, false, out textPoint);
                    g.DrawBezier(Pens.Red, start.Center, third, third, end.Center);
                    g.DrawString(this.gain, new Font(new FontFamily("arial"), 10), Brushes.Black,textPoint);


                }
                
             
                //DrawArrow(g);
            }
        }
        public Line(Line copy)
        {
            this.start = copy.start;
            this.end = copy.end;
            this.gain = copy.gain;
        }
        private void DrawArrow(Graphics g)
        {        
            float arrowWidth = 10.0f;
            float theta = 0.423f;
            int[] xPoints = new int[3];
            int[] yPoints = new int[3];
            float[] vecLine = new float[2];
            float[] vecLeft = new float[2];
            float fLength;
            float th;
            float ta;
            float baseX, baseY;

            xPoints[0] = end.Center.X;
            yPoints[0] = end.Center.Y;

            // build the line vector
            vecLine[0] = (float)xPoints[0] - start.Center.X;
            vecLine[1] = (float)yPoints[0] - start.Center.Y;

            // build the arrow base vector - normal to the line
            vecLeft[0] = -vecLine[1];
            vecLeft[1] = vecLine[0];

            // setup length parameters
            fLength = (float)Math.Sqrt(vecLine[0] * vecLine[0] + vecLine[1] * vecLine[1]);
            th = arrowWidth / (2.0f * fLength);
            ta = arrowWidth / (2.0f * ((float)Math.Tan(theta) / 2.0f) * fLength);

            // find the base of the arrow
            baseX = ((float)xPoints[0] - ta * vecLine[0]);
            baseY = ((float)yPoints[0] - ta * vecLine[1]);

            // build the points on the sides of the arrow
            xPoints[1] = (int)(baseX + th * vecLeft[0]);
            yPoints[1] = (int)(baseY + th * vecLeft[1]);
            xPoints[2] = (int)(baseX - th * vecLeft[0]);
            yPoints[2] = (int)(baseY - th * vecLeft[1]);
            Point[] points = {
                new Point(xPoints[0], yPoints[0]),
                new Point(xPoints[1], yPoints[1]),
                new Point(xPoints[2], yPoints[2])
            };
            g.FillPolygon(Brushes.Black,points);
        }
        /// <summary>Calculates the third point for bezeire curve given start and end point</summary>
        /// <param name="start">Start point of the curve</param>
        /// <param name="end">End point of the curve</param>
        /// <param name="isClockwise">Direction of the curve</param>
        /// <returns></returns>
        private static Point CalculateBezierePoint(Point start, Point end, bool isClockwise, out Point textPoint)
        {
            double angle = FindAngleBetweenPoints(start, end);
            int direction = isClockwise ? 1 : -1;

            // Flip the position of the curve, according to the direction
            double distance = CalculateDistance(start, end) * 0.5 * direction;
            double prepAngle = angle + (direction * Math.PI / 2);
            Point midPoint = CalculateMidPoint(start, end);

            Point retVal = new Point( 
                (int)(midPoint.X + (Math.Cos(prepAngle) * distance)),
                (int)(midPoint.Y + (Math.Sin(prepAngle) * distance)));

            textPoint = CalculateMidPoint(midPoint, retVal);
            return retVal;
        }

        /// <summary>Calculates the distance between two given points</summary>
        /// <param name="start">Start point to calculate the distance from</param>
        /// <param name="end">End point to calculate the distance to</param>
        /// <returns></returns>
        private static double CalculateDistance(Point start, Point end)
        {
            return Math.Sqrt(((start.X - end.X) * (start.X - end.X) + (start.Y - end.Y) * (start.Y - end.Y)));
        }

        /// <summary>Calculates the midpoint between two given points</summary>
        /// <param name="start">Start point to calculate the distance from</param>
        /// <param name="end">End point to calculate the distance to</param>
        /// <returns>Midpoint location</returns>
        private static Point CalculateMidPoint(Point start, Point end)
        {
            var midX = (start.X + end.X) / 2;
            var midY = (start.Y + end.Y) / 2;
            return new Point(midX, midY);
        }

        private static double FindAngleBetweenPoints(Point start, Point end)
        {
            return Math.Atan2((end.Y - start.Y), (end.X - start.X));
        }
    }
}
 