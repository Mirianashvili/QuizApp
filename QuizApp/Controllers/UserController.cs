using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Extensions;
using QuizApp.Filters;
using QuizApp.Models;
using QuizApp.Repository;
using QuizApp.ViewModels;

namespace QuizApp.Controllers
{
    [UserFilter]
    public class UserController : Controller
    {
        private IRepository<Test> testRepository;
        private IRepository<Question> questionRepository;
        private IRepository<Answer> answerRepository;
        private IRepository<TestResult> testResultRepository;

        public UserController()
        {
            testRepository = new TestRepository();
            questionRepository = new QuestionRepository();
            answerRepository = new AnswerRepository();
            testResultRepository = new TestResultReposiory();
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
        public IActionResult BeginTest(int Agree, int TestId)
        {
            if (HttpContext.Session.Get<Testing>("testing") != null)
            {
                return RedirectToAction("ClearSession", "User");
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

            //int userAnswerCounter = 0;
            
            for (int i = 0; i < nvm.Answers.Length; i++)
            {
                int answerId = nvm.Answers[i];
                var answer = answers.Where(x => x.Id == answerId).FirstOrDefault();
                if (answer != null)
                {
                    if (answer.Correct == 1) 
                    {
                        testing.Score += question.Score;
                        break;
                    }
                }
            }
            /*
            int questionAnswerCounter = answers.Where(x => x.Correct == 1).ToList().Count;

            if (userAnswerCounter == questionAnswerCounter)
            {
                testing.Score += question.Score;
            }*/

            testing.Position++;

            HttpContext.Session.Set<Testing>("testing", testing);

            if (testing.Position == testing.Questions.Count)
            {
                return RedirectToAction("Result", "User");
            }

            UserTestingViewModel vm = new UserTestingViewModel();
            vm.Question = testing.Questions[testing.Position];
            vm.Answers = answerRepository.getAll()
                .Where(x => x.QuestionId == vm.Question.Id)
                .ToList();

            return View(vm);
        }

        public IActionResult Result()
        {
            if (HttpContext.Session.Get<Testing>("testing") == null)
            {
                return RedirectToAction("Index", "User");
            }

            Testing testing = HttpContext.Session.Get<Testing>("testing");
            HttpContext.Session.Set<Testing>("testing", null);

            if (testing.SaveRatings == 1)
            {
                TestResult testResult = new TestResult
                {
                    TestId = testing.Test.Id,
                    UserId = HttpContext.Session.Get<User>("login-user").Id,
                    Result = testing.Score,
                };
                testResultRepository.Add(testResult);
            }

            ViewBag.Score = testing.Score;
            return View();
        }

        public IActionResult ClearSession()
        {
            HttpContext.Session.Set("testing", "");
            return RedirectToAction("Index", "User");
        }

        public IActionResult UserResult()
        {
            var user = HttpContext.Session.Get<User>("login-user");
            var testResult = testResultRepository.getAll().Where(x => x.UserId == user.Id).ToList();
            var tests = new List<Test>();

            foreach (var item in testResult)
            {
                var test = testRepository.Get(item.TestId);
                tests.Add(test);
            }

            HomeTestResultViewModel vm = new HomeTestResultViewModel
            {
                TestResult = testResult,
                Test = tests
            };

            return View(vm);
        }
    }
}