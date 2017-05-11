using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.ViewModels
{
    public class CreateQuizViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
    }
}
