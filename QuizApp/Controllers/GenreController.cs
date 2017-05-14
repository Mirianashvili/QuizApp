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
        IRepository<Test> testRepository;

        public GenreController()
        {
            this.testRepository = new TestRepository();
            this.genreRepository = new GenreRepository();
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
                Title = vm.Name,
                IsActive = 1
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

            List<Test> tests = testRepository.getAll()
                .Where(x => x.GenreId == genre.Id)
                .ToList();

            DetailsGenreViewModel vm = new DetailsGenreViewModel()
            {
                Genre = genre,
                Tests = tests
            };
            

            return View(vm);
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
        
        public IActionResult Search(string query)
        {
            var genres = genreRepository.getAll()
                .Where(x => x.Title.ToLower().Contains(query.ToLower()))
                .ToList();
            return View(genres);
        }

        public IActionResult IsActive(bool status)
        {
            return View();
        }
    }
}
