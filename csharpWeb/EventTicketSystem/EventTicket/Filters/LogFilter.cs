using EventTicket.Controllers;
using EventTicket.ViewModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTicket.Filters
{
    public class LogFilter : ActionFilterAttribute
    {
        private readonly ILogger<LogFilter> _logger;
        private EventsInputModel _inputModel;

        public LogFilter(ILogger<LogFilter> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var inputModel = (EventsInputModel)context.ActionArguments.FirstOrDefault().Value;
            if (inputModel != null) _inputModel = inputModel;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                var username = context.HttpContext.User.Identity.Name;
                //var requestArgs = context.HttpContext.Request.Form.ToDictionary(x => x.Key, y => y.Value.ToString());
                _logger.LogInformation($"[{DateTime.Now}] Administrator \"{username}\" created event \"{_inputModel.Name}\" ({_inputModel.Start} / {_inputModel.End}).");
            }
        }
    }
}
