using System.Windows.Forms;

namespace UnifiCommands.Logging
{
    public class ConsoleLogger
    {
        //private static TextBoxConsole _console;
        private static RichTextBox _textBox;

        public static void Initialize(RichTextBox textBox)
        {
            //_console = new TextBoxConsole(textBox);
            _textBox = textBox;
        }

        public static void Log(string message)
        {
            _textBox.AppendText(message);
        }
    }
}
