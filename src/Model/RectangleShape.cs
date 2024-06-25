using System;
using System.Drawing;

namespace Draw
{
    /// The Rectangle class is a base primitive that inherits from the base Shape.

    [Serializable]
    public class RectangleShape : Shape
	{
		#region Constructor
		
		public RectangleShape(RectangleF rect) : base(rect)
		{
		}
		
		public RectangleShape(RectangleShape rectangle) : base(rectangle)
		{
		}

        #endregion

        /// Checking whether a point belongs to the rectangle.
        /// In the case of a rectangle, this method may not be overridden because
        /// The implementation matches that of the abstract Shape class it checks for
        /// whether the point is in the element's bounding rectangle (and it matches
        /// the element in this case).
        public override bool Contains(PointF point)
		{
			if (base.Contains(point))
                // Check if it is in the object only if the point is in the bounding rectangle.
                // In the case of a rectangle - we directly return true
                return true;
			else
                // If it is not in the bounding rectangle, it cannot be in the object and => false
                return false;
		}

        /// The part visualising the specific primitive.
        public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);
			
			grfx.FillRectangle(new SolidBrush(FillColor),Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			grfx.DrawRectangle(new Pen(StrokeColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

        }
	} 
}
