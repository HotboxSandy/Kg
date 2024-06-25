namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsAPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.ColorDialog = new System.Windows.Forms.ToolStripButton();
            this.GroupPrimitivesButton = new System.Windows.Forms.ToolStripButton();
            this.UngroupPrimitivesButton = new System.Windows.Forms.ToolStripButton();
            this.drawRectangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.EllipseButton = new System.Windows.Forms.ToolStripButton();
            this.CircleButton = new System.Windows.Forms.ToolStripButton();
            this.TriangleButton = new System.Windows.Forms.ToolStripButton();
            this.SquareButton = new System.Windows.Forms.ToolStripButton();
            this.LineButton = new System.Windows.Forms.ToolStripButton();
            this.DoubleCrossedCircle = new System.Windows.Forms.ToolStripButton();
            this.CrossedCircle = new System.Windows.Forms.ToolStripButton();
            this.TripleCrossedCircle = new System.Windows.Forms.ToolStripButton();
            this.CrossedCircleWithTwoLines = new System.Windows.Forms.ToolStripButton();
            this.CrossedCircleWithFourLines = new System.Windows.Forms.ToolStripButton();
            this.CrossedRectangle = new System.Windows.Forms.ToolStripButton();
            this.TripleCrossedRectangle = new System.Windows.Forms.ToolStripButton();
            this.CrossedTriangle = new System.Windows.Forms.ToolStripButton();
            this.TripleCrossedTrapezoid = new System.Windows.Forms.ToolStripButton();
            this.DoubleCrossedRhombus = new System.Windows.Forms.ToolStripButton();
            this.ExamShape = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(924, 28);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenButton,
            this.saveAsFileToolStripMenuItem,
            this.saveAsAPictureToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // OpenButton
            // 
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenButton.Size = new System.Drawing.Size(282, 26);
            this.OpenButton.Text = "Open";
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // saveAsFileToolStripMenuItem
            // 
            this.saveAsFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsFileToolStripMenuItem.Image")));
            this.saveAsFileToolStripMenuItem.Name = "saveAsFileToolStripMenuItem";
            this.saveAsFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.saveAsFileToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.saveAsFileToolStripMenuItem.Text = "Save As File";
            this.saveAsFileToolStripMenuItem.Click += new System.EventHandler(this.saveAsFileToolStripMenuItem_Click);
            // 
            // saveAsAPictureToolStripMenuItem
            // 
            this.saveAsAPictureToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsAPictureToolStripMenuItem.Image")));
            this.saveAsAPictureToolStripMenuItem.Name = "saveAsAPictureToolStripMenuItem";
            this.saveAsAPictureToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.saveAsAPictureToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.saveAsAPictureToolStripMenuItem.Text = "Save As Picture";
            this.saveAsAPictureToolStripMenuItem.Click += new System.EventHandler(this.saveAsAPictureToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("selectAllToolStripMenuItem.Image")));
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 499);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusBar.Size = new System.Drawing.Size(924, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // speedMenu
            // 
            this.speedMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickUpSpeedButton,
            this.ColorDialog,
            this.GroupPrimitivesButton,
            this.UngroupPrimitivesButton,
            this.drawRectangleSpeedButton,
            this.EllipseButton,
            this.CircleButton,
            this.TriangleButton,
            this.SquareButton,
            this.LineButton,
            this.DoubleCrossedCircle,
            this.CrossedCircle,
            this.TripleCrossedCircle,
            this.CrossedCircleWithTwoLines,
            this.CrossedCircleWithFourLines,
            this.CrossedRectangle,
            this.TripleCrossedRectangle,
            this.CrossedTriangle,
            this.TripleCrossedTrapezoid,
            this.DoubleCrossedRhombus,
            this.ExamShape});
            this.speedMenu.Location = new System.Drawing.Point(0, 28);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(924, 27);
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            // 
            // pickUpSpeedButton
            // 
            this.pickUpSpeedButton.CheckOnClick = true;
            this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
            this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickUpSpeedButton.Name = "pickUpSpeedButton";
            this.pickUpSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.pickUpSpeedButton.Text = "toolStripButton1";
            // 
            // ColorDialog
            // 
            this.ColorDialog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ColorDialog.Image = ((System.Drawing.Image)(resources.GetObject("ColorDialog.Image")));
            this.ColorDialog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ColorDialog.Name = "ColorDialog";
            this.ColorDialog.Size = new System.Drawing.Size(29, 24);
            this.ColorDialog.Text = "ColorDialog";
            this.ColorDialog.Click += new System.EventHandler(this.ColorDialog_Click);
            // 
            // GroupPrimitivesButton
            // 
            this.GroupPrimitivesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GroupPrimitivesButton.Image = ((System.Drawing.Image)(resources.GetObject("GroupPrimitivesButton.Image")));
            this.GroupPrimitivesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GroupPrimitivesButton.Name = "GroupPrimitivesButton";
            this.GroupPrimitivesButton.Size = new System.Drawing.Size(29, 24);
            this.GroupPrimitivesButton.Text = "GroupPrimitivesButton";
            this.GroupPrimitivesButton.Click += new System.EventHandler(this.GroupPrimitivesButton_Click);
            // 
            // UngroupPrimitivesButton
            // 
            this.UngroupPrimitivesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UngroupPrimitivesButton.Image = ((System.Drawing.Image)(resources.GetObject("UngroupPrimitivesButton.Image")));
            this.UngroupPrimitivesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UngroupPrimitivesButton.Name = "UngroupPrimitivesButton";
            this.UngroupPrimitivesButton.Size = new System.Drawing.Size(29, 24);
            this.UngroupPrimitivesButton.Text = "UngroupPrimitivesButton";
            this.UngroupPrimitivesButton.Click += new System.EventHandler(this.UngroupPrimitivesButton_Click);
            // 
            // drawRectangleSpeedButton
            // 
            this.drawRectangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawRectangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawRectangleSpeedButton.Image")));
            this.drawRectangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawRectangleSpeedButton.Name = "drawRectangleSpeedButton";
            this.drawRectangleSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.drawRectangleSpeedButton.Text = "DrawRectangleButton";
            this.drawRectangleSpeedButton.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
            // 
            // EllipseButton
            // 
            this.EllipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("EllipseButton.Image")));
            this.EllipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(29, 24);
            this.EllipseButton.Text = "EllipseButton";
            this.EllipseButton.Click += new System.EventHandler(this.EllipseButton_Click);
            // 
            // CircleButton
            // 
            this.CircleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CircleButton.Image = ((System.Drawing.Image)(resources.GetObject("CircleButton.Image")));
            this.CircleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CircleButton.Name = "CircleButton";
            this.CircleButton.Size = new System.Drawing.Size(29, 24);
            this.CircleButton.Text = "CircleButton";
            this.CircleButton.Click += new System.EventHandler(this.CircleButton_Click);
            // 
            // TriangleButton
            // 
            this.TriangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TriangleButton.Image = ((System.Drawing.Image)(resources.GetObject("TriangleButton.Image")));
            this.TriangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TriangleButton.Name = "TriangleButton";
            this.TriangleButton.Size = new System.Drawing.Size(29, 24);
            this.TriangleButton.Text = "TriangleButton";
            this.TriangleButton.Click += new System.EventHandler(this.TriangleButton_Click);
            // 
            // SquareButton
            // 
            this.SquareButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SquareButton.Image = ((System.Drawing.Image)(resources.GetObject("SquareButton.Image")));
            this.SquareButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SquareButton.Name = "SquareButton";
            this.SquareButton.Size = new System.Drawing.Size(29, 24);
            this.SquareButton.Text = "SquareButton";
            this.SquareButton.Click += new System.EventHandler(this.SquareButton_Click);
            // 
            // LineButton
            // 
            this.LineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LineButton.Image = ((System.Drawing.Image)(resources.GetObject("LineButton.Image")));
            this.LineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(29, 24);
            this.LineButton.Text = "LineButton";
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // DoubleCrossedCircle
            // 
            this.DoubleCrossedCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DoubleCrossedCircle.Image = ((System.Drawing.Image)(resources.GetObject("DoubleCrossedCircle.Image")));
            this.DoubleCrossedCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DoubleCrossedCircle.Name = "DoubleCrossedCircle";
            this.DoubleCrossedCircle.Size = new System.Drawing.Size(29, 24);
            this.DoubleCrossedCircle.Text = "DoubleCrossedCircle";
            this.DoubleCrossedCircle.Click += new System.EventHandler(this.DoubleCrossedCircle_Click);
            // 
            // CrossedCircle
            // 
            this.CrossedCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CrossedCircle.Image = ((System.Drawing.Image)(resources.GetObject("CrossedCircle.Image")));
            this.CrossedCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CrossedCircle.Name = "CrossedCircle";
            this.CrossedCircle.Size = new System.Drawing.Size(29, 24);
            this.CrossedCircle.Text = "CrossedCircle";
            this.CrossedCircle.Click += new System.EventHandler(this.CrossedCircle_Click);
            // 
            // TripleCrossedCircle
            // 
            this.TripleCrossedCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TripleCrossedCircle.Image = ((System.Drawing.Image)(resources.GetObject("TripleCrossedCircle.Image")));
            this.TripleCrossedCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TripleCrossedCircle.Name = "TripleCrossedCircle";
            this.TripleCrossedCircle.Size = new System.Drawing.Size(29, 24);
            this.TripleCrossedCircle.Text = "TripleCrossedCircle";
            this.TripleCrossedCircle.Click += new System.EventHandler(this.TripleCrossedCircle_Click);
            // 
            // CrossedCircleWithTwoLines
            // 
            this.CrossedCircleWithTwoLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CrossedCircleWithTwoLines.Image = ((System.Drawing.Image)(resources.GetObject("CrossedCircleWithTwoLines.Image")));
            this.CrossedCircleWithTwoLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CrossedCircleWithTwoLines.Name = "CrossedCircleWithTwoLines";
            this.CrossedCircleWithTwoLines.Size = new System.Drawing.Size(29, 24);
            this.CrossedCircleWithTwoLines.Text = "CrossedCircleWithTwoLines";
            this.CrossedCircleWithTwoLines.Click += new System.EventHandler(this.CrossedCircleWithTwoLines_Click);
            // 
            // CrossedCircleWithFourLines
            // 
            this.CrossedCircleWithFourLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CrossedCircleWithFourLines.Image = ((System.Drawing.Image)(resources.GetObject("CrossedCircleWithFourLines.Image")));
            this.CrossedCircleWithFourLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CrossedCircleWithFourLines.Name = "CrossedCircleWithFourLines";
            this.CrossedCircleWithFourLines.Size = new System.Drawing.Size(29, 24);
            this.CrossedCircleWithFourLines.Text = "CrossedCircleWithFourLines";
            this.CrossedCircleWithFourLines.Click += new System.EventHandler(this.CrossedCircleWithFourLines_Click);
            // 
            // CrossedRectangle
            // 
            this.CrossedRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CrossedRectangle.Image = ((System.Drawing.Image)(resources.GetObject("CrossedRectangle.Image")));
            this.CrossedRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CrossedRectangle.Name = "CrossedRectangle";
            this.CrossedRectangle.Size = new System.Drawing.Size(29, 24);
            this.CrossedRectangle.Text = "CrossedRectangle";
            this.CrossedRectangle.Click += new System.EventHandler(this.CrossedRectangle_Click);
            // 
            // TripleCrossedRectangle
            // 
            this.TripleCrossedRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TripleCrossedRectangle.Image = ((System.Drawing.Image)(resources.GetObject("TripleCrossedRectangle.Image")));
            this.TripleCrossedRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TripleCrossedRectangle.Name = "TripleCrossedRectangle";
            this.TripleCrossedRectangle.Size = new System.Drawing.Size(29, 24);
            this.TripleCrossedRectangle.Text = "TripleCrossedRectangle";
            this.TripleCrossedRectangle.Click += new System.EventHandler(this.TripleCrossedRectangle_Click);
            // 
            // CrossedTriangle
            // 
            this.CrossedTriangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CrossedTriangle.Image = ((System.Drawing.Image)(resources.GetObject("CrossedTriangle.Image")));
            this.CrossedTriangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CrossedTriangle.Name = "CrossedTriangle";
            this.CrossedTriangle.Size = new System.Drawing.Size(29, 24);
            this.CrossedTriangle.Text = "CrossedTriangle";
            this.CrossedTriangle.Click += new System.EventHandler(this.CrossedTriangle_Click);
            // 
            // TripleCrossedTrapezoid
            // 
            this.TripleCrossedTrapezoid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TripleCrossedTrapezoid.Image = ((System.Drawing.Image)(resources.GetObject("TripleCrossedTrapezoid.Image")));
            this.TripleCrossedTrapezoid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TripleCrossedTrapezoid.Name = "TripleCrossedTrapezoid";
            this.TripleCrossedTrapezoid.Size = new System.Drawing.Size(29, 24);
            this.TripleCrossedTrapezoid.Text = "TripleCrossedTrapezoid";
            this.TripleCrossedTrapezoid.Click += new System.EventHandler(this.TripleCrossedTrapezoid_Click);
            // 
            // DoubleCrossedRhombus
            // 
            this.DoubleCrossedRhombus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DoubleCrossedRhombus.Image = ((System.Drawing.Image)(resources.GetObject("DoubleCrossedRhombus.Image")));
            this.DoubleCrossedRhombus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DoubleCrossedRhombus.Name = "DoubleCrossedRhombus";
            this.DoubleCrossedRhombus.Size = new System.Drawing.Size(29, 24);
            this.DoubleCrossedRhombus.Text = "DoubleCrossedRhombus";
            this.DoubleCrossedRhombus.Click += new System.EventHandler(this.DoubleCrossedRhombus_Click);
            // 
            // ExamShape
            // 
            this.ExamShape.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExamShape.Image = ((System.Drawing.Image)(resources.GetObject("ExamShape.Image")));
            this.ExamShape.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExamShape.Name = "ExamShape";
            this.ExamShape.Size = new System.Drawing.Size(29, 24);
            this.ExamShape.Text = "ExamShape";
            this.ExamShape.Click += new System.EventHandler(this.ExamShape_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(0, 55);
            this.viewPort.Margin = new System.Windows.Forms.Padding(5);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(924, 444);
            this.viewPort.TabIndex = 4;
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 521);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Draw";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
		private System.Windows.Forms.ToolStripButton drawRectangleSpeedButton;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripButton EllipseButton;
        private System.Windows.Forms.ToolStripButton ColorDialog;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripButton GroupPrimitivesButton;
        private System.Windows.Forms.ToolStripButton UngroupPrimitivesButton;
        private System.Windows.Forms.ToolStripButton CircleButton;
        private System.Windows.Forms.ToolStripButton TriangleButton;
        private System.Windows.Forms.ToolStripButton SquareButton;
        private System.Windows.Forms.ToolStripMenuItem OpenButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsAPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton DoubleCrossedCircle;
        private System.Windows.Forms.ToolStripButton LineButton;
        private System.Windows.Forms.ToolStripButton CrossedCircle;
        private System.Windows.Forms.ToolStripButton TripleCrossedCircle;
        private System.Windows.Forms.ToolStripButton CrossedCircleWithTwoLines;
        private System.Windows.Forms.ToolStripButton CrossedCircleWithFourLines;
        private System.Windows.Forms.ToolStripButton CrossedRectangle;
        private System.Windows.Forms.ToolStripButton TripleCrossedRectangle;
        private System.Windows.Forms.ToolStripButton CrossedTriangle;
        private System.Windows.Forms.ToolStripButton TripleCrossedTrapezoid;
        private System.Windows.Forms.ToolStripButton DoubleCrossedRhombus;
        private System.Windows.Forms.ToolStripButton ExamShape;
    }
}
