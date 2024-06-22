using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    /// <summary>
    /// The Square class is a base primitive that inherits from the base Shape.
    /// </summary>
    [Serializable]
    public class SquareShape : Shape
    {
        #region Constructor

        public SquareShape(RectangleF rect) : base(rect)
        {
        }

        public SquareShape(SquareShape rectangle) : base(rectangle)
        {
        }

        #endregion

        /// <summary>
        /// Checking whether a point belongs to the square.
        /// In the case of a square, this method may not be overridden because
        /// The implementation matches that of the abstract Shape class it checks for
        /// whether the point is in the element's bounding square (and it matches
        /// the element in this case).
        /// </summary>
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
                // Check if it is in the object only if the point is in the bounding square.
                // In the case of a square - we directly return true
                return true;
            else
                // If it is not in the bounding square, it cannot be in the object and => false
                return false;
        }

        /// <summary>
        /// The part visualising the specific primitive.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            grfx.FillRectangle(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawRectangle(new Pen(StrokeColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
        }
    } // end of class SquareShape
}

