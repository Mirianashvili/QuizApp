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
    public class AnswerController : Controller
    {
        IRepository<Answer> answerRepository;

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
