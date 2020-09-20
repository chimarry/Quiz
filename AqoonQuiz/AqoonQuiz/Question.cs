using System.Collections.Generic;

namespace AqoonQuiz
{
    /// <summary>
    /// Holds information about the question
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Textual content of the question.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// List of possibles answers to the question.
        /// </summary>
        public List<Answer> Answers { get; set; }
    }
}
