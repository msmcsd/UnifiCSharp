using System.Windows.Forms;
using Unifi.Logging;

namespace UnifiDesktop.Logging
{
    /// <summary>
    /// This logger does not log to Console. Used by UpdateServiceState and UpdateFileVersion components.
    /// </summary>
    internal class UpdateIntervalLogger : DesktopLogger
    {
        public UpdateIntervalLogger(RichTextBox textBox) : base(textBox) { }

        public override void LogCommand(string message, bool newLine) { }

        public override void LogInfo(string message) { }

        public override void LogError(string message) { }

        public override void LogProgress(string message) { }
    }
}
