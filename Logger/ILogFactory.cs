namespace Core.Logs
{
    internal interface ILogFactory
    {
        public void AddLog(string message, LogType logType, LogLevel logLevel);
        
        public LogLevel MinLogLevel { get; }
    }
}
