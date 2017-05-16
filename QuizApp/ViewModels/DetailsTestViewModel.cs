using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Models;

namespace QuizApp.ViewModels
{
    public class DetailsTestViewModel
    {
        public Test Test { get; set; }
        public List<Question> Question { get; set; }
    }
}
