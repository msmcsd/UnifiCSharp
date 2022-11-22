
namespace UnifiCommands.Logging
{
    public class Logging
    {
        private readonly ILogger _logger;

        public Logging(ILogger logger)
        {
            _logger = logger;
        }

        public void LogInfo(string message) => _logger.LogInfo(message);
        
        public void LogError(string message) => _logger.LogError(message);
        
        public void LogProgress(string message) => _logger.LogProgress(message);
        
        public void LogCommand(string message, bool newLine) => _logger.LogCommand(message, newLine);

    }
}
