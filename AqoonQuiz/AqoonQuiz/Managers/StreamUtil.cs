using AqoonQuiz.ErrorHandling;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using static AqoonQuiz.ErrorHandling.IAqoonLogger;

namespace AqoonQuiz.Managers
{
    /// <summary>
    /// Contains helper methods for working with streams
    /// </summary>
    public static class StreamUtil
    {
        private static readonly IAqoonLogger aqoonLogger = DependencyFactory.GetLogger();

        /// <summary>
        /// Returns stream based on resource name
        /// </summary>
        /// <param name="name">Name of the stream' resource</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns>Initialized stream</returns>
        public static Stream GetStream(string name)
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                return assembly.GetManifestResourceStream(assembly.GetManifestResourceNames().First(x => x.Contains(name)));
            }
            catch (InvalidOperationException ex)
            {
                aqoonLogger.Log(string.Format("%s: %s", "Could not found this resource " + ex.Message), LoggingLevel.Error);
                throw;
            }
        }
    }
}
