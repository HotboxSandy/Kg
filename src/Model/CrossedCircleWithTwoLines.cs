using System;
using System.Drawing;


namespace Draw.src.Model
{
    [Serializable]
    public class CrossCircleWithTwoLines : Shape
    {
        public CrossCircleWithTwoLines(RectangleF rect) : base(rect)
        {

        }
        public CrossCircleWithTwoLines(CrossCircleWithTwoLines rectangle) : base(rectangle)
        {

        }
        /// <summary>
        /// Checking whether a point belongs to the circle.
        /// In the case of a circle, this method may not be overridden because
        /// The implementation matches that of the abstract Shape class it checks for
        /// whether the point is in the element's bounding circle (and it matches
        /// the element in this case).
        /// </summary>

        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
            {
                // Check if it is in the object only if the point is in the bounding circle.
                // In the case of a circle - we directly return true

                return true;
            }
            else
                // If it is not in the bounding circle, it cannot be in the object and => false
                return false;
        }

        /// <summary>
        /// The part visualising the specific primitive.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
           

            grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawEllipse(new Pen(StrokeColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            // Defining the points
            float x1, y1, x2, y2, x3, y3, x4, y4, radius, x0, y0, x5, y5, x6, y6;

            radius = Rectangle.Width / 2;
            x0 = Rectangle.X + Rectangle.Width / 2;
            y0 = Rectangle.Y + Rectangle.Height / 2;

            //Calculating the right line
            x1 = (float)(x0 + radius * Math.Cos(0 * (Math.PI / 180)));
            y1 = (float)(y0 + radius * Math.Sin(-90 * (Math.PI / 180)));

            x2 = (float)(x0 + radius * Math.Cos(0 * (Math.PI / 180)));
            y2 = (float)(y0 + radius * Math.Sin(90 * (Math.PI / 180)));

            //Calculating the left Line
            x3 = (float)(x0 + radius * Math.Cos(180 * (Math.PI / 180)));
            y3 = (float)(y0 + radius * Math.Sin(-90 * (Math.PI / 180)));

            x4 = (float)(x0 + radius * Math.Cos(180 * (Math.PI / 180)));
            y4 = (float)(y0 + radius * Math.Sin(90 * (Math.PI / 180)));

            //Calculating the middle line
            x5 = (float)(x0 + radius * Math.Cos(0 * (Math.PI / 180)));
            y5 = (float)(y0 + radius * Math.Sin(0 * (Math.PI / 180)));

            x6 = (float)(x0 + radius * Math.Cos(180 * (Math.PI / 180)));
            y6 = (float)(y0 + radius * Math.Sin(180 * (Math.PI / 180)));
            
            //Adding the lines

            grfx.DrawLine(new Pen(StrokeColor), x1, y1, x2, y2);
            grfx.DrawLine(new Pen(StrokeColor), x3, y3, x4, y4);
            grfx.DrawLine(new Pen(StrokeColor), x5, y5, x6, y6);

            grfx.ResetTransform();
        }
    } // end of class CrossedCircleWithTwoLines
}