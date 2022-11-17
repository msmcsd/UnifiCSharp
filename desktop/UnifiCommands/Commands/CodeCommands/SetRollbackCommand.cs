using System.Threading.Tasks;
using Microsoft.Win32;
using UnifiCommands.Logging;

namespace UnifiCommands.Commands.CodeCommands
{
    public class SetRollbackCommand : Command
    {
        private readonly string _rollbackCategory;
        private readonly string _rollbackPosition;

        public SetRollbackCommand(string rollbackCategory, string rollbackPosition, ILogger logger) : base(logger)
        {
            _rollbackCategory = rollbackCategory;
            _rollbackPosition = rollbackPosition;
        }

        public override void LogParameters()
        {
            LogCommand($"Rollback category = {_rollbackCategory}", $"Rollback position = {_rollbackPosition}");
        }

        protected override Task<string> ExecuteCommand()
        {
            SetRegistryKey("Rollback", _rollbackPosition);
            SetRegistryKey("RollbackCategory", _rollbackCategory);

            return Task.FromResult("");
        }

        private void SetRegistryKey(string key, string value)
        {
            Registry.LocalMachine.OpenSubKey(Variables.RegistryKey, true)?.SetValue(key, value);

            Logger.LogInfo($"Set {Variables.RegistryKey}\\{key} to '{value}'.");
        }
    }
}