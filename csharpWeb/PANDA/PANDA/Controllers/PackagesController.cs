using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Helpers;
using Panda.Models;
using Panda.Models.Enums;
using Panda.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.Controllers
{
    public class PackagesController : Controller
    {
        private const int MinShippingDays = 20;
        private const int MaxShippingDays = 41;


        private readonly Random _rand;

        private readonly PandaDbContext _context;

        public PackagesController(PandaDbContext context)
        {
            _context = context;
            _rand = new Random();
        }

        public IActionResult Create()
        {
            if (!this.HttpContext.Session.IsUserLoggedIn() && this.HttpContext.Session.Get<Role>(Constants.Role) == Role.Admin)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var viewModel = new PackageCreateViewModel();

            foreach (var user in _context.Users)
            {
                viewModel.AllUsers.Add(new SelectListItem(user.Username, user.Id.ToString()));
            }


            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PackageCreateViewModel inputModel)
        {
            if (inputModel.Weight == null)
            {
                ModelState.AddModelError("", "Weight cannot be empty!");
                return this.RedirectToAction(nameof(Create));
            }

            var package = new Package(inputModel.Description, inputModel.Weight.Value, inputModel.ShippingAddress, inputModel.RecipientId);

            try
            {
                _context.Packages.Add(package);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError($"", "Something went wrong!");
                return this.RedirectToAction("Index", "Home");
            }


            return this.RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Details(int id)
        {
            if (!this.HttpContext.Session.IsUserLoggedIn())
            {
                return this.RedirectToAction("Index", "Home");
            }

            var currentPackage = await _context
                .Packages
                .Include(p => p.Recipient)
                .SingleOrDefaultAsync(p => p.Id == id);


            var viewModel = new PackageDetailsViewModel
            {
                Address = currentPackage.ShippingAddress,
                Status = currentPackage.Status.ToString(),
                //TODO: check ETA status for null
                ETA = currentPackage.Status == Status.Pending ? "N/A" :
                    (currentPackage.Status == Status.Delivered || currentPackage.Status == Status.Acquired) ? "Delivered" :
                        currentPackage.ETA.Value.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture),
                Description = currentPackage.Description,
                Recipient = currentPackage.Recipient.Username,
                Weight = Math.Round(currentPackage.Weight, 2)
            };



            return View(viewModel);
        }

        public async Task<IActionResult> Delivered()
        {
            if (!this.HttpContext.Session.IsUserLoggedIn() && this.HttpContext.Session.Get<Role>(Constants.Role) == Role.Admin)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(await FetchPackagesViewModelAsync(Status.Delivered, _context));
        }

        public async Task<IActionResult> Shipped()
        {
            if (!this.HttpContext.Session.IsUserLoggedIn() && this.HttpContext.Session.Get<Role>(Constants.Role) == Role.Admin)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(await FetchPackagesViewModelAsync(Status.Shipped, _context));
        }

        public async Task<IActionResult> Pending()
        {
            if (!this.HttpContext.Session.IsUserLoggedIn() && this.HttpContext.Session.Get<Role>(Constants.Role) == Role.Admin)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(await FetchPackagesViewModelAsync(Status.Pending, _context));
        }

        public async Task<IActionResult> Ship(int id)
        {
            var currentPackage = await _context.Packages.FindAsync(id);
            currentPackage.Status = Status.Shipped;
            currentPackage.ETA = DateTime.Now.AddDays(_rand.Next(MinShippingDays, MaxShippingDays));

            await _context.SaveChangesAsync();

            return this.RedirectToAction(nameof(Pending));
        }

        public async Task<IActionResult> Deliver(int id)
        {
            await UpdatePackageStatusAsync(id, Status.Delivered, _context);

            return this.RedirectToAction(nameof(Shipped));
        }

        public async Task<IActionResult> Aquire(int id)
        {
            var currentPackage = await _context.Packages
                .SingleOrDefaultAsync(p => p.Id == id);

            currentPackage.Status = Status.Acquired;

            await _context.SaveChangesAsync();

            return this.RedirectToAction("Create", "Receipts", new { Id = id, RecipientId = currentPackage.RecipientId });
        }


        private static Task<IQueryable<PackageViewModel>> FetchPackagesViewModelAsync(Status status, PandaDbContext _context)
        {
            return Task.Run(() => _context.Packages
                .Include(p => p.Recipient)
                .Where(p => p.Status == status)
                .Select(p => new PackageViewModel
                {
                    Id = p.Id,
                    Description = p.Description,
                    Weight = Math.Round(p.Weight, 2),
                    Recipient = p.Recipient.Username,
                    ShippingAddress = p.ShippingAddress,
                    DeliveryDate = p.ETA
                }));
        }

        private static async Task UpdatePackageStatusAsync(int id, Status newStatus, PandaDbContext _context)
        {
            var package = await _context.Packages.FindAsync(id);
            package.Status = newStatus;

            await _context.SaveChangesAsync();
        }
    }
}
