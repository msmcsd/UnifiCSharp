using System;
using System.Drawing;
using System.Windows.Forms;

namespace Unifi.Consoles
{
    internal class TextBoxConsole
    {
        private readonly RichTextBox _console;

        public TextBoxConsole(RichTextBox console)
        {
            _console = console ?? throw new ArgumentNullException($"{nameof(console)} is null");
            _console.DoubleClick += (sender, e) => _console.Clear();
        }

        public void LogInfo(string message)
        {
            Log(message, false);
        }

        public void LogError(string message)
        {
            Log(message, true, Color.Red);
        }       
        
        public void LogProgress(string message)
        {
            Log(message, false, Color.Green);
        }

        public void LogCommand(string message, bool newLine = true)
        {
            Log(message, true, Color.RoyalBlue, newLine);
        }

        public void LogSocketMessage(Type type, string message)
        {
            Log($"[{type.Name}] {message}", false, Color.Green);
        }

        public void LogSocketError(Type type, string message)
        {
            LogError($"[{type.Name}] {message}");
        }

        public void Log(string message, bool bold, Color? color = null, bool newLine = false)
        {
            _console.BeginInvoke(new MethodInvoker(() =>
            {
                if (string.IsNullOrEmpty(message)) return;

                if (newLine && _console.Text.Length > 0)
                {
                    _console.AppendText(Environment.NewLine);
                }

                int consoleTextLength = _console.Text.Length;
                _console.AppendText(message + Environment.NewLine);
                _console.ScrollToCaret();

                _console.Select(consoleTextLength, message.Length);
                _console.SelectionFont = new Font(_console.Font, bold ? FontStyle.Bold : FontStyle.Regular);
                _console.SelectionColor = color ?? Color.Black;
            }));

        }
    }
}
