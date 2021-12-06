using System;
using System.Drawing;


namespace GraphicalAssignment
{
    //this is the class for Circle that inherits from the Shape class
    class Circle : Shape
    {
        Point keyPt, radiusPt;

        //the class constructor
        public Circle(Point keyPt, Point radiusPt)
        {
            this.keyPt = keyPt;
            this.radiusPt = radiusPt;
        }

        //this is the draw method for the circle
        public void drawCircle(Graphics g, Pen blackPen)
        {
            double xdiff = keyPt.X - radiusPt.X;
            double ydiff = keyPt.Y - radiusPt.Y;

            double radius = Math.Sqrt(Math.Pow(xdiff, 2) + Math.Pow(ydiff,2));

            g.DrawEllipse(blackPen, (keyPt.X - (float)radius), (keyPt.Y - (float)radius), (2 * (float)radius), (2 * (float)radius)); //this code is adapt from https://stackoverflow.com/questions/1835062/drawing-circles-with-system-drawing

        }
    }
}
