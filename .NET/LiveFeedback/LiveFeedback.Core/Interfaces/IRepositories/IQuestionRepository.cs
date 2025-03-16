//using LiveFeedback.Core.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace LiveFeedback.Core.Interfaces.IRepositories

//{
//    public interface IQuestionRepository : IRepository<Question>
//    {
//        // פונקציה מיוחדת לקבלת שאלות עם תמונות ופידבקים
//        Task<IEnumerable<Question>> GetQuestionsWithDetailsAsync();

//        // פונקציה לחיפוש שאלות לפי כותרת
//        Task<IEnumerable<Question>> GetQuestionsByTitleAsync(string title);

//        // פונקציה לחיפוש שאלות לפי תוכן
//        Task<IEnumerable<Question>> GetQuestionsByContentAsync(string content);
//    }
//}
using LiveFeedback.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Core.Interfaces.IRepositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<IEnumerable<Question>> GetQuestionsWithDetailsAsync();
        Task<IEnumerable<Question>> GetQuestionsByTitleAsync(string title);
        Task<IEnumerable<Question>> GetQuestionsByContentAsync(string content);
    }
}

