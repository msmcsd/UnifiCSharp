
namespace UnifiCommands.Socket
{
    public class SocketMessage
    {
        public SocketMessageType Type { get; set; }

        public string Data { get; set; }
    }

    public enum SocketMessageType
    {
        // For update interval
        SetInterval = 0,

        // For monitoring keywords
        SetMonitorState,
        DisplayKeywords,

        // For setting report
        SetReportType,

        // For requesting install parameters
        RequestInstallParameters,

        // For sending install parameters
        BroadcastInstallParameters
    }
}
