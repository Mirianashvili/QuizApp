using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Extensions;

namespace QuizApp.Filters
{
    public class AdminFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var user = context.HttpContext.Session.Get<User>("login-user");

            if (user == null)
            {
                Redirect(context);
            }

            else
            {

                if (user.UserRoleId != 2)
                {
                    Redirect(context);
                }
            }

        }

        private void Redirect(ResultExecutingContext context)
        {
            context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Home" }, { "action", "Login" } });
        }
    }
}
