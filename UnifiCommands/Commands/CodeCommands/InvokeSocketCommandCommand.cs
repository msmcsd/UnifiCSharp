using System;
using System.Threading.Tasks;
using UnifiCommands.Logging;
using UnifiCommands.Socket;
using WebSocketSharp;

namespace UnifiCommands.Commands.CodeCommands
{
    public class InvokeSocketCommandCommand : Command
    {
        private readonly string _behavior;
        private readonly string _parameter;

        public InvokeSocketCommandCommand(string behavior, string parameter, ILogger logger) : base(logger)
        {
            _behavior = behavior;
            _parameter = parameter;
        }

        public override void LogParameters()
        {
            LogCommand($"behavior: \"{_behavior}\"", $"parameter: \"{_parameter}\"");
        }

        protected override Task<string> ExecuteCommand()
        {
            string channelName = GetChannelName();
            if (string.IsNullOrEmpty(channelName))
            {
                return Task.FromResult("");
            }

            using (var ws = new WebSocket($"{SocketCommandServer.SocketUrl}/{channelName}"))
            {
                ws.OnError += (sender, e) => { Logger.LogError(e.Message); };
                ws.OnOpen += (sender, e) => 
                { 
                    SocketCommandServer.Instance.LogMessage($"InvokeSocketCommand connected to channel '{channelName}'");
                    ws.Send(_parameter);
                    SocketCommandServer.Instance.LogMessage($"Sent data '{_parameter}' to channel '{channelName}'");
                };
                ws.Connect();
                //Thread.Sleep(2000);
                //ws.Send(_parameter);
                //Logger.LogInfo($"Sent {_parameter} to channel {channelName}");
            }

            return Task.FromResult("");
        }

        private string GetChannelName()
        {
            string channel = "";
            try
            {
                string typeName = $"UnifiCommands.Socket.Behaviors.{_behavior}Behavior, UnifiCommands";
                Type t = Type.GetType(typeName);

                if (t == null)
                {
                    Logger.LogError($"Unable to find type {_behavior}Behavior");
                    return null;
                }

                channel = (string)t.GetField("ChannelName", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).GetValue(null);
            }
            catch (Exception e)
            {
                Logger.LogError($"Unable to find behavior {e}");
            }
            return channel;
        }
    }
}
