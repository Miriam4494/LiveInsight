//using LiveFeedback.Core.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using LiveFeedback.Core.Interfaces.IRepositories;
//using LiveFeedback.Core.Interfaces.IServices;

//namespace LiveFeedback.Services.Services
//{
//    public class UserService : IUserService
//    {
//        private readonly IUserRepository _userRepository;

//        public UserService(IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }

//        public async Task<IEnumerable<User>> GetAllUsersAsync() => await _userRepository.GetUsersWithDetailsAsync();

//        public async Task<User> GetUserByIdAsync(int id) => await _userRepository.GetByIdAsync(id);

//        public async Task AddUserAsync(User user) => await _userRepository.AddAsync(user);

//        public async Task UpdateUserAsync(User user) => await _userRepository.UpdateAsync(user);

//        public async Task DeleteUserAsync(int id) => await _userRepository.DeleteAsync(id);
//    }
//}
using AutoMapper;
using LiveFeedback.Core.DTOs;
using LiveFeedback.Core.Entities;
using LiveFeedback.Core.Interfaces.IRepositories;
using LiveFeedback.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Identity;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDTO>>(users);
    }

    public async Task<UserDTO> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDTO>(user);
    }

    //public async Task<UserDTO> AddUserAsync(UserDTO userDto)
    //{
    //    var user = _mapper.Map<User>(userDto);
    //    await _userRepository.AddAsync(user);
    //    return _mapper.Map<UserDTO>(user);
    //}
    public async Task<UserDTO> AddUserAsync(UserDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);

        // הוספת חישוב PasswordHash (הסיסמה לא תישלח ישירות לבסיס הנתונים, אלא תעבור חישוב)
        var passwordHasher = new PasswordHasher<User>();
        user.PasswordHash = passwordHasher.HashPassword(user, userDto.PasswordHash);  // כאן מתבצע החישוב

        await _userRepository.AddAsync(user); // משתמש נוסף
        return _mapper.Map<UserDTO>(user);
    }
    //public async Task<User> AddUserAsync(User user)
    //{
    //    await _userRepository.AddAsync(user); // הוספה של ה-Entity
    //    return user; // מחזירים את ה-Entity לאחר ההוספה
    //}


    

    public async Task<UserDTO> UpdateUserAsync(int id, UserDTO userDto)
    {
        // מציאת התמונה לפי ה-ID בלבד
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return null;

        // ממפים את ה-DTO ל-Entity (MyImage), אבל לא משפיעים על ה-ID
        User entity = _mapper.Map<User>(userDto);

        // עושים Save רק לאחר המיפוי, לא מעדכנים את ה-ID
        await _userRepository.UpdateAsync(id, entity);  // אל תעביר את ה-ID כאן

        return _mapper.Map<UserDTO>(entity);
    }



    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return false;

        await _userRepository.DeleteAsync(id);
        return true;
    }
    public async Task<UserDTO> AuthenticateAsync(string email, string password)
    {
        // חיפוש משתמש על פי דואר אלקטרוני
        var user = await _userRepository.GetUserByEmailAsync(email);  // תחפש את המשתמש על פי הדוא"ל
        if (user == null) return null;  // אם לא נמצא משתמש, מחזירים null

        // השוואת הסיסמה
        var passwordHasher = new PasswordHasher<User>();  // שימוש ב-PasswordHasher לאימות הסיסמה
        var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

        if (passwordVerificationResult == PasswordVerificationResult.Failed)  // אם הסיסמה לא נכונה
        {
            return null;
        }

        // אם האימות הצליח, מחזירים את המידע על המשתמש
        return _mapper.Map<UserDTO>(user);
    }
    public async Task<UserDTO> GetUserByEmailAsync(string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        return _mapper.Map<UserDTO>(user);
    }


}


