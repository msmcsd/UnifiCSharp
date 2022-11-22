using System.Threading.Tasks;
using Microsoft.Win32;
using UnifiCommands.Logging;

namespace UnifiCommands.Commands.CodeCommands
{
    public class ShowRollbackPositionCommand : Command
    {
        public ShowRollbackPositionCommand(ILogger logger) : base(logger) { }

        public override void LogParameters()
        {
            string _rollbackPosition = Registry.LocalMachine.OpenSubKey(Variables.RegistryKey, true)?.GetValue("Rollback") as string;
            string _rollbackCategory = Registry.LocalMachine.OpenSubKey(Variables.RegistryKey, true)?.GetValue("RollbackCategory") as string;

            LogCommand($"Rollback category = {_rollbackCategory}", $"Rollback position = {_rollbackPosition}");
        }

        protected override Task<string> ExecuteCommand()
        {
            return Task.FromResult("");
        }
    }
}