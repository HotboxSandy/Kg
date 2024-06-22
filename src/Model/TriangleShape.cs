using System;
using System.Drawing;

namespace Draw.src.Model
{
    /// <summary>
    /// The Triangle class is a base primitive that inherits from the base Shape.
    /// </summary>
    [Serializable]
    public class TriangleShape : Shape
    {
        #region Constructor

        public TriangleShape(RectangleF rect) : base(rect)
        {
        }

        public TriangleShape(TriangleShape rectangle) : base(rectangle)
        {
        }

        #endregion

        /// <summary>
        /// Checking whether a point belongs to the triangle.
        /// In the case of a triangle, this method may not be overridden because
        /// The implementation matches that of the abstract Shape class it checks for
        /// whether the point is in the element's bounding triangle (and it matches
        /// the element in this case).
        /// </summary>
        public override bool Contains(PointF point)
        {
            PointF a = Rectangle.Location;
            PointF b = new PointF(Rectangle.Left, Rectangle.Bottom);
            PointF c = new PointF(Rectangle.Right, Rectangle.Top);

            double A = GetArea(a, b, c);
            double A1 = GetArea(point, b, c);
            double A2 = GetArea(a, point, c);
            double A3 = GetArea(a, b, point);

            return (A1 + A2 + A3) == A;
        }

        private double GetArea(PointF b, PointF a, PointF c)
        {
            return Math.Abs((a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y)) / 4.0);
        }

        /// <summary>
        /// The part visualising the specific primitive.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            PointF[] points = new PointF[]
            {
                new PointF(Rectangle.X, Rectangle.Y),
                new PointF(Rectangle.X, Rectangle.Bottom),
                new PointF(Rectangle.Right, Rectangle.Top)
            };

            grfx.FillPolygon(new SolidBrush(FillColor), points);
            grfx.DrawPolygon(new Pen(StrokeColor), points);

        }

    } // end of class TriangleShape
}
