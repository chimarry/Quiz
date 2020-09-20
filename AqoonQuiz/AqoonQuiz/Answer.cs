namespace AqoonQuiz
{
    /// <summary>
    /// Holds information about the answer.
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Textual content of the answer.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Flag that indicates wheter answer is correct or not, 
        /// depending on the context.
        /// </summary>
        public bool IsCorrect { get; set; }
    }
}
