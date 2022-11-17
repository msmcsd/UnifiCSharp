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

            bool ret = Enum.TryParse(args[1], true, out TailType tailType);
            if (!ret) tailType = TailType.Filter;
            Application.Run(args.Length < 3 ? new TailForm() : new TailForm(args[0], tailType, args[2]));
        }
    }
}
