using System;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public String Title { get; set; }
    }
}
