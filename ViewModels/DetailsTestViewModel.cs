using System.Collections.Generic;
using QuizApp.Models;

namespace QuizApp.ViewModels
{
    public class DetailsTestViewModel
    {
        public Test Test { get; set; }
        public List<Question> Question { get; set; }
    }
}
