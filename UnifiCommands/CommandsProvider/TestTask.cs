using System.Collections.Generic;
using UnifiCommands.CommandInfo;

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
        public ShowCommandOnMachine ShowTaskOnMachine { get; set; } = ShowCommandOnMachine.All;

        /// <summary>
        /// List of commands for this command group.
        /// </summary>
        public List<FullCommandInfo> Commands { get; set; }

        /// <summary>
        /// Used to determine if the command group is needed in web client.
        /// This is to minimize the amount of data sent back to web client.
        /// </summary>
        public bool UsedInWeb => CommandGroup != CommandGroup.Function && CommandGroup != CommandGroup.Function && CommandGroup != CommandGroup.Variable;

        /// <summary>
        /// When CommandGroup is Install, ApiMethod will refer to this command group instead of individual command
        /// since all commands need to run. For individual command like Dos Command, each command will have its own ApiMethod.
        /// </summary>
        public string ApiMethod { get; set; }
    }

    public class WebTestTask
    {
        public string Name { get; set; }

        /// <summary>
        /// Used to group similar commands, which are populated in the same list box.
        /// </summary>
        public CommandGroup CommandGroup { get; set; }

        /// <summary>
        /// List of commands for this command group.
        /// </summary>
        public List<BaseCommandInfo> Commands { get; set; }
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
