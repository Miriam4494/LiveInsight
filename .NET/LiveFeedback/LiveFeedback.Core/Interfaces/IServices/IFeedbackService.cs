//using LiveFeedback.Core.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace LiveFeedback.Core.Interfaces.IServices
//{
//    public interface IFeedbackService
//    {
//        Task<IEnumerable<Feedback>> GetAllFeedbacksAsync();
//        Task<Feedback> GetFeedbackByIdAsync(int id);
//        Task AddFeedbackAsync(Feedback feedback);
//        Task UpdateFeedbackAsync(Feedback feedback);
//        Task DeleteFeedbackAsync(int id);
//    }
//}
using LiveFeedback.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Core.Interfaces.IServices
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackDTO>> GetAllFeedbacksAsync();
        Task<FeedbackDTO> GetFeedbackByIdAsync(int id);
        Task<FeedbackDTO> AddFeedbackAsync(FeedbackDTO model);
        Task<FeedbackDTO> UpdateFeedbackAsync(int id, FeedbackDTO model);
        Task<bool> DeleteFeedbackAsync(int id);
    }
}
