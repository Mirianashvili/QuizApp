using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Models;
using QuizApp.DB;

namespace QuizApp.Repository
{
    public class AnswerRepository : IRepository<Answer>
    {
        private QuizAppDbContext context { get; set; }

        public AnswerRepository()
        {
            context = new QuizAppDbContext();
        }

        public void Add(Answer entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Answer entity)
        {
            throw new NotImplementedException();
        }

        public Answer Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Answer> getAll()
        {
            return context.Answer.ToList();
        }

        public void Update(Answer entity)
        {
            throw new NotImplementedException();
        }
    }
}
