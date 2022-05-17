using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordMaster.Filters
{
    public class MyFirstActionFilterAttribute : ActionFilterAttribute
    {
         
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("action end" + DateTime.Now);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userName = context.HttpContext.Session.GetString("userName");
            if (String.IsNullOrWhiteSpace(userName))
            {
                context.HttpContext.Session.SetString("returnUrl", context.HttpContext.Request.Path);
                context.HttpContext.Response.Redirect("/Auth/Login");

            }

           
            
            Console.WriteLine("action start" + DateTime.Now);
        }
    }
}
