using System;
using System.Diagnostics;
using System.Threading.Tasks;
using UnifiCommands.Logging;

namespace UnifiCommands.Commands.CodeCommands
{
    public class ServiceStateCommand : Command
    {
        private readonly string _serviceName;
        private readonly ServiceStateType _serviceState;

        public ServiceStateCommand(string serviceName, string serviceState, ILogger logger): base(logger)
        {
            _serviceName = serviceName;
            _serviceState = (ServiceStateType)Enum.Parse(typeof(ServiceStateType), serviceState);
        }

        public override void LogParameters()
        {
            LogCommand($"Service name: {_serviceName}", $"Service state: {_serviceState}");
        }

        protected override Task<string> ExecuteCommand()
        {
            string result = "";
            switch (_serviceState)
            {
                case ServiceStateType.ServiceState:
                    result = GetServiceStatus();
                    break;
                case ServiceStateType.AmpplState:
                    result = GetAmpplStatus();
                    break;
            }

            Logger.LogInfo(result);

            return Task.FromResult(result);
        }


        private string GetServiceStatus()
        {
            string status = RunCommand($"sc query {_serviceName} | find \"STATE\"");

            if (!string.IsNullOrEmpty(status))
            {
                string[] result = status.Trim().Split(' ');
                return result[result.Length - 1];
            }

            return "NOT FOUND";
        }

        private string GetAmpplStatus()
        {
            string status = RunCommand($"sc qprotection {_serviceName} | find \"{_serviceName}\"");

            if (!string.IsNullOrEmpty(status))
            {
                int i = status.IndexOf(":");
                if (i >= 0)
                {
                    status = status.Substring(i + 1).Trim();
                    if (status.EndsWith(".")) status = status.Substring(0, status.Length - 1);
                }
                return status;
            }

            return "NOT FOUND";
        }

        private string RunCommand(string command)
        {
            string result = "";
            Process p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c {command}",
                    CreateNoWindow = true,
                    RedirectStandardOutput= true,
                    UseShellExecute = false
                }
            };

            try
            {
                p.Start();
                result = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }
    }

    public enum ServiceStateType 
    {
        ServiceState,
        AmpplState
    }
}
