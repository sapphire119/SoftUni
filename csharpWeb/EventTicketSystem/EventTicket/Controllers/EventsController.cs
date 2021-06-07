using EventTicket.Data;
using EventTicket.Filters;
using EventTicket.Models;
using EventTicket.Models.Enums;
using EventTicket.Services.Interfaces;
using EventTicket.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EventTicket.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EventsController> _logger;

        public EventsController(IEventService eventService, ApplicationDbContext context, ILogger<EventsController> logger)
        {
            _eventService = eventService;
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return this.View(await _context.Events.ToListAsync());
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            _logger.LogDebug("Administrator accessed Event Create page");
            return this.View();
        }

        [HttpPost, ValidateAntiForgeryToken, Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(LogFilter))]
        public async Task<IActionResult> Create(EventsInputModel model)
        {
            var @event = _eventService.FetchEventModel(model, ModelState);

            if (ModelState.ErrorCount > 0) return this.View();

            try
            {
                _context.Events.Add(@event);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Couldn't add event {ex.Message}");
                return this.View();
            }

            return this.RedirectToAction(nameof(Index));
        }
    }
}
