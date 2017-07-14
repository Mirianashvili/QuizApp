using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Models;
using QuizApp.DB;

namespace QuizApp.Repository
{
    public class UserRepository : IRepository<User>
    {
        private QuizAppDbContext context;

        public UserRepository()
        {
            context = new QuizAppDbContext();
        }

        public void Add(User entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(User entity)
        {
            context.User.Remove(entity);
            context.SaveChanges();
        }

        public User Get(int Id)
        {
            return context.User.FirstOrDefault(x => x.Id == Id);
        }

        public List<User> getAll()
        {
            return context.User.ToList();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
