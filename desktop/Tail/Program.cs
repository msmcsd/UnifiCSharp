using System;
using System.Windows.Forms;

namespace Tail
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length >= 3)
            {
                bool ret = Enum.TryParse(args[1], true, out TailType tailType);
                if (!ret) tailType = TailType.Filter;
                Application.Run(new TailForm(args[0], tailType, args[2]));
            }
            else
            {
                Application.Run(new TailForm());
            }
        }
    }
}
