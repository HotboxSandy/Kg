using System;
using System.Drawing;

namespace Draw.src.Model
{

    [Serializable]
    public class CircleShape : Shape
    {
        #region Constructor

        public CircleShape(RectangleF rect) : base(rect)
        {
        }

        public CircleShape(CircleShape rectangle) : base(rectangle)
        {
        }

        #endregion

        // Checking whether a point belongs to the circle.
        // In the case of a circle, this method may not be overridden because
        // The implementation matches that of the abstract Shape class it checks for
        // whether the point is in the element's bounding circle (and it matches
        // the element in this case).
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
            {
                // Check if it is in the object only if the point is in the bounding circle.
                // In the case of a circle - we directly return true

                float a = Width / 2;
                float b = Height / 2;
                float x0 = Location.X + a;
                float y0 = Location.Y + b;

                return Math.Pow((point.X - x0) / a, 2) + Math.Pow((point.Y - y0) / b, 2) - 1 <= 0;
            }
            else
                // If it is not in the bounding circle, it cannot be in the object and => false
                return false;
        }

        // The part visualising the specific primitive.
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawEllipse(new Pen(StrokeColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

        }
    } 
}