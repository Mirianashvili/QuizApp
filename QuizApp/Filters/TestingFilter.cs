using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using QuizApp.Extensions;
using QuizApp.Models;

namespace QuizApp.Filters
{
    public class TestingFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var process = context.HttpContext.Session.Get<Testing>("testing");

            if (process == null)
            {
                RouteValueDictionary Route = new RouteValueDictionary
                {
                     { "controller", "User" },
                     { "action", "Index" }
                };
                context.Result = new RedirectToRouteResult(Route);
            }
        
        }
    }
}
