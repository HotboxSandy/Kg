using System;
using System.Drawing;
using System.Reflection;

namespace Draw.src.Model
{

    [Serializable]
    public class TripleCrossedTrapezoid : Shape
    {
        #region Constructor

        public TripleCrossedTrapezoid(RectangleF rect) : base(rect)
        {
        }

        public TripleCrossedTrapezoid(TripleCrossedTrapezoid rectangle) : base(rectangle)
        {
        }

        #endregion

        /// <summary>
        /// Checking whether a point belongs to the trapezoid.
        /// In the case of a trapezoid, this method may not be overridden because
        /// the implementation matches that of the abstract Shape class it checks for
        /// whether the point is in the element's bounding trapezoid (and it matches
        /// the element in this case).
        /// </summary>
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
                // Check if it is in the object only if the point is in the bounding trapezoid.
                // In the case of a trapezoid - we directly return true
                return true;
            else
                // If it is not in the bounding trapezoid, it cannot be in the object and => false
                return false;
        }

        /// The part visualising the specific primitive.
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);


            float topWidth = Rectangle.Width * 1.35f; // length of the top base
            float bottomWidth = Rectangle.Width * 0.9f; // length of the bottom base
            float height = Rectangle.Height * 0.9f; // height of the trapezoid
            float x1 = Rectangle.X + (Rectangle.Width - topWidth) / 2; // x-coordinate of the left vertex of the top base
            float x2 = Rectangle.X + (Rectangle.Width - bottomWidth) / 2; // x-coordinate of the left vertex of the bottom base
            float y1 = Rectangle.Y; // y-coordinate of the top vertex
            float y2 = Rectangle.Y + height; // y-coordinate of the bottom vertex

            PointF[] points = new PointF[]
            {
                new PointF(x1, y1),
                new PointF(x2, y2),
                new PointF(x2 + bottomWidth, y2),
                new PointF(x1 + topWidth, y1)
            };

            grfx.FillPolygon(new SolidBrush(FillColor), points);
            grfx.DrawPolygon(new Pen(StrokeColor), points);

            // Draw the three lines
            grfx.DrawLine(new Pen(StrokeColor), new PointF(Rectangle.X, Rectangle.Y + Rectangle.Height * 0.96f), new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height * 0.9f / 2));
            grfx.DrawLine(new Pen(StrokeColor), new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y), new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height * 0.9f / 2));
            grfx.DrawLine(new Pen(StrokeColor), new PointF(Rectangle.X + Rectangle.Width * 1.05f, Rectangle.Y + Rectangle.Height * 0.9f / 2), new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height * 0.9f / 2));
        }
    }
}