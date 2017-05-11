using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.ViewModels
{
    public class CreateQuestionViewModel
    {
        public int QuizId { get; set; }
        public int Score { get; set; }
        public string Title { get; set; }
    }
}
