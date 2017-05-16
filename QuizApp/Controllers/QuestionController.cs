using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Repository;
using QuizApp.Models;
using QuizApp.ViewModels;

namespace QuizApp.Controllers
{
    public class QuestionController : Controller
    {
        IRepository<Question> questionRepository;
        IRepository<Answer> answerRepository;
        IRepository<Test> testRepository;
        IRepository<Genre> genreRepository;

        public QuestionController()
        {
            genreRepository = new GenreRepository();
            answerRepository = new AnswerRepository();
            questionRepository = new QuestionRepository();
            testRepository = new TestRepository();
        }

        public IActionResult Index()
        {
            var questions = questionRepository.getAll();
            return View(questions);
        }

        public IActionResult Details(int Id)
        {
            var question = questionRepository.Get(Id);

            if (question == null)
            {
                return RedirectToAction("Error", "Question");
            }

            var test = testRepository.Get(question.TestId);
            var genre = genreRepository.Get(test.GenreId);
            var answers = answerRepository.getAll()
                .Where(x => x.QuestionId == question.Id)
                .ToList();

            DetailsQuestionViewModel vm = new DetailsQuestionViewModel
            {
                Question = question,
                Test = test,
                Genre = genre,
                Answer = answers
            };

            return View(vm);
        }

        public IActionResult Create()
        {
            var tests = testRepository.getAll();
            return View(tests);
        }

        [HttpPost]
        public IActionResult Create(CreateQuestionViewModel vm)
        {

            var question = questionRepository.getAll()
                .Where(x => x.Title.ToLower().Contains(vm.Title))
                .FirstOrDefault();

            if (question != null)
            {
                ModelState.AddModelError("errors", "ასეთი კითხვა უკვე არსებობს");
                var tests = testRepository.getAll();
                return View(tests);
            }

            question = new Question()
            {
                TestId = vm.TestId,
                Title = vm.Title,
                Score = vm.Score
            };
            
            questionRepository.Add(question);

            var questionId = questionRepository.getAll()
                .FirstOrDefault(x => x.Title.Equals(question.Title)).Id;

            List<Answer> answers = new List<Answer>();

            for (int i = 0; i < vm.Titles.Length; i++)
            {

                int find = 0;

                foreach(var index in vm.Corrects)
                {
                    if (index == i)
                    {
                        find = 1 - find;
                        break;
                    }
                }

                Answer answer = new Answer
                {
                    QuestionId = questionId,
                    Title = vm.Titles[i],
                    Correct = find
                };
                
                answers.Add(answer);
            }

            foreach (var answer in answers)
            {
                answerRepository.Add(answer);
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}
