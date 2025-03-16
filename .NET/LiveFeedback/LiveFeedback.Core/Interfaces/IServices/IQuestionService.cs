//using LiveFeedback.Core.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;


//namespace LiveFeedback.Core.Interfaces.IServices
//{
//    public interface IQuestionService
//    {
//        Task<IEnumerable<Question>> GetAllQuestionsAsync();
//        Task<Question> GetQuestionByIdAsync(int id);
//        Task AddQuestionAsync(Question question);
//        Task UpdateQuestionAsync(Question question);
//        Task DeleteQuestionAsync(int id);
//        Task<IEnumerable<Question>> GetQuestionsByTitleAsync(string title);
//        Task<IEnumerable<Question>> GetQuestionsByContentAsync(string content);
//    }
//}
using LiveFeedback.Core.DTOs;
using LiveFeedback.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Core.Interfaces.IServices
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDTO>> GetAllQuestionsAsync();
        Task<QuestionDTO> GetQuestionByIdAsync(int id);
        Task<QuestionDTO> AddQuestionAsync(QuestionDTO questionDto);
        Task<QuestionDTO> UpdateQuestionAsync(int id, QuestionDTO questionDto);
        Task<bool> DeleteQuestionAsync(int id);
        Task<IEnumerable<QuestionDTO>> GetQuestionsByTitleAsync(string title);
        Task<IEnumerable<QuestionDTO>> GetQuestionsByContentAsync(string content);
    }

}
