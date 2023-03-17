using System;
using System.Windows.Forms;
using Unifi.Consoles;
using UnifiCommands.Logging;

namespace Unifi.Logging
{
    /// <summary>
    /// Logger used for desktop app.
    /// </summary>
    internal class DesktopLogger : ILogger
    {
        private readonly TextBoxConsole _console;

        public DesktopLogger(RichTextBox textBox)
        {
            if (textBox == null) throw new ArgumentNullException($"{nameof(textBox)} is null.");

            _console = new TextBoxConsole(textBox);
        }

        public void LogInfo(string message)
        {
            _console.LogInfo(message);
        }

        public void LogError(string message)
        {
            _console.LogError(message);
        }

        public void LogProgress(string message)
        {
            _console.LogProgress(message);
        }

        public void LogCommand(string message, bool newLine)
        {
            _console.LogCommand(message, newLine);
        }

        public void SendReport(string report) { }
    }
}
