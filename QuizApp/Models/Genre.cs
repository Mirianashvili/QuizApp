using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public String Title { get; set; }
    }
}
