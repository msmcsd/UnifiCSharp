using System;
using System.Windows.Forms;
using Unifi.Forms;

namespace Unifi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestToolV2());
        }
    }
}
