
namespace UnifiCommands.Socket
{
    public class SocketMessage
    {
        public SocketMessageType Type { get; set; }

        public string Data { get; set; }
    }

    public enum SocketMessageType
    {
        StopMonitoringError = 0,
        DisplayError
    }
}
