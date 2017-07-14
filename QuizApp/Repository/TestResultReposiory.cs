using System;
using System.Collections.Generic;
using QuizApp.Models;
using QuizApp.DB;
using System.Linq;

namespace QuizApp.Repository
{
    public class TestResultReposiory : IRepository<TestResult>
    {
        QuizAppDbContext context;

        public TestResultReposiory()
        {
            context = new QuizAppDbContext();
        }

        public void Add(TestResult entity)
        {
            context.TestResult.Add(entity);
            context.SaveChanges();
        }

        public void Delete(TestResult entity)
        {
            throw new NotImplementedException();
        }

        public TestResult Get(int Id)
        {
            return context.TestResult.Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<TestResult> getAll()
        {
            return context.TestResult.ToList();
        }

        public void Update(TestResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
