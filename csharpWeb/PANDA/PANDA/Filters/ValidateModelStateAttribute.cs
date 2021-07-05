using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.Filters
{
    public class GlobalHomeAtrribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //context.HttpContext.Response.Headers.Add("X-Home", "Home Controller");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }

    //public class AddHeaderAttribute : Attribute, IAsyncActionFilter
    //{
    //    private readonly string _name;
    //    private readonly string _value;

    //    public AddHeaderAttribute(string name, string value)
    //    {
    //        _name = name;
    //        _value = value;
    //    }

    //    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //    {
    //        context.HttpContext.Response.Headers.Add(_name, _value);
    //        await next();
    //    }
    //}

    public class ValidateModelStateAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {   
            //if (!context.ModelState.IsValid)
            //{
            //    context.Result = new JsonResult("Invalid Model state.");
            //}
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
            //if (context.ModelState.IsValid)
            //{
            //    context.Result = new ContentResult { ContentType = "Invalid Model state." };
            //}
        }
    }
}
