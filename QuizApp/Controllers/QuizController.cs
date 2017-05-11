using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Repository;
using QuizApp.ViewModels;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        IRepository<Genre> genreRepository;
        IRepository<Quiz> quizRepository;
        IRepository<Question> questionRepository;
        IRepository<Answer> answerRepository;

        public QuizController()
        {
            genreRepository = new InMemoryGenreRepository();
            quizRepository = new InMemoryQuizRepository();
            questionRepository = new InMemoryQuestionRepository();
        }

        public IActionResult Index()
        {
            var quizes = quizRepository.getAll();
            return View(quizes);
        }

        public IActionResult Details(int Id)
        {
            var quiz = quizRepository.Get(Id);

            if (quiz == null)
            {
                return RedirectToAction("Error", "Quiz");
            }

            var genre = genreRepository.Get(Id);

            ViewBag.genre = genre;
            return View(quiz);
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Create()
        {
            var genres = genreRepository.getAll();
            return View(genres);
        }

        [HttpPost]
        public IActionResult Create(CreateQuizViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Quiz");
            }

            Quiz quiz = new Quiz
            {
                Name = vm.Name,
                Difficulty = vm.Difficulty,
                GenreId = vm.GenreId
            };

            quizRepository.Add(quiz);

            return RedirectToAction("Index", "Quiz");
        }
    }
}
