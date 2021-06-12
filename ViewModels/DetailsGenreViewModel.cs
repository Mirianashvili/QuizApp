using QuizApp.Models;
using System.Collections.Generic;

namespace QuizApp.ViewModels
{
    public class DetailsGenreViewModel
    {
        public Genre Genre { get; set; }
        public List<Test> Tests { get; set; }
    }
}
