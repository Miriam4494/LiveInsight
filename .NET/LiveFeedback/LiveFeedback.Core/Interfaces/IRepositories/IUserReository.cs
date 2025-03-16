//using LiveFeedback.Core.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace LiveFeedback.Core.Interfaces.IRepositories
//{ 
//    public interface IUserRepository : IRepository<User>
//    {
//        Task<IEnumerable<User>> GetUsersWithDetailsAsync();
//    }
//}
using LiveFeedback.Core.DTOs;
using LiveFeedback.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Core.Interfaces.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<UserDTO>> GetUsersWithDetailsAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);  // הוספת הפונקציה הזו

    }
}
