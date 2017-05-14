using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Models;
using QuizApp.Repository;

namespace QuizApp.Controllers
{
    public class TestController : Controller
    {

        IRepository<Test> testRepository;
        IRepository<Genre> genreRepository;

        public TestController()
        {
            genreRepository = new GenreRepository();
            testRepository = new TestRepository();
        }

        public IActionResult Index()
        {
            var tests = testRepository.getAll();
            return View(tests);
        }

        public IActionResult Details(int Id)
        {
            var test = testRepository.Get(Id);
            return View();
        }
    }
}
