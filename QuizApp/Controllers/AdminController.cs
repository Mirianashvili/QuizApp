using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Filters;
using QuizApp.Models;
using QuizApp.Repository;
using QuizApp.ViewModels;

namespace QuizApp.Controllers
{
    [AdminFilter]
    public class AdminController : Controller
    {
        private readonly IRepository<User> usersRepository;

        public AdminController()
        {
            usersRepository = new UserRepository();
        }

        public IActionResult Index()
        {
            var user = usersRepository
                .getAll().Where(x => x.UserRoleId == 2)
                .FirstOrDefault();

            AdminViewModel vm = new AdminViewModel
            {
                FullName = user.FullName,
                Email = user.Email
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(AdminViewModel vm)
        {
            return View();
        }

        public IActionResult Users()
        {
            var users = usersRepository.getAll()
                .Where(x => x.UserRoleId == 1)
                .ToList();

            return View(users);
        }
    }
}