using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace Draw.src.Model
{
    /// <summary>
    /// The Rhombus class is a base primitive that inherits from the base Shape.
    /// </summary>
    [Serializable]
    public class DoubleCrossRhombus : Shape
    {
        #region Constructor

        public DoubleCrossRhombus(RectangleF rect) : base(rect)
        {
        }

        public DoubleCrossRhombus(DoubleCrossRhombus rectangle) : base(rectangle)
        {
        }

        #endregion

        /// <summary>
        /// Checking whether a point belongs to the rhombus.
        /// In the case of a rhombus, this method may not be overridden because
        /// the implementation matches that of the abstract Shape class it checks for
        /// whether the point is in the element's bounding rhombus (and it matches
        /// the element in this case).
        /// </summary>
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
                // Check if it is in the object only if the point is in the bounding rhombus.
                // In the case of a rectangle - we directly return true
                return true;
            else
                // If it is not in the bounding rhombus, it cannot be in the object and => false
                return false;
        }

        /// <summary>
        /// The part visualising the specific primitive.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            // Calculate the side length of the rhombus based on its bounding rectangle
            float sideLength = (float)Math.Sqrt(Math.Pow(Rectangle.Width / 2, 2) + Math.Pow(Rectangle.Height / 2, 2));

            // Calculate the four vertices of the rhombus
            PointF[] points = new PointF[]
            {
                new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y - sideLength / 2),
                new PointF(Rectangle.Right, Rectangle.Y + Rectangle.Height / 2),
                new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Bottom + sideLength / 2),
                new PointF(Rectangle.X, Rectangle.Y + Rectangle.Height / 2)
            };

            // Rotate the graphics object by 90 degrees around the center of the bounding rectangle
            PointF center = new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);
            grfx.TranslateTransform(center.X, center.Y);
            grfx.RotateTransform(90);
            grfx.TranslateTransform(-center.X, -center.Y);

            grfx.FillPolygon(new SolidBrush(FillColor), points);
            grfx.DrawPolygon(new Pen(StrokeColor), points);


            // Draw the two additional lines
            PointF intersectionPoint = new PointF((points[0].X + points[2].X) / 2, (points[1].Y + points[3].Y) / 2); // calculate intersection point
            grfx.DrawLine(new Pen(StrokeColor), points[0], points[2]);  // left to right through the middle
            grfx.DrawLine(new Pen(StrokeColor), points[1], intersectionPoint);  // bottom corner to intersection point

            // Reset the graphics object's transformation to the identity matrix
            grfx.ResetTransform();
        }
    }
}