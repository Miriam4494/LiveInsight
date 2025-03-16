//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LiveFeedback.Core.DTOs
//{
//    public class QuestionDTO
//    {
//        [Required]
//        public string Content { get; set; }

//        public string Title { get; set; }

//        public int UserId { get; set; }

//        public List<int>? Images { get; set; } // אם תרצה לשלוח רשימה של תמונות, תוכל לשנות את זה ל-List<Guid> או לפי הצורך.
//    }

//}
using LiveFeedback.Core.Entities;

namespace LiveFeedback.Core.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<MyImageDTO> Images { get; set; } // מכיל את האובייקטים המלאים של התמונות
        public UserDTO User { get; set; } // מכיל את המשתמש המלא
        public List<Feedback> Feedbacks { get; set; }

    }

}


