//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LiveFeedback.Core.Entities
//{
//    public class MyImage
//    {
//        [Key]
//        public int Id { get; set; }
//        public string ImageUrl { get; set; } 
//        public DateTime CreatedAt { get; set; }
//        public int UserId { get; set; } 
//        public int? QuestionId { get; set; } 
//        //public Question? Question { get; set; }
//    }

//}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveFeedback.Core.Entities
{
    public class MyImage
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }


        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}




