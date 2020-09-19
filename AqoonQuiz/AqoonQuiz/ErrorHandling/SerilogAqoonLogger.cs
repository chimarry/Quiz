using Serilog;
using Serilog.Events;
using System;
using static AqoonQuiz.ErrorHandling.IAqoonLogger;

namespace AqoonQuiz.ErrorHandling
{
    /// <summary>
    /// Responsible for logging events using Serilog.
    /// </summary>
    public class SerilogAqoonLogger : IAqoonLogger
    {
        private readonly ILogger logger;

        /// <summary>
        /// Initializes custom logger with Serilog interface.
        /// </summary>
        /// <param name="logger"></param>
        public SerilogAqoonLogger(ILogger logger)
            => (this.logger) = (logger);

        /// <summary>
        /// Logs specified message based on the provided log level.
        /// <see cref="LoggingLevel"/>
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="level">The level that will be mapped to Serilog' logging level object<see cref="LogEventLevel"/></param>
        public void Log(string message, LoggingLevel level)
            => logger.Write(Map(level), message);


        private LogEventLevel Map(LoggingLevel level) =>
           level switch
           {
               LoggingLevel.Information => LogEventLevel.Information,
               LoggingLevel.Warning => LogEventLevel.Warning,
               LoggingLevel.Error => LogEventLevel.Error,
               _ => LogEventLevel.Verbose
           };
    }
}
