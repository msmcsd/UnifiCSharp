using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UnifiCommands.Logging;
using UnifiCommands.Socket;

namespace UnifiCommands.Commands.CodeCommands
{
    public class InvokeSocketCommandCommand : Command
    {
        private readonly string _channel;
        private readonly SocketMessageType _socketMessageType;
        private readonly string _socketMessage;

        public InvokeSocketCommandCommand(string channel, string socketMessageType, string socketMessage, ILogger logger) : base(logger)
        {
            _channel = channel;
            Enum.TryParse(socketMessageType, true, out _socketMessageType);
            _socketMessage = socketMessage;
        }

        public override void LogParameters()
        {
            LogCommand($"channel: \"{_channel}\"", $"data: \"{_socketMessage}\"");
        }

        protected override Task<string> ExecuteCommand()
        {
            string channelName = GetChannelName();
            if (string.IsNullOrEmpty(channelName))
            {
                return null;
            }

            SocketMessage m = new SocketMessage
            {
                Type = _socketMessageType,
                Data = _socketMessage
            };
            SocketUtils.SendCommandToChannel(channelName, JsonConvert.SerializeObject(m), (sender, e) => Logger.LogError(e.Message));

            return Task.FromResult("");
        }

        private string GetChannelName()
        {
            string channel = "";
            try
            {
                string typeName = $"UnifiCommands.Socket.Behaviors.{_channel}Behavior, UnifiCommands";
                Type t = Type.GetType(typeName);

                if (t == null)
                {
                    Logger.LogError($"Unable to find type {_channel}Behavior");
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
