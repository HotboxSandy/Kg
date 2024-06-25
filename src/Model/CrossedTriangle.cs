using System;
using System.Drawing;
using System.Reflection;

namespace Draw.src.Model
{
    /// The Triangle class is a base primitive that inherits from the base Shape.
    [Serializable]
    public class CrossedTriangle : Shape
    {
        #region Constructor

        public CrossedTriangle(RectangleF rect) : base(rect)
        {
        }

        public CrossedTriangle(CrossedTriangle rectangle) : base(rectangle)
        {
        }

        #endregion

        /// Checking whether a point belongs to the triangle.
        /// In the case of a triangle, this method may not be overridden because
        /// The implementation matches that of the abstract Shape class it checks for
        /// whether the point is in the element's bounding triangle (and it matches
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

            PointF[] points = new PointF[]
            {
                new PointF(Rectangle.X, Rectangle.Y),
                new PointF(Rectangle.X, Rectangle.Bottom),
                new PointF(Rectangle.Right, Rectangle.Top)
            };

            // Rotate the triangle by 45 degrees clockwise
            PointF center = new PointF((Rectangle.Left + Rectangle.Right) / 2, (Rectangle.Top + Rectangle.Bottom) / 2);
            for (int i = 0; i < points.Length; i++)
            {
                PointF p = points[i];
                float x = center.X + (p.X - center.X) * (float)Math.Cos(45 * Math.PI / 180) - (p.Y - center.Y) * (float)Math.Sin(45 * Math.PI / 180);
                float y = center.Y + (p.X - center.X) * (float)Math.Sin(45 * Math.PI / 180) + (p.Y - center.Y) * (float)Math.Cos(45 * Math.PI / 180);
                points[i] = new PointF(x, y);
            }

            PointF middle = new PointF((points[0].X + points[1].X + points[2].X) / 3, (points[0].Y + points[1].Y + points[2].Y) / 3);

            grfx.FillPolygon(new SolidBrush(FillColor), points);
            grfx.DrawPolygon(new Pen(StrokeColor), points);

            // Draw the crossed lines
            grfx.DrawLine(new Pen(StrokeColor), points[0], middle);
            grfx.DrawLine(new Pen(StrokeColor), points[1], middle);
            grfx.DrawLine(new Pen(StrokeColor), points[2], middle);
        }

    } 
}
