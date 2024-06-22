using System;
using System.Drawing;



namespace Draw.src.Model
{
    /// <summary>
    /// The Circle class is a base primitive that inherits from the base Shape.
    /// </summary>
    [Serializable]
    public class CrossCircleWithFourLines : Shape
    {
        #region Constructor

        public CrossCircleWithFourLines(RectangleF rect) : base(rect)
        {
        }

        public CrossCircleWithFourLines(CrossCircleWithFourLines rectangle) : base(rectangle)
        {
        }

        #endregion

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

            // Calculate the intersection points between the diagonal lines and the circle
            float radius = Math.Min(Rectangle.Width, Rectangle.Height) / 2f;
            float centerX = Rectangle.X + Rectangle.Width / 2f;
            float centerY = Rectangle.Y + Rectangle.Height / 2f;
            float intersectionX = (float)(radius / Math.Sqrt(2f));
            float intersectionY = (float)(radius / Math.Sqrt(2f));

            // Draw the third line from top to bottom
            grfx.DrawLine(new Pen(StrokeColor), centerX, Rectangle.Y, centerX, Rectangle.Y + Rectangle.Height);

            // Calculate the starting and ending points of the left vertical line
            float lineX1 = centerX - (radius / 1.5f);
            float lineY1 = centerY - intersectionY;
            float lineX2 = centerX - (radius / 1.5f);
            float lineY2 = centerY + intersectionY;

            // Draw the left vertical line
            grfx.DrawLine(new Pen(StrokeColor), lineX1, lineY1, lineX2, lineY2);

            // Calculate the starting and ending points of the right vertical line
            lineX1 = centerX + (radius / 1.5f);
            lineY1 = centerY - intersectionY;
            lineX2 = centerX + (radius / 1.5f);
            lineY2 = centerY + intersectionY;

            // Draw the right vertical line
            grfx.DrawLine(new Pen(StrokeColor), lineX1, lineY1, lineX2, lineY2);

            // Calculate the starting and ending points of the horizontal line
            lineX1 = centerX - radius;
            lineY1 = centerY;
            lineX2 = centerX + radius;
            lineY2 = centerY;

            // Draw the horizontal line in the middle
            grfx.DrawLine(new Pen(StrokeColor), lineX1, lineY1, lineX2, lineY2);
        } // end of class TripleCrossedCircle
    }
}