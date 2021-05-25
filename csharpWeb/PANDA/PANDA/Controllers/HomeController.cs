using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Panda.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Panda.Helpers;
using Panda.Data;
using Microsoft.EntityFrameworkCore;
using Panda.ViewModels;
using Microsoft.Extensions.Configuration;
using Panda.Services;

namespace Panda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PandaDbContext _pandaDbContext;
        private readonly ICounterService _counterService;

        //private readonly IConfigurationRoot _configurationRoot;

        public HomeController(ILogger<HomeController> logger,
            PandaDbContext pandaDbContext,
            ICounterService counterService
            //IConfigurationRoot configurationRoot
            /*UserManager userManager, RoleManager roleManager, SignInManager signInManager*/)
        {
            _logger = logger;
            _pandaDbContext = pandaDbContext;
            _counterService = counterService;
            //_configurationRoot = configurationRoot;
        }

        public async Task<IActionResult> Index()
        {
            //var a = this.GetType().Assembly.FullName;
            var a = this.ControllerContext.ValueProviderFactories;
            var b = this.ControllerContext.ActionDescriptor;
            var c = this.ControllerContext.RouteData;
            //var test = _configurationRoot.Providers.ToList();
            //;
            if (this.HttpContext.Session.IsUserLoggedIn())
            {
                var userId = this.HttpContext.Session.Get<int>(Constants.UserId);

                var currentUser = await _pandaDbContext.Users
                    .Include(x => x.Packages)
                    .SingleOrDefaultAsync(u => u.Id == userId);

                var viewModel = new UserIndexViewModel(
                        currentUser.Packages.Where(p => p.Status == Models.Enums.Status.Pending),
                        currentUser.Packages.Where(p => p.Status == Models.Enums.Status.Shipped),
                        currentUser.Packages.Where(p => p.Status == Models.Enums.Status.Delivered)
                    );

                return this.View(viewModel);
            }


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
