using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Models;
using QuizApp.Repository;
using QuizApp.ViewModels;
using QuizApp.Filters;

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

            var selectedGenre = genreRepository.getAll()
                .Where(x => x.Title == vm.Title)
                .FirstOrDefault();

            if (selectedGenre != null)
            {
                ModelState.AddModelError("errors", "ასეთი კატეგორია უკვე არსებობს");
                return View(selectedGenre);
            }

            Genre genre = new Genre
            {
                Title = vm.Title,
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
            if (!ModelState.IsValid)
            {
                return View(genre);
            }

            var isGenreUnique = genreRepository.getAll()
                .Where(x => x.Title.ToLower() == genre.Title.ToLower())
                .FirstOrDefault();

            if (isGenreUnique != null)
            {
                ModelState.AddModelError("errors", "ასეთი კატეგორიის სახელი უკვე არსებობს");
                return View(genre);
            }

            genreRepository.Update(genre);
            return RedirectToAction("Index", "Genre");
        }
        
        public IActionResult Remove(int Id)
        {
            var genre = genreRepository.Get(Id);

            if (genre == null)
            {
                return RedirectToAction("Error", "Genre");
            }

            //delete test,question,answer
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
    }
}
