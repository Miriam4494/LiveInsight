//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LiveFeedback.Core.DTOs
//{
//    public class RoleDTO
//    {
//        [Required]
//        public string RoleName { get; set; }

//        public string Description { get; set; }
//    }

//}
using System;

namespace LiveFeedback.Core.DTOs
{
    public class RoleDTO
    {

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
    }
}

