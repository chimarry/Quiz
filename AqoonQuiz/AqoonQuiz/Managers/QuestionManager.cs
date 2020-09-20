using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AqoonQuiz.Managers
{
    public class QuestionManager : IQuestionManager
    {
        private const int questionOffset = 0;
        private const int correctAnswerOffset = 1;

        /// <summary>
        /// Returns list of questions with shuffled answers from csv file marked as embedded resource.
        /// </summary>
        /// <param name="count">Number of questions to return.</param>
        /// <returns></returns>
        public List<Question> GetQuestions(int count)
        {
            // Read questions from the file
            List<Question> questions = new List<Question>();
            using StreamReader reader = new StreamReader(StreamUtil.GetStream("Questions.csv"));
            while (!reader.EndOfStream)
                questions.Add(ParseQuestion(reader.ReadLine()));

            // Randomize questions
            questions.Shuffle();

            return questions.Take(count)
                            .ToList();
        }

        private Question ParseQuestion(string line)
        {
            string[] questionAndAnswers = line.Split(",");
            Question question = new Question()
            {
                Content = questionAndAnswers[questionOffset],
                Answers = new List<Answer>(questionAndAnswers.Skip(correctAnswerOffset)
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
    }
}
