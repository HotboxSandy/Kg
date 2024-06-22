using System;
using System.Windows.Forms;

namespace Draw
{
    /// <summary>
    /// Class with the entry point of the program.
    /// </summary>
    internal sealed class Program
	{
        /// <summary>
        /// Entry point. Creates and displays the main form of the program.
        /// </summary>
        [STAThread]
		private static void Main(string[] args) //MainMethod
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		} //end of MainMethod
		
	}
}
