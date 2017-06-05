using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Extensions;
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
