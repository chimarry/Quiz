using AqoonQuiz.ErrorHandling;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static AqoonQuiz.ErrorHandling.IAqoonLogger;

namespace AqoonQuiz.Managers
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IAqoonLogger aqoonLogger;
        private const int questionOffset = 0;
        private const int correctAnswerOffset = 1;

        public QuestionManager(IAqoonLogger aqoonLogger)
        {
            this.aqoonLogger = aqoonLogger;
        }

        /// <summary>
        /// Returns list of questions with shuffled answers from csv file marked as embedded resource.
        /// </summary>
        /// <param name="count">Number of questions to return.</param>
        /// <returns></returns>
        public async Task<List<Question>> GetQuestions(int count)
        {
            try
            {
                List<Question> questions = new List<Question>();
                // Read questions from the file
                using StreamReader reader = new StreamReader(StreamUtil.GetStream("Questions.csv"));
                while (!reader.EndOfStream)
                    questions.Add(ParseQuestion(await reader.ReadLineAsync()));

                // Randomize questions
                questions.Shuffle();

                return questions.Take(count)
                                .ToList();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return ProcessException(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return ProcessException(ex.Message);
            }
        }

        private Question ParseQuestion(string line)
        {
            string[] questionAndAnswers = line.Split(",");
            Question question = new Question()
            {
                Content = questionAndAnswers[questionOffset],
                Answers = new List<Answer>(questionAndAnswers.Skip(correctAnswerOffset + 1)
                                                             .Select(x => new Answer()
                                                             {
                                                                 Content = x,
                                                                 IsCorrect = false
                                                             }))
            };
            Answer correctAnswer = new Answer
            {
                Content = questionAndAnswers[correctAnswerOffset],
                IsCorrect = true
            };
            question.Answers.Add(correctAnswer);

            // Randomize answers
            question.Answers.Shuffle();
            return question;
        }

        private List<Question> ProcessException(string message)
        {
            aqoonLogger.Log(message, LoggingLevel.Error);
            return new List<Question>();
        }
    }
}
