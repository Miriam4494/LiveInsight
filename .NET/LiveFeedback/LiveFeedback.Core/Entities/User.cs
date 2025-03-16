//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;

//namespace LiveFeedback.Core.Entities
//{
//    public class User
//    {
//        [Key]
//            public int Id { get; set; }
//            public string UserName { get; set; }
//            public string Email { get; set; } 
//            public string PasswordHash { get; set; } 
//            public int Points { get; set; } 
//            public int RoleId { get; set; } 
//            public List<Role> UserRoles { get; set; }
//            public List<Question> Questions { get; set; }
//            //public List<Image> Images { get; set; } 
//            //public ICollection<AdminLog> AdminLogs { get; set; } = new List<AdminLog>();


//    }
//}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LiveFeedback.Core.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int Points { get; set; }
        public int RoleId { get; set; }
        public List<Role> UserRoles { get; set; }
        public List<Question> Questions { get; set; }
    }
}

