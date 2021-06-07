using EventTicket.Models;
using EventTicket.Services.Interfaces;
using EventTicket.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EventTicket.Services
{
    public class EventService : IEventService
    {
        public Event FetchEventModel(EventsInputModel model, ModelStateDictionary modelState)
        {
            if (model.TotalTickets < 1)
            {
                modelState.AddModelError("", "Total tickets cannot be a negative number!");
                return null;
            }

            if (model.PricePerTicket < 1.0m)
            {
                modelState.AddModelError("", "Tickets must cost at least 1$");
                return null;
            }

            var parseStartDate = DateTime.TryParseExact(model.Start, @"dd-MMM-yyyy HH:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var startTime);

            var parseEndDate = DateTime.TryParseExact(model.End, @"dd-MMM-yyyy HH:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var endTime);

            if (!parseStartDate || !parseEndDate)
            {
                modelState.AddModelError("", "Couldn't parse either start or end date");
                return null;
            }

            return new Event
            {
                Name = model.Name,
                PricePerTicket = model.PricePerTicket,
                TotalTickets = model.TotalTickets,
                Place = model.Place,
                Start = startTime,
                End = endTime
            };
        }
    }
}
