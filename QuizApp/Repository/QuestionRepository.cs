using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Models;
using QuizApp.DB;

namespace QuizApp.Repository
{
    public class QuestionRepository : IRepository<Question>
    {
        QuizAppDbContext context;

        public QuestionRepository()
        {
            context = new QuizAppDbContext();
        }

        public void Add(Question entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Question entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Question Get(int Id)
        {
            return context.Question.FirstOrDefault(x => x.Id == Id);
        }

        public List<Question> getAll()
        {
            return context.Question.ToList();
        }

        public void Update(Question entity)
        {
            var question = this.Get(entity.Id);
            question.TestId = entity.TestId;
            question.Title = entity.Title;
            context.SaveChanges();
        }
    }
}
