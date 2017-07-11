﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Repository;
using QuizApp.Models;
using QuizApp.Extensions;

/*
    admin:admin@mail.com 123456 
*/

namespace QuizApp.Controllers
{
    public class HomeController : Controller
    {
        IRepository<User> usersRepository;
        IRepository<Genre> genreRepository;

        public HomeController()
        {
            genreRepository = new GenreRepository();
            usersRepository = new UserRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Genre()
        {
            var genres = genreRepository.getAll();
            return View(genres);
        }

        public IActionResult Category(int Id)
        {
            var genre = genreRepository.Get(Id);

            if (genre == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(genre);
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

    
            if (user.UserRoleId == 1)
            {
                HttpContext.Session.Set<User>("login-user", user);
                return RedirectToAction("Index", "User");
            }

            HttpContext.Session.Set<User>("login-admin", user);
            return RedirectToAction("Index","Genre");

        }

        [Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Set<User>("login-user", null);
            HttpContext.Session.Set<User>("login-admin", null);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error()
        {
            return View();
        }
                
    }
}
