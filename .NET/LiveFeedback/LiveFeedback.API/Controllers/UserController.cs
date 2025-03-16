using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LiveFeedback.API.PostModels;
using LiveFeedback.Core.DTOs;
using LiveFeedback.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using LiveFeedback.Core.Entities;

namespace LiveFeedback.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // מנהל יכול לראות את כל המשתמשים
        [HttpGet]

       // [Authorize(Roles = "Admin")] // רק למנהל
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // כל משתמש יכול לראות רק את עצמו
        [HttpGet("{id}")]
        [Authorize] // כל משתמש יכול לגשת לנתוניו
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            // בדיקה אם המשתמש הוא זה שמבצע את הבקשה (למשתמשים רגילים בלבד)
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentUserId != id)
            {
                return Unauthorized(new { message = "אין לך הרשאה לצפות במידע זה" });
            }

            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // כל משתמש יכול להוסיף את עצמו
        [HttpPost]
        [Authorize] // כל משתמש יכול להוסיף את עצמו
        public async Task<ActionResult<UserDTO>> AddUser([FromBody] UserPostModel userPostModel)
        {
            var userDto = _mapper.Map<UserDTO>(userPostModel);
            userDto = await _userService.AddUserAsync(userDto);
            if (userDto == null) return BadRequest();

            return CreatedAtAction(nameof(GetUser), new { id = userDto.Id }, userDto);
        }
        //public async Task<ActionResult<UserDTO>> AddUser([FromBody] UserPostModel userPostModel)
        //{
        //    var user = _mapper.Map<User>(userPostModel); // ממפה ל-User (Entity)
        //    user = await _userService.AddUserAsync(user); // הוספה לשרת

        //    var userDto = _mapper.Map<UserDTO>(user); // ממפה חזרה ל-DTO
        //    if (userDto == null) return BadRequest();

        //    return CreatedAtAction(nameof(GetUser), new { id = userDto.Id }, userDto); // מחזיר את ה-ID של ה-User
        //}


        // כל משתמש יכול לעדכן רק את עצמו
        [HttpPut("{id}")]
        [Authorize] // כל משתמש יכול לעדכן את עצמו
        public async Task<ActionResult<UserDTO>> UpdateUser(int id, [FromBody] UserPostModel userPostModel)
        {
            // בדיקה אם המשתמש הוא זה שמבצע את הבקשה
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentUserId != id)
            {
                return Unauthorized(new { message = "אין לך הרשאה לעדכן מידע זה" });
            }

            var userDto = _mapper.Map<UserDTO>(userPostModel);
            userDto = await _userService.UpdateUserAsync(id, userDto);
            if (userDto == null) return NotFound();

            return Ok(userDto);
        }

        // כל משתמש יכול למחוק את עצמו
        [HttpDelete("{id}")]
        [Authorize] // כל משתמש יכול למחוק את עצמו
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            // בדיקה אם המשתמש הוא זה שמבצע את הבקשה
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentUserId != id)
            {
                return Unauthorized(new { message = "אין לך הרשאה למחוק את המידע הזה" });
            }

            var deleted = await _userService.DeleteUserAsync(id);
            if (!deleted) return NotFound();

            return Ok(true);
        }
    }
}

//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using LiveFeedback.API.PostModels;
//using LiveFeedback.Core.DTOs;
//using LiveFeedback.Core.Interfaces.IServices;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace LiveFeedback.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IUserService _userService;
//        private readonly IMapper _mapper;

//        public UserController(IUserService userService, IMapper mapper)
//        {
//            _userService = userService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
//        {
//            var users = await _userService.GetAllUsersAsync();
//            return Ok(users);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<UserDTO>> GetUser(int id)
//        {
//            var user = await _userService.GetUserByIdAsync(id);
//            if (user == null) return NotFound();
//            return Ok(user);
//        }

//        [HttpPost]
//        public async Task<ActionResult<UserDTO>> AddUser([FromBody] UserPostModel userPostModel)
//        {
//            var userDto = _mapper.Map<UserDTO>(userPostModel);
//            userDto = await _userService.AddUserAsync(userDto);
//            if (userDto == null) return BadRequest();

//            return CreatedAtAction(nameof(GetUser), new { id = userDto.Id }, userDto);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult<UserDTO>> UpdateUser(int id, [FromBody] UserPostModel userPostModel)
//        {
//            var userDto = _mapper.Map<UserDTO>(userPostModel);
//            userDto = await _userService.UpdateUserAsync(id, userDto);
//            if (userDto == null) return NotFound();

//            return Ok(userDto);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult<bool>> DeleteUser(int id)
//        {
//            var deleted = await _userService.DeleteUserAsync(id);
//            if (!deleted) return NotFound();

//            return Ok(true);
//        }
//    }
//}

//using LiveFeedback.Core.Entities;
//using LiveFeedback.Core.DTOs;
//using LiveFeedback.Services;
//using Microsoft.AspNetCore.Mvc;
//using LiveFeedback.Core.Interfaces.IServices;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using LiveFeedback.API.PostModels;

//namespace LiveFeedback.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IUserService _userService;

//        public UserController(IUserService userService)
//        {
//            _userService = userService;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
//        {
//            var users = await _userService.GetAllUsersAsync();
//            return Ok(users);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<UserDTO>> GetUser(int id)
//        {
//            var user = await _userService.GetUserByIdAsync(id);
//            if (user == null) return NotFound();
//            return Ok(user);
//        }

//        [HttpPost]
//        public async Task<ActionResult> AddUser(UserPostModel userPostModel)
//        {
//            var user = new User
//            {
//                UserName = userPostModel.UserName,
//                Email = userPostModel.Email,
//                PasswordHash = userPostModel.PasswordHash,
//                Points = userPostModel.Points,
//                RoleId = userPostModel.RoleId
//            };

//            await _userService.AddUserAsync(user);
//            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult> UpdateUser(int id, UserPostModel userPostModel)
//        {
//            var user = await _userService.GetUserByIdAsync(id);
//            if (user == null) return NotFound();

//            user.UserName = userPostModel.UserName;
//            user.Email = userPostModel.Email;
//            user.Points = userPostModel.Points;
//            user.RoleId = userPostModel.RoleId;

//            await _userService.UpdateUserAsync(user);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeleteUser(int id)
//        {
//            await _userService.DeleteUserAsync(id);
//            return NoContent();
//        }
//    }
//}
