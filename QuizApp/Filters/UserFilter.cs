using Microsoft.AspNetCore.Mvc.Filters;
using QuizApp.Extensions;
using QuizApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace QuizApp.Filters
{
    public class UserFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var user = context.HttpContext.Session.Get<User>("login-user");

            if (user == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Home" }, { "action", "Login" } });
            }
        }
    }
}
