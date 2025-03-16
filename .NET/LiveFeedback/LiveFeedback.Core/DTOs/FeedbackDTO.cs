//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LiveFeedback.Core.DTOs
//{
//    public class FeedbackDTO
//    {
//        [Required]
//        public string Content { get; set; }

//        public int? QuestionId { get; set; }
//    }

//}
using System.ComponentModel.DataAnnotations;

namespace LiveFeedback.Core.DTOs
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
    }
}
