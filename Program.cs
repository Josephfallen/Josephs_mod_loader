using System;
using System.Windows.Forms;

namespace NN_ModLoaderGUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());  // Make sure this is referring to MainForm, not Form1.
        }
    }
}
