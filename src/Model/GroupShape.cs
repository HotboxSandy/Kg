using System;
using System.Collections.Generic;
using System.Drawing;

namespace Draw
{
    // The Group class is a base primitive that inherits from the base Shape.
    [Serializable]
    public class GroupShape : Shape
    {
        #region Constructor

        public GroupShape(RectangleF rect) : base(rect)
        {
        }

        public GroupShape(RectangleShape rectangle) : base(rectangle)
        {
        }

        public List<Shape> SubItems { get; set; }

        public override Color FillColor
        {
            set
            {
                foreach (var item in SubItems)
                {
                    item.FillColor = value;
                }
            }
        }

        #endregion

        public override PointF Location
        {
            set
            {
                float dx = value.X - Location.X;
                float dy = value.Y - Location.Y;
                base.Location = value;
                foreach (var item in SubItems)
                {
                    item.Location = new PointF(item.Location.X + dx, item.Location.Y + dy);
                }
            }
        }

        /// Checking whether a point belongs to the primitive.
        /// In the case of a primitive, this method may not be overridden because
        /// The implementation matches that of the abstract Shape class it checks for
        /// whether the point is in the element's bounding primitive (and it matches
        /// the element in this case).
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
            {
                // Check if it is in the object only if the point is in the bounding primitive.
                // In the case of a primitive - we directly return true

                foreach (var item in SubItems)
                {
                    if (item.Contains(point)) return true;
                }
                return false;
            }
            else
                // If it is not in the bounding primitive, it cannot be in the object and => false
                return false;
        }

        // The part visualising the specific primitive.
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            foreach (var item in SubItems)
            {
                item.DrawSelf(grfx);
            }
        }
    } 
}

