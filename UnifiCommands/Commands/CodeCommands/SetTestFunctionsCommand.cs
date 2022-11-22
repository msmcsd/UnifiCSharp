using System.Threading.Tasks;
using Microsoft.Win32;
using UnifiCommands.Logging;

namespace UnifiCommands.Commands.CodeCommands
{
    public class SetTestFunctionsCommand : Command
    {
        private readonly string _functionsToRun;

        public SetTestFunctionsCommand(string functionsToRun, ILogger logger) : base(logger)
        {
            _functionsToRun = functionsToRun;
        }

        public override void LogParameters()
        {
            LogCommand($"Functions to run = {_functionsToRun}");
        }

        protected override Task<string> ExecuteCommand()
        {
            SetRegistryKey("TestFunctionsToRun", _functionsToRun);

            return Task.FromResult("");
        }

        private void SetRegistryKey(string key, string value)
        {
            Registry.LocalMachine.OpenSubKey(Variables.RegistryKey, true)?.SetValue(key, value);

            Logger.LogInfo($"Set {Variables.RegistryKey}\\{key} to {value}.");
        }
    }
}