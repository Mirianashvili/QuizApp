using System.ComponentModel.DataAnnotations;

namespace QuizApp.ViewModels
{
    public class AdminViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public string OldPassword { get; set; }

        [Required]
        [MinLength(6)]
        [Compare(nameof(Password), ErrorMessage = "არ ემთხვევა პაროლები")]
        public string RepeatPassword { get; set; }
    }
}