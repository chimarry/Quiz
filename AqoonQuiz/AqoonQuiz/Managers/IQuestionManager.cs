using System.Collections.Generic;
using System.Threading.Tasks;

namespace AqoonQuiz.Managers
{
    public interface IQuestionManager
    {
        Task<List<Question>> GetQuestions(int count);
    }
}
