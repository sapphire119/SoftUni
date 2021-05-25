using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Models;
using Panda.Models.Enums;
using Panda.Helpers;
using Panda.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.Controllers
{
    public class UsersController : Controller
    {
        private PandaDbContext _pandaDbContext;
        
        public UsersController(PandaDbContext pandaDbContext)
        {
            _pandaDbContext = pandaDbContext;
        }

        public IActionResult Login()
        {
            if (this.HttpContext.Session.IsUserLoggedIn())
            {
                ModelState.AddModelError("", "User already logged in!");
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (this.HttpContext.Session.IsUserLoggedIn())
            {
                ModelState.AddModelError("", "User already logged in!");
                return this.RedirectToAction("Index", "Home");
            }

            var currentUser = await _pandaDbContext.Users.SingleOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (currentUser == null)
            {
                ModelState.AddModelError("", "User doesn't exist!");
                return this.View();
            }

            HttpContext.Session.Set(Constants.Username, currentUser.Username);
            HttpContext.Session.Set(Constants.UserId, currentUser.Id);
            HttpContext.Session.Set(Constants.Role, currentUser.Role);

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            if (this.HttpContext.Session.IsUserLoggedIn())
            {
                ModelState.AddModelError("", "User already logged in!");
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {
            if (this.HttpContext.Session.IsUserLoggedIn())
            {
                ModelState.AddModelError("", "User already logged in!");
                return this.RedirectToAction("Index", "Home");
            }

            var currentUser = await _pandaDbContext.Users
                .SingleOrDefaultAsync(
                    u => u.Username == userViewModel.Username &&
                         u.Email == userViewModel.Email);

            if (currentUser != null)
            {
                ModelState.AddModelError("", "User already exists!");
                return this.View();
            }

            if (userViewModel.Password != userViewModel.ConfirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match!");
                return this.View();
            }

            if (!_pandaDbContext.Users.Any()) currentUser.Role = Role.Admin;

            try
            {
                _pandaDbContext.Users.Add(currentUser);
                await _pandaDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return this.View();
            }

            this.HttpContext.Session.Set(Constants.Username, currentUser.Username);
            this.HttpContext.Session.Set(Constants.UserId, currentUser.Id);
            this.HttpContext.Session.Set(Constants.Role, currentUser.Role);

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            this.HttpContext.Session.Clear();

            return this.RedirectToAction("Index", "Home");
        }
    }
}
