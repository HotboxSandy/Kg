using System;
using System.Drawing;

namespace Draw
{
    /// <summary>
    /// The Line class is a base primitive that inherits from the base Shape.
    /// </summary>
    [Serializable]
    public class LineShape : Shape
    {
        #region Constructor

        public LineShape(RectangleF rect) : base(rect)
        {
        }

        public LineShape(RectangleShape rectangle) : base(rectangle)
        {
        }

        #endregion

        /// <summary>
        /// Checking whether a point belongs to the line.
        /// In the case of a line, this method may not be overridden because
        /// The implementation matches that of the abstract Shape class it checks for
        /// whether the point is in the element's bounding line (and it matches
        /// the element in this case).
        /// </summary>
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
            {
                // Check if it is in the object only if the point is in the bounding line.
                // In the case of a line - we directly return true

                return true;
            }
            else
                // If it is not in the bounding line, it cannot be in the object and => false
                return false;
        }

        /// <summary>
        /// The part visualising the specific primitive.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            grfx.DrawLine(new Pen(StrokeColor), Rectangle.X, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height);
        }
    } // end of class LineShape
}
