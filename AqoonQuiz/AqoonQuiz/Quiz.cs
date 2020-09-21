using AqoonQuiz.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqoonQuiz
{
    public class Quiz
    {
        private const int previousQuestionIndex = 1;

        public static int TotalNumberOfQuestions = Properties.Default.TotalNumberOfQuestions;

        private int correctAnswersCount { get; set; }
        private int wrongAnswersCount { get; set; }

        public Question CurrentQuestion
        {
            get => Questions?.FirstOrDefault();
        }
        private List<Question> Questions { get; set; }

        private Quiz()
        {

        }

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
        /// 
        /// </summary>
        /// <param name="chosenAnswersContent"></param>
        /// <returns></returns>
        public Answer ChooseAnswer(string chosenAnswersContent)
        {
            try
            {
                Answer correctAnswer = CurrentQuestion.Answers.First(x => x.IsCorrect);
                if (correctAnswer.Content == chosenAnswersContent)
                    correctAnswersCount++;
                else
                    wrongAnswersCount++;
                return correctAnswer;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }


    }
}
