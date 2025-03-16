//using LiveFeedback.Core.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;


//namespace LiveFeedback.Core.Interfaces.IServices
//{
//    public interface IUserService
//    {
//        Task<IEnumerable<User>> GetAllUsersAsync();
//        Task<User> GetUserByIdAsync(int id);
//        Task AddUserAsync(User user);
//        Task UpdateUserAsync(User user);
//        Task DeleteUserAsync(int id);
//    }
//}
using LiveFeedback.Core.Entities;
using LiveFeedback.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Core.Interfaces.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> AddUserAsync(UserDTO userDto);
        Task<UserDTO> UpdateUserAsync(int id, UserDTO userDto);
        Task<bool> DeleteUserAsync(int id);
        Task<UserDTO> AuthenticateAsync(string email, string password);  // הוספת הפונקציה הזו
        Task<UserDTO> GetUserByEmailAsync(string email);


    }

}

