using EventTicket.Data;
using EventTicket.Models;
using EventTicket.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTicket.Services.Interfaces
{
    public interface IEventService
    {
        Event FetchEventModel(EventsInputModel model, ModelStateDictionary modelState);
    }
}
