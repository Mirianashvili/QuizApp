using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Models;
using QuizApp.Repository;
using QuizApp.ViewModels;
using QuizApp.Extensions;

namespace QuizApp.Controllers
{
    public class RegisterController:Controller
    {
        IRepository<User> userRepository;

        public RegisterController()
        {
            userRepository = new UserRepository();
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateUserViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var users = userRepository.getAll();
            bool AddUser = true;

            if (users.FirstOrDefault(x => x.FullName == vm.Fullname) != null)
            {
                ModelState.AddModelError("errors", "ასეთი სრული სახელი უკვე არსებობს");
                AddUser = false;
            }

            if (users.FirstOrDefault(x => x.Email == vm.Email) != null)
            {
                AddUser = false;
                ModelState.AddModelError("errors", "ასეთი პაროლი უკვე არსებობს");
            }

            if (!AddUser)
            {
                return View();
            }
                
            User user = new User()
            {
                FullName = vm.Fullname,
                IsActive = 1,
                UserRoleId = 1,
                Password = PasswordHasher.Get(vm.Password),
                Email = vm.Email
            };
            userRepository.Add(user);

            return RedirectToAction("Index","Account");
        }
    }
}
