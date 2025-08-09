using UnityEngine;

namespace Core.Logs
{
    internal class NativeLogFactory : ILogFactory
    {
        private readonly LogLevel _minLogLevel;

        public LogLevel MinLogLevel => _minLogLevel;

        public NativeLogFactory(LogLevel minLogLevel)
        {
            _minLogLevel = minLogLevel;
        }
        
        public void AddLog(string log, LogType logType, LogLevel logLevel)
        {
            if(logLevel < _minLogLevel) return;
            
            switch (logType)
            {
                case LogType.Log:
                    Debug.Log(log);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(log);
                    break;
                case LogType.Error:
                    Debug.LogError(log);
                    break;
            }
        }

    }
}
