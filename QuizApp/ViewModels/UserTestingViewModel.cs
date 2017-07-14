using System.Collections.Generic;
using QuizApp.Models;

namespace QuizApp.ViewModels
{
    public class UserTestingViewModel
    {
        public Test Test { get; set; }
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
