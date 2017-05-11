
using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Repository;
using System.Collections.Generic;

namespace QuizApp.Controllers
{
    public class ApiController : Controller
    {
        IRepository<Question> questionRepository;

        public ApiController()
        {
            questionRepository = new InMemoryQuestionRepository();
        }

        /*
            get questions by quiz id 
        */
  
        public IActionResult Questions(int Id)
        {
            List<Question> filtered = new List<Question>();

            foreach (var item in questionRepository.getAll())
            {
                if (item.QuizId == Id)
                {
                    filtered.Add(item);
                }
            }

            return Json(filtered);
        }
    }
}
