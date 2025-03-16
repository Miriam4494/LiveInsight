﻿using System.ComponentModel.DataAnnotations;

namespace LiveFeedback.API.PostModels
{
    public class FeedbackPostModel
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public int QuestionId { get; set; }
    }
}
