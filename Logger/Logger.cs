using Core.Logs;

namespace Core
{
    public static class Logger
    {
        private static readonly ILogFactory _logFactory;

        static Logger()
        {
            _logFactory = new NativeLogFactory(LogLevel.Internal);
        }

        public static void Log(string message, LogLevel level = LogLevel.Internal)
        {
            _logFactory.AddLog(message, LogType.Log, level);
        }
        
        public static void Warning(string message, LogLevel level = LogLevel.Internal)
        {
            _logFactory.AddLog(message, LogType.Warning, level);
        }
        
        public static void Error(string message, LogLevel level = LogLevel.Internal)
        {
            _logFactory.AddLog(message, LogType.Error, level);
        }
    }
}
