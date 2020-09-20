using System.Collections.Generic;

namespace AqoonQuiz.Managers
{
    public interface IQuestionManager
    {
        List<Question> GetQuestions(int count);
    }
}
