using System;
using System.Drawing;
using System.Collections.Generic;
using Draw.src.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Draw
{

    public class DialogProcessor : DisplayProcessor
	{
		#region Constructor
		
		public DialogProcessor()
		{
		}

        #endregion

        #region Properties

        /// <summary>
        /// Selected item.
        /// </summary>
        private List<Shape> selection = new List<Shape>();
		public List<Shape> Selection {
			get { return selection; }
			set { selection = value; }
		}

        /// <summary>
        /// Whether the dialog is currently in the "drag" state of the selected item.
        /// </summary>
        private bool isDragging;
		public bool IsDragging {
			get { return isDragging; }
			set { isDragging = value; }
		}

        /// <summary>
        /// Last position of the mouse when "drag".
        /// Used to specify the translation vector.
        /// </summary>
        private PointF lastLocation;
		public PointF LastLocation {
			get { return lastLocation; }
			set { lastLocation = value; }
		}

        #endregion


        public void AddRandomRectangle() 
		{
			Random rnd = new Random();
			int x = rnd.Next(100,1000);
			int y = rnd.Next(100,600);
			
			RectangleShape rect = new RectangleShape(new Rectangle(x,y,100,200));
			rect.FillColor = Color.White;
            rect.StrokeColor = Color.Aqua;
            ShapeList.Add(rect);
		} 

        public void AddRandomEllipse() 
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            EllipseShape ellipse = new EllipseShape(new Rectangle(x, y, 100, 200));
            ellipse.FillColor = Color.White;
			ellipse.StrokeColor = Color.Aquamarine;

            ShapeList.Add(ellipse);
        } 

        /// <summary>
        /// Checks if a point is in the element.
        /// Iterates in reverse order of the preview to find the
        /// the "top" element ie. the one we see under the mouse.
        /// </summary>
        /// <param name="point">Point indicated</param>
        /// <returns>The image element to which the given point belongs.</returns>
        public Shape ContainsPoint(PointF point)
		{
			for(int i = ShapeList.Count - 1; i >= 0; i--){
				if (ShapeList[i].Contains(point)){
					ShapeList[i].FillColor = Color.Red;
						
					return ShapeList[i];
				}	
			}
			return null;
		}

        /// <summary>
        /// Translation of the selected element to the vector specified by <paramref name="p>p</paramref>
        /// </summary>
        /// <param name="p">Translation vector.</param>
        public void TranslateTo(PointF p)
		{
			foreach(Shape item in Selection) {
				item.Location = new PointF(item.Location.X + p.X - lastLocation.X, item.Location.Y + p.Y - lastLocation.Y);
				lastLocation = p;
			}
		}

        /// Color window.
        public void SetFillColor(Color color) 
        {
            foreach (var item in Selection)
            {
                item.FillColor = color;
            }
        }
        internal void SetFillColor(object color)
        {
            throw new NotImplementedException();
        }
        public override void Draw(Graphics grfx)
        {
            base.Draw(grfx);
            foreach (var item in Selection)
            {
                grfx.DrawRectangle(Pens.Black, item.Location.X - 3, item.Location.Y - 3, item.Width + 6, item.Height + 6);
            }
        } 


        public void Group() 
        {
            if (Selection.Count < 2) return;

            float minX = float.PositiveInfinity; // Initialize Boundary Variables
            float minY = float.PositiveInfinity;
            float maxX = float.NegativeInfinity;
            float maxY = float.NegativeInfinity;
            foreach (var item in Selection)
            {
                if (minX > item.Location.X) minX = item.Location.X; // Find Bounding Box
                if (minY > item.Location.Y) minY = item.Location.Y;
                if (maxX < item.Location.X + item.Width) maxX = item.Location.X + item.Width;
                if (maxY < item.Location.Y + item.Height) maxY = item.Location.Y + item.Height;
            }

            var group = new GroupShape(new RectangleF(minX, minY, maxX - minX, maxY - minY));
            group.SubItems = Selection;

            foreach (var item in Selection)
            {
                ShapeList.Remove(item);
            }

            Selection = new List<Shape>();
            Selection.Add(group);

            ShapeList.Add(group);
        }


        public void Ungroup() 
        {
            for (int i = 0; i < Selection.Count; i++)
            {
                if (Selection[i] is GroupShape)
                {
                    var ungroupedShapes = (Selection[i] as GroupShape).SubItems;
                    ShapeList.AddRange(ungroupedShapes);
                    ShapeList.RemoveAt(ShapeList.IndexOf(Selection[i]));
                    Selection.AddRange(ungroupedShapes);
                    Selection.RemoveAt(i);
                    i -= 1;
                }
            }
        }


        public void AddRandomCircle() 
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            CircleShape circle = new CircleShape(new Rectangle(x, y, 100, 100));
            circle.FillColor = Color.White;
            circle.StrokeColor = Color.LightSkyBlue;

            ShapeList.Add(circle);
        }


        public void AddRandomTriangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            TriangleShape triangle = new TriangleShape(new Rectangle(x, y, 100, 100));
            triangle.FillColor = Color.White;
            triangle.StrokeColor = Color.LightSlateGray;

            ShapeList.Add(triangle);
        }



        public void AddRandomSquare() 
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            SquareShape square = new SquareShape(new Rectangle(x, y, 100, 100));
            square.FillColor = Color.White;
            square.StrokeColor = Color.ForestGreen;

            ShapeList.Add(square);
        }



        public void OpenFile(string fileName) 
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            ShapeList = (List<Shape>)bf.Deserialize(fs);
            fs.Close();
        } 


        // Choosing shapes.
        public void SelectAll()
        {
            Selection = new List<Shape>(ShapeList);
        }



        // Deleting shapes.
        internal void Delete() 
        {
            foreach (var item in Selection)
            ShapeList.Remove(item);
            Selection.Clear();
        } 


        public void SaveAs(string fileName) 
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, ShapeList);
            fs.Close();
        } 

        public void AddRandomDoubleCrossedCircle() 
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            DoubleCrossedCircle ellipse = new DoubleCrossedCircle(new Rectangle(x, y, 100, 100));
            ellipse.FillColor = Color.LightBlue;
            ellipse.StrokeColor = Color.Black;

            ShapeList.Add(ellipse);
        }

 
        public void AddRandomLine() 
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            LineShape line = new LineShape(new Rectangle(x, y, 150, 0));
            line.FillColor = Color.White;
            line.StrokeColor = Color.DarkOrchid;
            ShapeList.Add(line);
        } 


        public void AddRandomCrossedCircle() 
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            CrossedCircle ellipse = new CrossedCircle(new Rectangle(x, y, 100, 100));
            ellipse.FillColor = Color.LightBlue;
            ellipse.StrokeColor = Color.Black;

            ShapeList.Add(ellipse);
        }


        public void AddRandomTripleCrossedCircle() 
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            TripleCrossedCircle ellipse = new TripleCrossedCircle(new Rectangle(x, y, 100, 100));
            ellipse.FillColor = Color.LightBlue;
            ellipse.StrokeColor = Color.Black;

            ShapeList.Add(ellipse);
        }


        public void AddRandomCrosssedCircleWithTwoLines() 
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            CrossedCircleWithTwoLines ellipse = new CrossedCircleWithTwoLines(new Rectangle(x, y, 100, 100));
            ellipse.FillColor = Color.LightBlue;
            ellipse.StrokeColor = Color.Black;

            ShapeList.Add(ellipse);
        }


        public void AddRandomCrossedCircleWithFourLines()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            CrossedCircleWithFourLines ellipse = new CrossedCircleWithFourLines(new Rectangle(x, y, 100, 100));
            ellipse.FillColor = Color.LightBlue;
            ellipse.StrokeColor = Color.Black;

            ShapeList.Add(ellipse);
        }


        public void AddRandomCrossedRectangle() 
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            CrossedRectangle rect = new CrossedRectangle(new Rectangle(x, y, 100, 200));
            rect.FillColor = Color.LightBlue;
            rect.StrokeColor = Color.Black;
            ShapeList.Add(rect);
        } 


        public void AddRandomTripleCrossedRectangle() 
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            TripleCrossedRectangle rect = new TripleCrossedRectangle(new Rectangle(x, y, 100, 200));
            rect.FillColor = Color.LightBlue;
            rect.StrokeColor = Color.Black;
            ShapeList.Add(rect);
        } 


        public void AddRandomCrossedTriangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            CrossedTriangle triangle = new CrossedTriangle(new Rectangle(x, y, 100, 100));
            triangle.FillColor = Color.LightBlue;
            triangle.StrokeColor = Color.Black;

            ShapeList.Add(triangle);
        }


        public void AddRandomTripleCrossedTrapezoid() // Trapec
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            TripleCrossedTrapezoid triangle = new TripleCrossedTrapezoid(new Rectangle(x, y, 100, 100));
            triangle.FillColor = Color.LightBlue;
            triangle.StrokeColor = Color.Black;

            ShapeList.Add(triangle);
        }


        public void AddRandomDoubleCrossedRhombus()// Romb
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            DoubleCrossedRhombus triangle = new DoubleCrossedRhombus(new Rectangle(x, y, 100, 100));
            triangle.FillColor = Color.LightBlue;
            triangle.StrokeColor = Color.Black;

            ShapeList.Add(triangle);
        }


        public void AddRandomExamShape() 
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            ExamShape ellipse = new ExamShape(new Rectangle(x, y, 100, 100));
            ellipse.FillColor = Color.LightGreen;
            ellipse.StrokeColor = Color.Black;

            ShapeList.Add(ellipse);
        }
    } 
}
