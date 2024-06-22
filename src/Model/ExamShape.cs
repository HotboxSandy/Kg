using System;
using System.Drawing;



namespace Draw.src.Model
{
    /// <summary>
    /// The Circle class is a base primitive that inherits from the base Shape.
    /// </summary>
    [Serializable]
    public class ExamShape : Shape
    {
        #region Constructor

        public ExamShape(RectangleF rect) : base(rect)
        {
        }

        public ExamShape(ExamShape rectangle) : base(rectangle)
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
            float x1 = centerX - (float)Math.Sqrt(2) / 2f * radius;
            float y1 = centerY - (float)Math.Sqrt(2) / 2f * radius;
            float x2 = centerX + (float)Math.Sqrt(2) / 2f * radius;
            float y2 = centerY + (float)Math.Sqrt(2) / 2f * radius;

            // Draw the diagonal lines using the calculated intersection points
            grfx.DrawLine(new Pen(StrokeColor), x1, y1, x2, y2);
            grfx.DrawLine(new Pen(StrokeColor), x1, y2, x2, y1);

            // Draw the third line from top to bottom
            grfx.DrawLine(new Pen(StrokeColor), centerX, Rectangle.Y, centerX, Rectangle.Y + Rectangle.Height);
        } // end of class TripleCrossedCircle
    }
}