
namespace QuizApp.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public int Correct { get; set; }
    }
}
