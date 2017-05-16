
namespace QuizApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Title { get; set; }
        public int Score { get; set; }
    }
}
