using System;

namespace UnifiCommands.Logging
{
    public interface ILogger
    {
        void LogInfo(string message);

        void LogError(string message);
        
        void LogProgress(string message);

        void LogCommand(string message, bool newLine);

        void LogSocketMessage(Type type, string message);
        
        void LogSocketError(Type type, string message);

        void SendReport(string json);
    }
}
