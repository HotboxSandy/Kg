using System;
using System.Drawing;


namespace Draw.src.Model
{

    [Serializable]
    public class DoubleCrossCircle : Shape
    {
        #region Constructor

        public DoubleCrossCircle(RectangleF rect) : base(rect)
        {
        }

        public DoubleCrossCircle(DoubleCrossCircle rectangle) : base(rectangle)
        {
        }

        #endregion


        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
            {


                return true;
            }
            else

                return false;
        }


        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawEllipse(new Pen(StrokeColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            grfx.DrawLine(new Pen(StrokeColor), Rectangle.X + 10, Rectangle.Y + 22, Rectangle.X + Rectangle.Width - 1, Rectangle.Y + Rectangle.Height - 44);
            grfx.DrawLine(new Pen(StrokeColor), Rectangle.X + 0, Rectangle.Y + 52, Rectangle.X + Rectangle.Width - 15, Rectangle.Y + Rectangle.Height - 14);
        }
    }
}