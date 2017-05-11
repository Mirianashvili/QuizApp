using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Models;

namespace QuizApp.Repository
{
    public class InMemoryQuizRepository : IRepository<Quiz>
    {
        private static List<Quiz> quizes;

        static InMemoryQuizRepository()
        {
            quizes = new List<Quiz>();

            quizes.Add(new Quiz { Id = 1, GenreId = 1, Name = "1st grade", Difficulty = 1 });
            quizes.Add(new Quiz { Id = 2, GenreId = 2, Name = "for university", Difficulty = 9 });
            quizes.Add(new Quiz { Id = 3, GenreId = 3, Name = "Basic c++", Difficulty = 5 });
        }

        public void Add(Quiz entity)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(Quiz entity)
        {
            throw new NotImplementedException();
        }

        public Quiz Get(int Id)
        {
            return quizes.FirstOrDefault(x => x.Id == Id);
        }

        public List<Quiz> getAll()
        {
            return quizes;
        }

        public void Update(Quiz entity)
        {
            throw new NotImplementedException();
        }
    }
}
