//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LiveFeedback.Core.DTOs
//{
//    public class UserDTO
//    {
//        [Required]
//        public string UserName { get; set; }

//        [Required]
//        [EmailAddress]
//        public string Email { get; set; }

//        [Required]
//        public string PasswordHash { get; set; }

//        public int Points { get; set; }

//        public int RoleId { get; set; }
//    }

//}
namespace LiveFeedback.Core.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int Points { get; set; }
        public int RoleId { get; set; }
    }
}
