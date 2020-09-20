using System;
using System.Collections.Generic;
using System.Text;

namespace AqoonQuiz
{
    public class Quiz
    {
        public static int TotalNumberOfQuestions = Properties.Default.TotalNumberOfQuestions;

        public List<Question> Questions { get; set; }

        public Question CurrentQuestion { get; set; }

        public (int correct, int wrong) Score { get; set; }

    }
}
