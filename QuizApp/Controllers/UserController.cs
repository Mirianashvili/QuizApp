using Microsoft.AspNetCore.Mvc;
using System.Linq;
using QuizApp.Filters;
using QuizApp.Models;
using QuizApp.Repository;
using QuizApp.ViewModels;
using QuizApp.Extensions;

namespace QuizApp.Controllers
{
    [UserFilter]
    public class UserController : Controller
    {
        IRepository<Test> testRepository;
        IRepository<Question> questionRepository;
        IRepository<Answer> answerRepository;

        public UserController()
        {
            testRepository = new TestRepository();
            questionRepository = new QuestionRepository();
            answerRepository = new AnswerRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tests()
        {
            var tests = testRepository.getAll();
            UserTestsViewModel vm = new UserTestsViewModel
            {
                Tests = tests
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Test(int Id)
        {
            var test = testRepository.Get(Id);

            if (test == null)
            {
                return RedirectToAction("Tests", "User");
            }
            
            return View(test);
        }

        [HttpPost]
        public IActionResult BeginTest(int Agree,int TestId)
        {
            if (HttpContext.Session.Get<Testing>("testing") != null)
            {
                HttpContext.Session.Set("testing", null);
            }

            var MyTest = testRepository.Get(TestId);

            if (MyTest == null)
            {
                return RedirectToAction("Index", "User");
            }

            Testing testing = new Testing()
            {
                Test = MyTest,
                SaveRatings = Agree,
                Position = 0
            };

            testing.Questions = questionRepository.getAll()
                .Where(x => x.TestId == MyTest.Id)
                .ToList();
            
            HttpContext.Session.Set<Testing>("testing", testing);

            return RedirectToAction("Testing", "User");
        }

        [HttpGet]
        public IActionResult Testing()
        {

            if (HttpContext.Session.Get<Testing>("testing") == null)
            {
                return RedirectToAction("Index", "User");
            }

            Testing testing = HttpContext.Session.Get<Testing>("testing");

            UserTestingViewModel vm = new UserTestingViewModel();
            vm.Question = testing.Questions[testing.Position];
            vm.Answers = answerRepository.getAll()
                .Where(x => x.QuestionId == vm.Question.Id)
                .ToList();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Next(NextQuestionViewModel nvm)
        {

            if (HttpContext.Session.Get<Testing>("testing") == null)
            {
                return RedirectToAction("Index", "User");
            }

            //check user's answer 
            Testing testing = HttpContext.Session.Get<Testing>("testing");

            if (nvm.Answers == null)
            {
                UserTestingViewModel uvm = new UserTestingViewModel();
                uvm.Question = testing.Questions[testing.Position];
                uvm.Answers = answerRepository.getAll()
                    .Where(x => x.QuestionId == uvm.Question.Id)
                    .ToList();

                return View(uvm);
            }

      
            var question = testing.Questions[testing.Position];
            var answers = answerRepository.getAll()
                .Where(x => x.QuestionId == question.Id)
                .ToList();

            int userAnswerCounter = 0;

            for (int i = 0; i < nvm.Answers.Length; i++)
            {
                int answerId = nvm.Answers[i];
                var answer = answers.Where(x => x.Id == answerId).FirstOrDefault();
                if (answer != null)
                {
                    userAnswerCounter++;
                }
            }

            int questionAnswerCounter = answers.Where(x=>x.Correct == 1).ToList().Count;

            if (userAnswerCounter == questionAnswerCounter)
            {
                testing.Score += question.Score;
            }

            testing.Position++;

            if (testing.Position == testing.Questions.Count)
            {
                return RedirectToAction("Result", "User");
            }

            HttpContext.Session.Set<Testing>("testing",testing);

            UserTestingViewModel vm = new UserTestingViewModel();
            vm.Question = testing.Questions[testing.Position];
            vm.Answers = answerRepository.getAll()
                .Where(x => x.QuestionId == vm.Question.Id)
                .ToList();

            return View(vm);
        }

        [TestingFilter]
        public IActionResult Result()
        {
            //if (HttpContext.Session.Get<Testing>("testing") == null)
            //{
            //    return RedirectToAction("Index", "User");
            //}

            Testing testing = HttpContext.Session.Get<Testing>("testing");
            HttpContext.Session.Set<Testing>("testing", null);

            ViewBag.Score = testing.Score;
            return View();
        }

    }
}
