using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Models;
using QuizApp.Repository;
using QuizApp.ViewModels;

namespace QuizApp.Controllers
{
    public class GenreController : Controller
    {

        IRepository<Genre> genreRepository;

        public GenreController()
        {
            this.genreRepository = new InMemoryGenreRepository();
        }

        public IActionResult Index()
        {
            var genres = genreRepository.getAll();
            return View(genres);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateGenreViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Genre genre = new Genre
            {
                Name = vm.Name
            };

            genreRepository.Add(genre);

            return RedirectToAction("Index", "Genre");
        }

        public IActionResult Details(int Id)
        {
            var genre = genreRepository.Get(Id);

            if (genre == null)
            {
                return RedirectToAction("Error", "Genre");
            }

            return View(genre);
        }


        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Edit(int Id)
        {
            var genre = genreRepository.Get(Id);

            if (genre == null)
            {
                return RedirectToAction("Error", "Genre");
            }

            return View(genre);
        }

        [HttpPost]
        public IActionResult Edit(Genre genre)
        {
            genreRepository.Update(genre);
            return RedirectToAction("Index", "Genre");
        }

        [HttpPost]
        public IActionResult Remove(int Id)
        {
            var genre = genreRepository.Get(Id);

            if (genre == null)
            {
                return RedirectToAction("Error", "Genre");
            }

            genreRepository.Delete(genre);

            return RedirectToAction("Index", "Genre");
        }

    }
}
