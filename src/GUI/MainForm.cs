using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace Draw
{
    /// <summary>
    /// A user control is placed on the main form,
    /// in which the visualization takes place.
    /// </summary>
    public partial class MainForm : Form
	{
        /// <summary>
        /// An aggregated dialog processor in the form facilitates manipulation of the model.
        /// </summary>
        private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

        /// <summary>
        /// Exit the program. Closes the main form and with it the program.
        /// </summary>
        void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}

        /// <summary>
        /// The event that is caught to be previewed when the model is modified.
        /// </summary>
        void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}

        /// <summary>
        /// A button that places a rectangle with the specified dimensions at any location.
        /// Changes the status bar and disables the control we're visualising in.
        /// </summary>
        void DrawRectangleSpeedButtonClick(object sender, EventArgs e) //Rectangle Button
		{
			dialogProcessor.AddRandomRectangle();
			
			statusBar.Items[0].Text = "Last step: Drawing a rectangle";
			
			viewPort.Invalidate();
		} //end of Rectangle Button

        /// <summary>
        /// Catching the coordinates when a mouse button is pressed and checking (in reverse order) if it isn't
        /// item clicked. If so, it is marked as selected and the "drag" process begins.
        /// Change the status and disable the control in which we are visualising.
        /// The implementation is the dialog with the user in which the "top" element of the screen is selected.
        /// </summary>
        void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (pickUpSpeedButton.Checked) {
				Shape sel = dialogProcessor.ContainsPoint(e.Location);
				if(sel != null)
				{
					if (dialogProcessor.Selection.Contains(sel))
						dialogProcessor.Selection.Remove(sel);
						else
						dialogProcessor.Selection.Add(sel);

				}
					statusBar.Items[0].Text = "Last action: Primitive selection";
					dialogProcessor.IsDragging = true;
					dialogProcessor.LastLocation = e.Location;
					viewPort.Invalidate();
			}
		}

        /// <summary>
        /// Capture the mouse movement.
        /// If we are in "drag" mode, the selected element is translated.
        /// </summary>
        void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selection != null) statusBar.Items[0].Text = "Last action: Dragging";
				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
		}

        /// <summary>
        /// Catch the release of the mouse button.
        /// Exit "drag" mode.
        /// </summary>
        void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}

        /// <summary>
        /// A button that places an ellipse with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void EllipseButton_Click(object sender, EventArgs e) // Ellipse button
        {
            dialogProcessor.AddRandomEllipse();

            statusBar.Items[0].Text = "Last action: Drawing an ellipse";

            viewPort.Invalidate();
        } //end of Ellipse Button

        /// <summary>
        /// A button that opens a window with colors.
        /// </summary>
        private void ColorDialog_Click(object sender, EventArgs e) //ColorDialog button
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.SetFillColor(colorDialog1.Color);
                viewPort.Invalidate();
            }
            //if(colorDialog1.ShowDialog()==DialogResult.OK)
            //{
            //	dialogProcessor.Selection.FillColor = colorDialog1.Color;
            //	viewPort.Invalidate();
            //}
        } // end of ColorDialog button

        /// <summary>
        /// A button that groups primitives.
        /// </summary>
        private void GroupPrimitivesButton_Click(object sender, EventArgs e) //GroupPrimitivesButton
        {
            dialogProcessor.Group();
			viewPort.Invalidate();
            // calculate bounding box
            // new group shape
            // SubShape = Selection
        } // end of GroupPrimitivesButton

        /// <summary>
        /// A button that ungroups primitives.
        /// </summary>
        private void UngroupPrimitivesButton_Click(object sender, EventArgs e) //UnGroupPrimitivesButton
        {
            dialogProcessor.Ungroup();
            viewPort.Invalidate();
        } //end of UnGroupPrimitivesButton

        /// <summary>
        /// A button that places a circle with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void CircleButton_Click(object sender, EventArgs e) //Circle button
        {
            dialogProcessor.AddRandomCircle();
            statusBar.Items[0].Text = "Last action: Drawing a circle";
            viewPort.Invalidate();
        } // end of Circle button

        /// <summary>
        /// A button that places a triangle with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void TriangleButton_Click(object sender, EventArgs e) //Triangle button
        {
            dialogProcessor.AddRandomTriangle();
            statusBar.Items[0].Text = "Last action: Drawing a triangle";
            viewPort.Invalidate();
        } // end of Triangle button

        /// <summary>
        /// A button that places a square with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void SquareButton_Click(object sender, EventArgs e) //Square button
        {
            dialogProcessor.AddRandomSquare();
            statusBar.Items[0].Text = "Last action: Drawing a square";
            viewPort.Invalidate();
        } // end of Square button

        /// <summary>
        /// A dropdown button that opens files.
        /// </summary>
        private void OpenButton_Click(object sender, EventArgs e) //Open Button
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.OpenFile(openFileDialog1.FileName);
                viewPort.Invalidate();
            }
        } // end of Open button

        /// <summary>
        /// A dropdown button that selects shapes.
        /// </summary>
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) //SelectAll button
        {
            dialogProcessor.SelectAll();
            viewPort.Invalidate();
        } // end of SelectAll button

        /// <summary>
        /// A dropdown button that deletes shapes.
        /// </summary>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) //Delete button
        {
            dialogProcessor.Delete();
            viewPort.Invalidate();
        } // end of Delete button

        /// <summary>
        /// A dropdown button that saves images in ".jpg", ".png", ".bmp" formats.
        /// </summary>
        private void saveAsAPictureToolStripMenuItem_Click(object sender, EventArgs e) // SaveAsAPicture button
        {
            Bitmap bmp = new Bitmap(width: viewPort.Width, height: viewPort.Height);
            Graphics g = Graphics.FromImage(bmp);
            Rectangle rect = viewPort.RectangleToScreen(viewPort.ClientRectangle);
            g.CopyFromScreen(rect.Location, Point.Empty, viewPort.Size);
            g.Dispose();
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = ".png file|*.png|.jpeg file|*.jpg|.bmp file|*.bmp";
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(s.FileName))
                {
                    File.Delete(s.FileName);
                }
                if (s.FileName.Contains(".jpg"))
                {
                    bmp.Save(s.FileName, ImageFormat.Jpeg);
                }
                else if (s.FileName.Contains(".png"))
                {
                    bmp.Save(s.FileName, ImageFormat.Png);
                }
                else if (s.FileName.Contains(".bmp"))
                {
                    bmp.Save(s.FileName, ImageFormat.Bmp);
                }
            }
        } // end of SaveAsAPicture button

        /// <summary>
        /// A dropdown button that saves files.
        /// </summary>
        private void saveAsFileToolStripMenuItem_Click(object sender, EventArgs e) // SaveAsFile button
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.SaveAs(saveFileDialog1.FileName);
            }
        } // end of SaveAsFile button

        /// <summary>
        /// A button that places a double crossed circle with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void DoubleCrossedCircle_Click(object sender, EventArgs e) // DoubleCrossedCircle button
        {
            dialogProcessor.AddRandomDoubleCrossedCircle();
            statusBar.Items[0].Text = "Last action: Drawing a  double crossed circle";
            viewPort.Invalidate();
        } // end of DoubleCrossedCircle button


        /// <summary>
        /// A button that places a line with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void LineButton_Click(object sender, EventArgs e) //Line button
        {
            dialogProcessor.AddRandomLine();

            statusBar.Items[0].Text = "Last action: Drawing a line";

            viewPort.Invalidate();
        } // end of Line button


        /// <summary>
        /// A button that places a crossed circle with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void CrossedCircle_Click(object sender, EventArgs e) //CrossedCircle button
        {
            dialogProcessor.AddRandomCrossedCircle();
            statusBar.Items[0].Text = "Last action: Drawing a crossed circle";
            viewPort.Invalidate();
        }// end of DoubleCrossedCircle button

        /// <summary>
        /// A button that places a triple crossed circle with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void TripleCrossedCircle_Click(object sender, EventArgs e) // TripleCrossedCircle button
        {
            dialogProcessor.AddRandomTripleCrossedCircle();
            statusBar.Items[0].Text = "Last action: Drawing a triple crossed circle";
            viewPort.Invalidate();
        } // end of TripleCrossedCircle button

        /// <summary>
        /// A button that places a crossed circle with two lines with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void CrossedCircleWithTwoLines_Click(object sender, EventArgs e) //CrossedCircleWithTwoLines button
        {
            dialogProcessor.AddRandomCrosssedCircleWithTwoLines();
            statusBar.Items[0].Text = "Last action: Drawing a crossed circle with two lines";
            viewPort.Invalidate(); 
        }// end of CrossedCircleWithTwoLines button
        
        /// <summary>
        /// A button that places a crossed circle with four lines with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void CrossedCircleWithFourLines_Click(object sender, EventArgs e) //CrossedCircleWithFourLines button
        {
            dialogProcessor.AddRandomCrossedCircleWithFourLines();
            statusBar.Items[0].Text = "Last action: Drawing a crossed circle with four lines";
            viewPort.Invalidate();
        } // end of CrossedCircleWithFourLines button

        /// <summary>
        /// A button that places a crossed rectangle with 2 lines with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void CrossedRectangle_Click(object sender, EventArgs e) //CrossedRectangle button
        {
            dialogProcessor.AddRandomCrossedRectangle();
            statusBar.Items[0].Text = "Last action: Drawing a crossed rectangle with two lines";
            viewPort.Invalidate();
        } // end of CrossedRectangle button
        
        /// <summary>
        /// A button that places a triple crossed rectangle with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void TripleCrossedRectangle_Click(object sender, EventArgs e) //TripleCrossedRectangle button
        {
            dialogProcessor.AddRandomTripleCrossedRectangle();
            statusBar.Items[0].Text = "Last action: Drawing a triple crossed rectangle";
            viewPort.Invalidate();
        } // end of TripleCrossedRectangle button

        /// <summary>
        /// A button that places a crossed triangle with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void CrossedTriangle_Click(object sender, EventArgs e) // CrossedTriangle button
        {
            dialogProcessor.AddRandomCrossedTriangle();
            statusBar.Items[0].Text = "Last action: Drawing a crossed triangle";
            viewPort.Invalidate();
        } // end of CrossedTriangle button

        /// <summary>
        /// A button that places a triple crossed trazpezoid with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void TripleCrossedTrapezoid_Click(object sender, EventArgs e) // TripleCrossedTrapezoid button
        {
            dialogProcessor.AddRandomTripleCrossedTrapezoid();
            statusBar.Items[0].Text = "Last action: Drawing a triple crossed trapezoid";
            viewPort.Invalidate();
        }// end of TripleCrossedTrapezoid button


        /// <summary>
        /// A button that places a double crossed rhombus with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void DoubleCrossedRhombus_Click(object sender, EventArgs e) // DoubleCrossedRhombus button
        {
            dialogProcessor.AddRandomDoubleCrossedRhombus();
            statusBar.Items[0].Text = "Last action: Drawing a double crossed rhombus";
            viewPort.Invalidate();
        } // end of DoubleCrossedRhombus button

        /// <summary>
        /// A button that places a triple crossed circle with the specified dimensions at any location.
        /// It changes the status bar and disables the control in which we are visualising.
        /// </summary>
        private void ExamShape_Click(object sender, EventArgs e) // ExamShape button
        {
            dialogProcessor.AddRandomExamShape();
            statusBar.Items[0].Text = "Last action: Drawing a triple crossed circle";
            viewPort.Invalidate();
        } // end of ExamShape button
    } // end of class MainForm
}
