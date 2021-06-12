using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Repository;
using QuizApp.ViewModels;

namespace QuizApp.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IRepository<Answer> answerRepository;

        public AnswerController()
        {
            answerRepository = new AnswerRepository();
        }

        public IActionResult Edit(int Id)
        {
            var answer = answerRepository.Get(Id);

            if (answer == null)
            {
                return RedirectToAction("Error", "Answer");
            }

            return View(answer);
        }

        [HttpPost]
        public IActionResult Edit(EditAnswerViewModel vm)
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}