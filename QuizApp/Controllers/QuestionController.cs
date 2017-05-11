using Microsoft.AspNetCore.Mvc;
using QuizApp.ViewModels;
using QuizApp.Repository;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class QuestionController : Controller
    {
        IRepository<Question> questionRepository;

        public QuestionController()
        {
            questionRepository = new InMemoryQuestionRepository();
        }

        public IActionResult Create(CreateQuestionViewModel vm)
        {
            string message = "";

            if (!ModelState.IsValid)
            {
                message = "Wrong input";
            }
            else
            {
                Question question = new Question();
                question.QuizId = vm.QuizId;
                question.Score = vm.Score;
                question.Title = vm.Title;

                questionRepository.Add(question);
                message = "Add Question";
            }

            return Json(message);
        }
    }
}
