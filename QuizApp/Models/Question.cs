
namespace QuizApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        // RANGE(1,5)
        public int Score { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
