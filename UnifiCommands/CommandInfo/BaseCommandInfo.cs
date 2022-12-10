using System;

namespace UnifiCommands.CommandInfo
{
    public class BaseCommandInfo : ICloneable
    {
        /// <summary>
        /// Describes what the command does. This displays on UI.
        /// </summary>
        public string DisplayText { get; set; } = "";

        //public override string ToString() => DisplayText;

        /// <summary>
        /// Used by React client to identify which command to run. Since not all fields in CommandIno is sent to client,
        /// this property is used to look up the command info list and return the actual command info. This property is
        /// expected to be uniquie among all commands.
        /// </summary>
        //public string ApiMethod { get; set; }

        /// <summary>
        /// Clones the original command so the runtime variables do not get overwritten.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        public static ShowCommandOnMachine GetShowCommandOnMachine()
        {
            bool isDevMachine = Environment.MachineName.Equals("WindowsDev", StringComparison.InvariantCultureIgnoreCase);
            return isDevMachine ? ShowCommandOnMachine.Dev : ShowCommandOnMachine.Test;
        }
    }

    public enum CommandType
    {
        Dos = 0,
        Code = 1,
        Function = 2
    }

    [Flags]
    public enum ShowCommandOnMachine
    {
        Test = 1,
        Dev = 2,
        All = 3
    }

    public enum RunAsUserType
    {
        Admin,
        User
    }
}
