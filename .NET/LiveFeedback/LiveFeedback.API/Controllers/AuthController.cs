using AutoMapper;
using LiveFeedback.API.PostModels;
using LiveFeedback.Core.DTOs;
using LiveFeedback.Core.Entities;
using LiveFeedback.Core.Interfaces.IServices;
//using LiveFeedback.Service.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LiveFeedback.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly IUserService _userService; // נניח שיש לך מחלקה שמטפלת במשתמשים
        private readonly IMapper _mapper; // הוספת מאפר בשביל להמיר UserDTO ל-User

        public AuthController(JwtService jwtService, IUserService userService, IMapper mapper)
        {
            _jwtService = jwtService;
            _userService = userService;
            _mapper = mapper; // הוספת מאפר
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginRequest model)
        //{
        //    var userDto = await _userService.AuthenticateAsync(model.Email, model.Password);

        //    if (userDto == null)
        //    {
        //        return Unauthorized(new { message = "שם משתמש או סיסמה שגויים" });
        //    }

        //    // המרת ה-UserDTO ל-User
        //    var user = _mapper.Map<User>(userDto);

        //    var token = _jwtService.GenerateJwtToken(user);
        //    return Ok(new { Token = token });
        //}
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var userDto = await _userService.AuthenticateAsync(model.Email, model.Password);

            if (userDto == null)
            {
                return Unauthorized(new { message = "שם משתמש או סיסמה שגויים" });
            }

            // המרת ה-UserDTO ל-User
            var user = _mapper.Map<User>(userDto);

            var token = _jwtService.GenerateJwtToken(user);

            return Ok(new
            {
                Token = token,
                User = new
                {
                    user.Id,
                    user.Email,
                    user.RoleId
                }
            });
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserPostModel model)
        {
            var existingUser = await _userService.GetUserByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest(new { message = "האימייל כבר קיים במערכת" });
            }

            var userDto = _mapper.Map<UserDTO>(model);
            userDto.Points = 0; // ברירת מחדל
            userDto.RoleId = 2; // משתמש רגיל

            var createdUser = await _userService.AddUserAsync(userDto);
            if (createdUser == null)
            {
                return BadRequest(new { message = "הרשמה נכשלה" });
            }

            return Ok(new { message = "נרשמת בהצלחה!" });
        }
    }
}
//using AutoMapper;
//using LiveFeedback.Core.DTOs;
//using LiveFeedback.Core.Entities;
//using LiveFeedback.Core.Interfaces.IServices;
//using LiveFeedback.Service.Services;
//using Microsoft.AspNetCore.Identity.Data;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace LiveFeedback.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly JwtService _jwtService;
//        private readonly IUserService _userService;
//        private readonly IMapper _mapper;

//        public AuthController(JwtService jwtService, IUserService userService, IMapper mapper)
//        {
//            _jwtService = jwtService;
//            _userService = userService;
//            _mapper = mapper;
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] LoginRequest model)
//        {
//            var userDto = await _userService.AuthenticateAsync(model.Email, model.Password);

//            if (userDto == null)
//            {
//                return Unauthorized(new { message = "שם משתמש או סיסמה שגויים" });
//            }

//            var user = _mapper.Map<User>(userDto);  // המרת ה-UserDTO ל-User
//            var token = _jwtService.GenerateJwtToken(user);
//            return Ok(new { Token = token });
//        }

//        // פעולה לרישום משתמש
//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
//        {
//            // בדוק אם המשתמש כבר קיים
//            var existingUser = await _userService.GetUserByEmailAsync(model.Email);
//            if (existingUser != null)
//            {
//                return BadRequest(new { message = "המשתמש כבר קיים" });
//            }

//            // צור את המשתמש החדש
//            var userDto = new UserDTO
//            {
//                Email = model.Email,
//                PasswordHash = model.Password
//            };

//            var createdUser = await _userService.AddUserAsync(userDto);

//            if (createdUser == null)
//            {
//                return BadRequest(new { message = "לא הצלחנו ליצור את המשתמש" });
//            }

//            // המרת המשתמש ל-User בשביל להפיק את ה-JWT
//            var user = _mapper.Map<User>(createdUser);

//            // יצירת ה-JWT
//            var token = _jwtService.GenerateJwtToken(user);
//            return Ok(new { Token = token });
//        }
//    }
//}





