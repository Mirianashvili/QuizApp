using System.Collections.Generic;

namespace QuizApp.Models
{
    public class Testing
    {
        public int SaveRatings { get; set; }
        public int Score { get; set; }
        public int Position { get; set; }
        public Test Test { get; set; }
        public List<Question> Questions { get; set; }
    }
}
