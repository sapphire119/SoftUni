using FDMC.Data;
using FDMC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FDMC.Controllers
{
    public class CatsController : Controller
    {
        private readonly ILogger<CatsController> _logger;
        private CatDbContext context;

        public CatsController(ILogger<CatsController> logger, CatDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var cats = this.context.Cats.ToList();
            return View(cats);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Cat inputCat)
        {
            try
            {
                this.context.Cats.Add(inputCat);
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("",$"{ex.Message}");
                return this.View();
            }

            return this.RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var currentCat = await this.context.Cats.FindAsync(id);
            return this.View(currentCat);
        }
    }
}
