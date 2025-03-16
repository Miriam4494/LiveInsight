//using LiveFeedback.Core.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;


//namespace LiveFeedback.Core.Interfaces.IServices
//{
//    public interface IMyImageService
//    {
//        Task<IEnumerable<MyImage>> GetAllImagesAsync();
//        Task<MyImage> GetImageByIdAsync(int id);
//        Task AddImageAsync(MyImage image);
//        Task UpdateImageAsync(MyImage image);
//        Task DeleteImageAsync(int id);
//        Task<IEnumerable<MyImage>> GetImagesByUserIdAsync(int userId);
//        Task<IEnumerable<MyImage>> GetImagesByQuestionIdAsync(int questionId);
//    }
//}

using LiveFeedback.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Core.Interfaces.IServices
{
    public interface IMyImageService
    {
        Task<IEnumerable<MyImageDTO>> GetAllImagesAsync();
        Task<MyImageDTO> GetImageByIdAsync(int id);
        Task<MyImageDTO> AddImageAsync(MyImageDTO imageDto);
        Task<MyImageDTO> UpdateImageAsync(int id, MyImageDTO imageDto);
        Task<bool> DeleteImageAsync(int id);
        Task<IEnumerable<MyImageDTO>> GetImagesByUserIdAsync(int userId);
        Task<IEnumerable<MyImageDTO>> GetImagesByQuestionIdAsync(int questionId);
    }
}
