//using LiveFeedback.Core.Entities;

//namespace LiveFeedback.Core.Interfaces.IRepositories

//{
//    public interface IMyImageRepository: IRepository<MyImage>
//    {
//        Task<IEnumerable<MyImage>> GetAllAsync();
//        Task<IEnumerable<MyImage>> GetImagesByUserIdAsync(int userId);
//        Task<IEnumerable<MyImage>> GetImagesByQuestionIdAsync(int questionId);




//    }
//}
using LiveFeedback.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Core.Interfaces.IRepositories
{
    public interface IMyImageRepository : IRepository<MyImage>
    {
        Task<IEnumerable<MyImage>> GetAllAsync();
        Task<IEnumerable<MyImage>> GetImagesByUserIdAsync(int userId);
        Task<IEnumerable<MyImage>> GetImagesByQuestionIdAsync(int questionId);
    }
}