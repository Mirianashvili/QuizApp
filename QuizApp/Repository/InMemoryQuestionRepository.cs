using System;
using System.Collections.Generic;
using QuizApp.Models;

namespace QuizApp.Repository
{
    public class InMemoryQuestionRepository : IRepository<Question>
    {
        private static List<Question> questions;

        public InMemoryQuestionRepository()
        {
            questions = new List<Question>();
            
            //1st grage
            questions.Add(new Question { Id = 1, QuizId = 1, Score = 1, Title = "1 + 1 =" });
            questions.Add(new Question { Id = 2, QuizId = 1, Score = 2, Title = "1 + 4 =" });
            questions.Add(new Question { Id = 3, QuizId = 1, Score = 4, Title = "1 + 9 =" });
            questions.Add(new Question { Id = 4, QuizId = 1, Score = 3, Title = "1 + 6 =" });
        }

        public void Add(Question entity)
        {
            questions.Add(entity);
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(Question entity)
        {
            throw new NotImplementedException();
        }

        public Question Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Question> getAll()
        {
            return questions;
        }

        public void Update(Question entity)
        {
            throw new NotImplementedException();
        }
    }
}
