
namespace UnifiCommands.CommandInfo
{
    /// <summary>
    /// Represents a command as provided in Json.
    /// </summary>
    public class FullCommandInfo : BaseCommandInfo
    {
        /// <summary>
        /// Arguments for a Dos command, or constructor parameters of a Code command.
        /// </summary>
        public string Arguments { get; set; }

        /// <summary>
        /// Path to load the icon from for a task in the task bar.
        /// </summary>
        public string IconSourcePath { get; set; }

        /// <summary>
        /// The icon index of resources embedded in the DLL/EXE in IconSourcePath.
        /// </summary>
        public int IconIndex { get; set; }

        /// <summary>
        /// A keyword to check from the result string of the command. The command is successful if the keyword exists in command result.
        /// </summary>
        public string KeywordForSuccess { get; set; }

        public bool ShowInReport { get; set; }

        /// <summary>
        /// Minimizes the DOS window when a command is running so the DOS window does not block the main window.
        /// </summary>
        public bool MinimizeWindow { get; set; }

        /// <summary>
        /// Indicates if the command should only run in Windows 8 or later.
        /// </summary>
        public bool Win8OrLater { get; set; }

        /// <summary>
        /// Callback to run during the execution of a command. Works with DOS commands only.
        /// For example, a callback that updates DLL version when Updater is running.
        /// </summary>
        public string Callback { get; set; }

        /// <summary>
        /// Used to instantiate different kind of commands.
        /// </summary>
        public CommandType Type { get; set; } = CommandType.Dos;

        /// <summary>
        /// Shows/Hides command in Batch Task. So a command doesn't have to be removed from Json if not used.
        /// </summary>
        public bool BatchEnabled { get; set; } = true;

        /// <summary>
        /// Indicates if the return value of the command is being checked in a batch command.
        /// </summary>
        public bool FireAndForget { get; set; }

        /// <summary>
        /// Determines if the command is visible in UI.
        /// </summary>
        public bool Visible { get; set; } = true;

        /// <summary>
        /// Determines if the command is visible on Dev or Test VM or both.
        /// </summary>
        public ShowCommandOnMachine ShowOnMachine { get; set; } = ShowCommandOnMachine.All;

        public override string ToString() => DisplayText;

        public string FullCommand => $">> {Command} {Arguments}";

        /// <summary>
        /// Checks if the command is for 64-bit or 32-bit.
        /// Values: x86 or x64. Empty string means the command is for both platforms.
        /// </summary>
        public string Platform { get; set; } = "";

        /// <summary>
        /// Runs the command either as a regular user or as an admin.
        /// </summary>
        public RunAsUserType RunAs { get; set; } = RunAsUserType.Admin;

        /// <summary>
        /// Used when command group is Variable only to define variable name.
        /// </summary>
        public string Variable { get; set; }

        /// <summary>
        /// Used when command group is Variable only to define variable value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Redirects output of DOS prompt to Console or not.
        /// When opening a new DOS prompt, instead of running a DOS command, set this to false;
        /// </summary>
        public bool RedirectOutputToConsole { get; set; } = true;

        /// <summary>
        /// Determines if a new DOS windows will be open or not.
        /// Only set in code for Task bar commands for now, not in JSON.
        /// </summary>
        public bool CreateNewWindow { get; set; }

        /// <summary>
        /// Source for the values of the runtime variables.
        /// 
        /// When AppType is
        /// Desktop: This is the reference to the main form. Used for calling functions in the form thru reflection.
        ///          The property is assigned once when JsonCommandsProvider is instantiated.
        /// Web:     An ExpandoObject created to hold the info passed from React client. The property names of the
        ///          object would be the same as the function names in the main desktop form.
        ///          The property is assigned on a per user-action basis where the ExpandoObject is created and assigned.
        ///      
        /// This field is not set in JSON.
        /// </summary>
        public object VariableValueSource { get; set; }

    }
}
