using System.ComponentModel.DataAnnotations;

namespace QuizApp.ViewModels
{
    public class CreateGenreViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
