using QuizApp.Models;
using System.Collections.Generic;

namespace QuizApp.ViewModels
{
    public class HomeTestResultViewModel
    {
        public List<TestResult> TestResult { get; set; }
        public List<Test> Test { get; set; }
        public List<User> User { get; set; }
    }
}
