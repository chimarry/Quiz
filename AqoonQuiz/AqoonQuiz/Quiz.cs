using AqoonQuiz.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqoonQuiz
{
    /// <summary>
    /// Encapsulates the information about a quiz game, like the 
    /// current score, list of questions etc.
    /// </summary>
    public class Quiz
    {
        private const int previousQuestionIndex = 1;

        public static int TotalNumberOfQuestions = Properties.Default.TotalNumberOfQuestions;

        public int CorrectAnswersCount { get; private set; }

        public int WrongAnswersCount { get; private set; }

        public Question CurrentQuestion
        {
            get => Questions?.FirstOrDefault();
        }

        private List<Question> Questions { get; set; }

        /// <summary>
        /// User cannot create this class using constructor, but
        /// using specified factory method <see cref="CreateQuiz(Quiz)"/>
        /// </summary>
        private Quiz()
        {

        }

        /// <summary>
        /// Indicates wheter the quiz is over or not.
        /// </summary>
        /// <returns>True if it is over, false if it is not.</returns>
        public bool IsOver() => Questions.Count() == 1;

        /// <summary>
        /// Async factory method used for creating new quiz or one 
        /// that is based on already configured quiz.
        /// </summary>
        /// <param name="configuredQuiz">Already configured quiz (optional)</param>
        /// <returns>Quiz</returns>
        public static async Task<Quiz> CreateQuiz(Quiz configuredQuiz = null)
        {
            if (configuredQuiz == null)
            {
                IQuestionManager questionManager = DependencyFactory.GetQuestionManager();
                Quiz quiz = new Quiz
                {
                    Questions = await questionManager.GetQuestions(TotalNumberOfQuestions),
                };
                return quiz;
            }
            else
            {
                configuredQuiz.Questions = configuredQuiz.Questions
                                                         .Skip(previousQuestionIndex)
                                                         .ToList();
                return configuredQuiz;
            }
        }

        /// <summary>
        /// From list of answers, choose one.
        /// </summary>
        /// <param name="chosenAnswersContent">Choosen answer's content</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns>Correct answer</returns>
        public Answer ChooseAnswer(string chosenAnswersContent)
        {
            try
            {
                Answer correctAnswer = CurrentQuestion.Answers.First(x => x.IsCorrect);
                if (correctAnswer.Content == chosenAnswersContent)
                    CorrectAnswersCount++;
                else
                    WrongAnswersCount++;
                return correctAnswer;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }


    }
}
