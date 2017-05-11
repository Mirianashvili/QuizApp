
namespace QuizApp.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string Name { get; set;}
        public int Difficulty { get; set; }
    }
}
