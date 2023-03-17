using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unifi.Logging;
using UnifiCommands.Logging;

namespace UnifiDesktop.Logging
{
    internal class ServiceStatusLogger : DesktopLogger
    {
        public ServiceStatusLogger(RichTextBox textBox) : base(textBox)
        {
        }

        public new void LogCommand(string message, bool newLine)
        {
            
        }
    }
}
