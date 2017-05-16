using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Models;
using QuizApp.Repository;
using QuizApp.ViewModels;

namespace QuizApp.Controllers
{
    public class TestController : Controller
    {

        IRepository<Test> testRepository;
        IRepository<Genre> genreRepository;
        IRepository<Question> questionRepository;

        public TestController()
        {
            genreRepository = new GenreRepository();
            testRepository = new TestRepository();
            questionRepository = new QuestionRepository();
        }

        public IActionResult Index()
        {
            var tests = testRepository.getAll();
            return View(tests);
        }

        public IActionResult Details(int Id)
        {
            var test = testRepository.Get(Id);
            var questions = questionRepository
                .getAll()
                .Where(x => x.TestId == test.Id)
                .ToList();

            DetailsTestViewModel vm = new DetailsTestViewModel
            {
                Test = test,
                Question = questions
            };

            return View(vm);
        }

        public IActionResult Search(string query)
        {
            var tests = testRepository.getAll()
                .Where(x => x.Title.ToLower().Contains(query.ToLower()))
                .ToList();
            return View(tests);
        }
    }
}
