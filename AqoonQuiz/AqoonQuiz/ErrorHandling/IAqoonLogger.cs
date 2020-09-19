namespace AqoonQuiz.ErrorHandling
{
    public interface IAqoonLogger
    {
        void Log(string message, LoggingLevel level);

        enum LoggingLevel { Information, Warning, Error}
    }
}
