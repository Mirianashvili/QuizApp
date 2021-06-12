using System.Collections.Generic;
using QuizApp.Models;
using QuizApp.DB;
using System.Linq;

namespace QuizApp.Repository
{
    public class TestRepository : IRepository<Test>
    {
        QuizAppDbContext context;

        public TestRepository()
        {
            this.context = new QuizAppDbContext();
        }

        public void Add(Test entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Test entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Test Get(int Id)
        {
            return context.Tests.Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<Test> getAll()
        {
            return context.Tests.ToList();
        }

        public void Update(Test entity)
        {
            var test = this.Get(entity.Id);

            test.Title = entity.Title;
            test.Difficulty = entity.Difficulty;
            test.GenreId = entity.GenreId;

            context.SaveChanges();
        }
    }
}
