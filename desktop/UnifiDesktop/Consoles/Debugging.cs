using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Unifi.Consoles
{
    internal class DebugListener : TraceListener
    {
        private readonly TextBoxConsole _console;

        public DebugListener(RichTextBox target)
        {
            if (target == null) new ArgumentNullException($"{nameof(target)} is null");

            _console = new TextBoxConsole(target);
        }

        public override void Write(string message)
        {
            WriteLine(message);
        }

        public override void WriteLine(string message)
        {
            _console.LogInfo(message);
        }

        public override void WriteLine(string type, string message)
        {
            _console.LogInfo($"[{type}] {message}");
        }

        public override void Fail(string message)
        {
            _console.LogError(message);
        }
    }
}


