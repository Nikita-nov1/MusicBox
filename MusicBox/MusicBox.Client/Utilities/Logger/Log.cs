using log4net;

namespace MusicBox.Utilities.Logger
{
    public class Log
    {
        protected ILog monitoringLogger;
        protected static ILog debugLogger;
        private static readonly Log Instance = new Log();

        private Log()
        {
            monitoringLogger = LogManager.GetLogger("MonitoringLogger");
            debugLogger = LogManager.GetLogger("DebugLogger");
        }

        /// <summary>
        /// Used to log Debug messages in an explicit Debug Logger.
        /// </summary>
        /// <param name="message">The object message to log.</param>
        public static void Debug(string message)
        {
            debugLogger.Debug(message);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log.</param>
        /// <param name="exception">The exception to log, including its stack trace. </param>
        public static void Debug(string message, System.Exception exception)
        {
            debugLogger.Debug(message, exception);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log.</param>
        public static void Info(string message)
        {
            Instance.monitoringLogger.Info(message);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log.</param>
        /// <param name="exception">The exception to log, including its stack trace. </param>
        public static void Info(string message, System.Exception exception)
        {
            Instance.monitoringLogger.Info(message, exception);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log.</param>
        public static void Warn(string message)
        {
            Instance.monitoringLogger.Warn(message);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log.</param>
        /// <param name="exception">The exception to log, including its stack trace. </param>
        public static void Warn(string message, System.Exception exception)
        {
            Instance.monitoringLogger.Warn(message, exception);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log.</param>
        public static void Error(string message)
        {
            Instance.monitoringLogger.Error(message);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log.</param>
        /// <param name="exception">The exception to log, including its stack trace. </param>
        public static void Error(string message, System.Exception exception)
        {
            Instance.monitoringLogger.Error(message, exception);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log.</param>
        public static void Fatal(string message)
        {
            Instance.monitoringLogger.Fatal(message);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log.</param>
        /// <param name="exception">The exception to log, including its stack trace. </param>
        public static void Fatal(string message, System.Exception exception)
        {
            Instance.monitoringLogger.Fatal(message, exception);
        }
    }
}