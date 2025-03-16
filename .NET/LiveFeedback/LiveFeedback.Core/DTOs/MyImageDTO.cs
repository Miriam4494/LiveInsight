//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LiveFeedback.Core.DTOs
//{
//    public class MyImageDTO
//    {
//        [Required]
//        public string ImageUrl { get; set; }

//        public int? QuestionId { get; set; }
//    }

//}
using System;

namespace LiveFeedback.Core.DTOs
{
    public class MyImageDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int QuestionId { get; set; }
    }
}
