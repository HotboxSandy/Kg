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
			int x = rnd.Next(50,500);
			int y = rnd.Next(50,300);
			
			RectangleShape rect = new RectangleShape(new Rectangle(x,y,50,100));
			rect.FillColor = Color.White;
            rect.StrokeColor = Color.Green;
            ShapeList.Add(rect);
		} 

  
        public void AddRandomEllipse() 
        {
            Random rnd = new Random();
            int x = rnd.Next(50, 500);
            int y = rnd.Next(50, 300);

            EllipseShape ellipse = new EllipseShape(new Rectangle(x, y, 50, 100));
            ellipse.FillColor = Color.White;
			ellipse.StrokeColor = Color.Brown;

            ShapeList.Add(ellipse);
        } 
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


        public void TranslateTo(PointF p)
		{
			foreach(Shape item in Selection) {
				item.Location = new PointF(item.Location.X + p.X - lastLocation.X, item.Location.Y + p.Y - lastLocation.Y);
				lastLocation = p;
			}
		}

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
                grfx.DrawRectangle(Pens.Black, item.Location.X - 4, item.Location.Y - 4, item.Width + 8, item.Height + 8);
            }
        } 
        public void Group() 
        {
            if (Selection.Count < 2) return;

            float minX = float.PositiveInfinity;
            float minY = float.PositiveInfinity;
            float maxX = float.NegativeInfinity;
            float maxY = float.NegativeInfinity;
            foreach (var item in Selection)
            {
                if (minX > item.Location.X) minX = item.Location.X;
                if (minY > item.Location.Y) minY = item.Location.Y;
                if (maxX < item.Location.X + item.Width) maxX = item.Location.X + item.Width;
                if (maxY < item.Location.Y + item.Height) maxY = item.Location.Y + item.Height;
            }

            var group = new GroupShape(new RectangleF(minX, minY, maxX - minX, maxY - minY));
            group.SubShape = Selection;

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
                    var ungroupedShapes = (Selection[i] as GroupShape).SubShape;
                    ShapeList.AddRange(ungroupedShapes);
                    ShapeList.RemoveAt(ShapeList.IndexOf(Selection[i]));
                    Selection.AddRange(ungroupedShapes);
                    Selection.RemoveAt(i);
                    i -= 1;
                }
            }
        }
        public void AddCircle()
        {
            Random rnd = new Random();
            int x = rnd.Next(50, 500);
            int y = rnd.Next(50, 300);

            CircleShape circle = new CircleShape(new Rectangle(x, y, 50, 50));
            circle.FillColor = Color.White;
            circle.StrokeColor = Color.Blue;

            ShapeList.Add(circle);
        }
        public void AddTriangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(50, 500);
            int y = rnd.Next(50, 300);

            TriangleShape triangle = new TriangleShape(new Rectangle(x, y, 50, 50));
            triangle.FillColor = Color.White;
            triangle.StrokeColor = Color.Black;

            ShapeList.Add(triangle);
        }
        public void AddSquare()
        {
            Random rnd = new Random();
            int x = rnd.Next(50, 500);
            int y = rnd.Next(50, 300);

            SquareShape square = new SquareShape(new Rectangle(x, y, 50, 50));
            square.FillColor = Color.White;
            square.StrokeColor = Color.Black;

            ShapeList.Add(square);
        }
        public void OpenFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            ShapeList = (List<Shape>)bf.Deserialize(fs);
            fs.Close();
        }
        public void SelectAll()
        {
            Selection = new List<Shape>(ShapeList);
        }
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
        public void AddCrossedCircle()
        {
            Random rnd = new Random();
            int x = rnd.Next(50, 500);
            int y = rnd.Next(50, 300);

            DoubleCrossedCircle ellipse = new DoubleCrossedCircle(new Rectangle(x, y, 50, 50));
            ellipse.FillColor = Color.LightBlue;
            ellipse.StrokeColor = Color.Black;

            ShapeList.Add(ellipse);
        }
        public void AddLine()
        {
            Random rnd = new Random();
            int x = rnd.Next(70, 700);
            int y = rnd.Next(70, 450);

            LineShape line = new LineShape(new Rectangle(x, y, 70, 0));
            line.FillColor = Color.White;
            line.StrokeColor = Color.DarkOrchid;
            ShapeList.Add(line);
        }
        public void AddRandomCrossedCircle() 
        {
            Random rnd = new Random();
            int x = rnd.Next(70, 700);
            int y = rnd.Next(70, 450);

            CrossedCircle ellipse = new CrossedCircle(new Rectangle(x, y, 70, 70));
            ellipse.FillColor = Color.LightBlue;
            ellipse.StrokeColor = Color.Black;

            ShapeList.Add(ellipse);
        }
        public void AddTripleCrossedCircle()
        {
            Random rnd = new Random();
            int x = rnd.Next(70, 700);
            int y = rnd.Next(70, 450);

            TripleCrossedCircle ellipse = new TripleCrossedCircle(new Rectangle(x, y, 70, 70));
            ellipse.FillColor = Color.LightBlue;
            ellipse.StrokeColor = Color.Black;

            ShapeList.Add(ellipse);
        }
        public void AddCrosssedCircleWithTwoLines() 
        {
            Random rnd = new Random();
            int x = rnd.Next(70, 700);
            int y = rnd.Next(70, 450);

            CrossedCircleWithTwoLines ellipse = new CrossedCircleWithTwoLines(new Rectangle(x, y, 70, 70));
            ellipse.FillColor = Color.LightBlue;
            ellipse.StrokeColor = Color.Black;

            ShapeList.Add(ellipse);
        }
        public void AddCrossedCircleWithFourLines()
        {
            Random rnd = new Random();
            int x = rnd.Next(70, 700);
            int y = rnd.Next(70, 450);

            CrossedCircleWithFourLines ellipse = new CrossedCircleWithFourLines(new Rectangle(x, y, 70, 70));
            ellipse.FillColor = Color.LightBlue;
            ellipse.StrokeColor = Color.Black;

            ShapeList.Add(ellipse);
        }
        public void AddCrossedRectangle() 
        {
            Random rnd = new Random();
            int x = rnd.Next(50, 500);
            int y = rnd.Next(50, 300);

            CrossedRectangle rect = new CrossedRectangle(new Rectangle(x, y, 50, 100));
            rect.FillColor = Color.LightBlue;
            rect.StrokeColor = Color.Black;
            ShapeList.Add(rect);
        } 
        public void AddTripleCrossedRectangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(50, 500);
            int y = rnd.Next(50, 300);

            TripleCrossedRectangle rect = new TripleCrossedRectangle(new Rectangle(x, y, 50, 100));
            rect.FillColor = Color.LightBlue;
            rect.StrokeColor = Color.Black;
            ShapeList.Add(rect);
        } 
        public void AddCrossedTriangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            CrossedTriangle triangle = new CrossedTriangle(new Rectangle(x, y, 100, 100));
            triangle.FillColor = Color.LightBlue;
            triangle.StrokeColor = Color.Black;

            ShapeList.Add(triangle);
        }
        public void AddRandomTripleCrossedTrapezoid()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            TripleCrossedTrapezoid triangle = new TripleCrossedTrapezoid(new Rectangle(x, y, 100, 100));
            triangle.FillColor = Color.LightBlue;
            triangle.StrokeColor = Color.Black;

            ShapeList.Add(triangle);
        }
        public void AddRandomDoubleCrossedRhombus()
        {
            Random rnd = new Random();
            int x = rnd.Next(70, 700);
            int y = rnd.Next(70, 450);

            DoubleCrossedRhombus triangle = new DoubleCrossedRhombus(new Rectangle(x, y, 70, 70));
            triangle.FillColor = Color.LightBlue;
            triangle.StrokeColor = Color.Black;

            ShapeList.Add(triangle);
        }

        
        public void AddRandomExamShape() 
        {
            Random rnd = new Random();
            int x = rnd.Next(50, 500);
            int y = rnd.Next(50, 300);

            ExamShape ellipse = new ExamShape(new Rectangle(x, y, 50, 50));
            ellipse.FillColor = Color.LightGreen;
            ellipse.StrokeColor = Color.Black;

            ShapeList.Add(ellipse);
        }

        public void AddDoubleCrossedCircle() 
        {
            Random rnd = new Random();
            int x = rnd.Next(70, 700);
            int y = rnd.Next(70, 450);

            DoubleCrossedCircle ellipse = new DoubleCrossedCircle(new Rectangle(x, y, 70, 70));
            ellipse.FillColor = Color.LightBlue;
            ellipse.StrokeColor = Color.Black;

            ShapeList.Add(ellipse);
        }

    } 
}
