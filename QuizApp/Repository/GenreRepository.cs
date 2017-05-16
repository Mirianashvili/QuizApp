using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Models;
using QuizApp.DB;

namespace QuizApp.Repository
{
    public class GenreRepository : IRepository<Genre>
    {
        private QuizAppDbContext context;

        public GenreRepository()
        {
            context = new QuizAppDbContext();    
        }

        public void Add(Genre entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }
        
        public void Delete(Genre entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Genre Get(int Id)
        {
            return context.Genre.FirstOrDefault(x => x.Id == Id);
        }

        public List<Genre> getAll()
        {
            return this.context.Genre.ToList();
        }

        public void Update(Genre entity)
        {
            Genre genre = this.Get(entity.Id);
            genre.Title = entity.Title;
            context.SaveChanges();
        }
    }
}
