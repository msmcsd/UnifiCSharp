using UnifiCommands.CommandInfo;
using UnifiCommands.Commands;

namespace UnifiCommands.Report
{
    public class ReportItem
    {
        public string Category { get; set; }

        public string Test { get; set; }

        public bool Passed { get; set; }

        public FullCommandInfo Command { get; set; }
    }
}
