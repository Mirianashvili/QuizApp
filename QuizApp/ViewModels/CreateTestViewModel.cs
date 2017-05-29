using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.ViewModels
{
    public class CreateTestViewModel
    {
        [Required]
        public int GenreId { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public int Difficulty { get; set; }
    }
}
