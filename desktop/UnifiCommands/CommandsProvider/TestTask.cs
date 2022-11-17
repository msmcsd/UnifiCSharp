using System.Collections.Generic;
using UnifiCommands.Commands;

namespace UnifiCommands.CommandsProvider
{
    // Represents a single task, like "Install Protect", as defined in XML.
    public class TestTask
    {
        public string Name { get; set; }

        /// <summary>
        /// Used to group similar commands, which are populated in the same list box.
        /// </summary>
        public CommandGroup CommandGroup { get; set; }

        // /// <summary>
        // /// Indicates if the batch command list is visible in UI.
        // /// </summary>
        // public bool BatchVisible { get; set; }

        /// <summary>
        /// Determines if the task is visible on Dev or Test VM or both.
        /// </summary>
        public CommandInfo.ShowCommandOnMachine ShowTaskOnMachine { get; set; } = CommandInfo.ShowCommandOnMachine.All;

        /// <summary>
        /// List of commands for this command group.
        /// </summary>
        public List<CommandInfo> Commands { get; set; }
    }

    public enum CommandGroup
    {
        Install,
        Dos,
        Taskbar,
        Download,
        Rollback,
        Batch,
        Function,
        Variable
    }

    public enum InstallerType
    {
        Msi,
        CyUpgrade,
        Bootstrapper
    }
}
