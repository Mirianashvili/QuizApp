using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Models;

namespace QuizApp.Repository
{
    public class InMemoryGenreRepository : IRepository<Genre>
    {
        private static List<Genre> _genres;

        static InMemoryGenreRepository()
        {
            _genres = new List<Genre>();

            _genres.Add(new Genre { Id = 1, Name = "Math" });
            _genres.Add(new Genre { Id = 2, Name = "Physics" });
            _genres.Add(new Genre { Id = 3, Name = "ICT" });
        }

        public void Add(Genre entity)
        {
            int Id = _genres.Max(x => x.Id) + 1;
            entity.Id = Id;
            _genres.Add(entity);
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(Genre entity)
        {
            _genres.Remove(entity);
        }

        public Genre Get(int Id)
        {
            return _genres.FirstOrDefault(x => x.Id == Id);
        }

        public List<Genre> getAll()
        {
            return _genres;
        }

        public void Update(Genre entity)
        {
            var genre = _genres.FirstOrDefault(x => x.Id == entity.Id);
            genre.Name = entity.Name;
        }
    }
}
