//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LiveFeedback.Core.Entities
//{
//    public class Permission
//    {
//        [Key]
//        public int Id { get; set; }
//        public string PermissionName { get; set; }
//        public string Description { get; set; }

//    }

//}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveFeedback.Core.Entities
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PermissionName { get; set; }

        public string Description { get; set; }

        public List<Role> Roles { get; set; }

        //[ForeignKey(nameof(RoleId))]
        //public int RoleId { get; set; }
        //public Role Role { get; set; }
    }
}
