using AqoonQuiz.ErrorHandling;
using Serilog;
using System;
using System.IO;

namespace AqoonQuiz
{
    /// <summary>
    /// A factory responsible for resolving interface dependencies.
    /// </summary>
    public static class DependencyFactory
    {
        /// <summary>
        /// Creates logger.
        /// </summary>
        /// <returns>Configured IAqoonLogger object</returns>
        public static IAqoonLogger GetLogger()
        {
            LoggerConfiguration logConfig = new LoggerConfiguration();
            return new SerilogAqoonLogger(logConfig.MinimumLevel.Information()
                                            .WriteTo.File($"log-{DateTime.Now}.txt")
                                            .CreateLogger());
        }
    }
}
