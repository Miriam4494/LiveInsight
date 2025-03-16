//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LiveFeedback.Core.DTOs
//{
//    public class PermissionDTO
//    {
//        [Required]
//        public string PermissionName { get; set; }

//        public string Description { get; set; }
//    }

//}
using System.ComponentModel.DataAnnotations;

namespace LiveFeedback.Core.DTOs
{
    public class PermissionDTO
    {
        [Required]
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
    }
}
