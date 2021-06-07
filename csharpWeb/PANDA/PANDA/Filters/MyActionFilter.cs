using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Panda.Filters.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.Filters
{
    public class MyAuthorizeFilter : IAuthorizationFilter/*, IAsyncAuthorizationFilter*/
        //AuthorizeFilter (only async)
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }

        //public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        //{
        //    return Task.CompletedTask;
        //}

    }

    public class MyResourceFilter : IResourceFilter/*, IAsyncResourceFilter*/
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        //public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        //{
        //    await next();
        //}
    }

    public class MyActionFilter : ActionFilterAttribute
        //Attribute, IAsyncActionFilter, IActionFilter
        //IAsyncResultFilter, IResultFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            
            //context.Exception
        }
        //override 

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    base.OnActionExecuting(context);
        //}
    }

    public class MyResultFilter : /*IAsyncResultFilter,*/ IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        //public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        //{
        //    await next();
        //}
    }

    public class MyExceptionFilter : /*IAsyncExceptionFilter,*/ IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
        }

        //public Task OnExceptionAsync(ExceptionContext context)
        //{
        //    return Task.CompletedTask;
        //}
    }

    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        private readonly PositionOptions _settings;

        public MyActionFilterAttribute(IOptions<PositionOptions> options)
        {
            _settings = options.Value;
            //Order = 1;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //new string[] { _settings.Name };
            context.HttpContext.Response.Headers.Add(_settings.Title, _settings.Names);
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

    }
}
