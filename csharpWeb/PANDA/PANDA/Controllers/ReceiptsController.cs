using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Panda.Helpers;
using Panda.Data;
using Microsoft.EntityFrameworkCore;
using Panda.ViewModels;
using System.Globalization;
using Panda.Models;

namespace Panda.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly PandaDbContext _context;

        public ReceiptsController(PandaDbContext pandaDbContext)
        {
            _context = pandaDbContext;
        }

        public async Task<IActionResult> Index()
        {
            if (!this.HttpContext.Session.IsUserLoggedIn())
            {
                return this.RedirectToAction("Index", "Home");
            }

            var sessionUserId = this.HttpContext.Session.Get<int>(Constants.UserId);

            var currentUser = await _context.Users
                .Include(u => u.Receipts)
                    .ThenInclude(r => r.Package)
                .Include(u => u.Receipts)
                    .ThenInclude(r => r.Recipient)
                .SingleOrDefaultAsync(u => u.Id == sessionUserId);


            if (currentUser == null)
            {
                ModelState.AddModelError("", "User doesn't exist in the database!");
                return this.RedirectToAction("Index", "Home");
            }

            var viewModel = new List<ReceiptIndexViewModel>();

            foreach (var receipt in currentUser.Receipts)
            {
                viewModel.Add(
                    new ReceiptIndexViewModel(
                        receipt.Id, 
                        receipt.Package.Weight, 
                        receipt.IssuedOn.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        receipt.Recipient.Username
                        )
                    );
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!this.HttpContext.Session.IsUserLoggedIn())
            {
                return this.RedirectToAction("Index", "Home");
            }

            var currentReceipt = await _context.Receipts
                .Include(r => r.Package)
                .Include(r => r.Recipient)
                .SingleOrDefaultAsync(r => r.Id == id);


            var viewModel = new ReceiptDetaislViewModel(
                    currentReceipt.Id,
                    currentReceipt.IssuedOn.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    currentReceipt.Package.ShippingAddress,
                    currentReceipt.Package.Weight,
                    currentReceipt.Package.Description,
                    currentReceipt.Recipient.Username
                );

            return this.View(viewModel);
        }

        public async Task<IActionResult> Create(int id, int recipientId)
        {
            var currentPackage = await _context.Packages.FindAsync(id);

            var receipt = new Receipt(currentPackage.Weight * 2.67M, DateTime.Now, recipientId, id);
            try
            {
                _context.Receipts.Add(receipt);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return this.RedirectToAction("Index", "Home"); ;
        }
    }
}
