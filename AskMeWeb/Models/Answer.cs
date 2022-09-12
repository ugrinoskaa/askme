using System;
using System.ComponentModel.DataAnnotations;

namespace AskMeWeb.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String content { get; set; }

        public int votes { get; set; } = 0;

        public DateTime createdAt { get; set; } = DateTime.Now;

        public virtual Question question { get; set; }

        public void upVote()
        {
            votes++;
        }

        public void downVote()
        {
            votes--;
        }
    }

  
}

