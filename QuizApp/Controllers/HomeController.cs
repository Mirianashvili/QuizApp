using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Repository;
using QuizApp.Models;
using QuizApp.Extensions;

namespace QuizApp.Controllers
{
    public class HomeController : Controller
    {
        IRepository<User> usersRepository;

        public HomeController()
        {
            usersRepository = new UserRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [Route("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/login")]
        [HttpPost]
        public IActionResult Login(string email, string password)
        {

            bool isRight = true;

            if (email == null)
            {
                isRight = false;
                ModelState.AddModelError("errors", "ელ-ფოსტის ველი ცარიელია");
            }

            if (password == null)
            {
                isRight = false;
                ModelState.AddModelError("errors", "პაროლის ველი ცარიელია");
            }

            if (!isRight)
            {
                return View();
            }

            var user = usersRepository.getAll()
                .Where(x => x.Email == email & x.Password == PasswordHasher.Get(password))
                .FirstOrDefault();

            if (user == null)
            {
                ModelState.AddModelError("errors", "პაროლი ან ელფოსტა არასწორია");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [Route("/logout")]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
