//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;

//namespace LiveFeedback.Core.Entities
//{
//    public class Question
//    {
//        [Key]
//        public int Id { get; set; }
//        public string? Title { get; set; } 
//        public string Content { get; set; } 
//        public DateTime CreatedAt { get; set; } 
//        public int UserId { get; set; } 
//        public List<MyImage>? Images { get; set; }
//        public List<Feedback> Feedbacks { get; set; } 
//    }

//}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveFeedback.Core.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }


        public List<MyImage>? Images { get; set; }

        public List<Feedback> Feedbacks { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
