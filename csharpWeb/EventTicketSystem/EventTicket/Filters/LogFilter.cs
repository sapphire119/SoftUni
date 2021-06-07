using EventTicket.Controllers;
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

        public LogFilter(ILogger<LogFilter> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var username = context.HttpContext.User.Identity.Name;
            var requestArgs = context.HttpContext.Request.Form.ToDictionary(x => x.Key, y => y.Value.ToString());
            _logger.LogInformation($"[{DateTime.Now}] Administrator \"{username}\" created event \"{requestArgs["Name"]}\" ({requestArgs["Start"]} / {requestArgs["End"]}).");
        }
    }
}
