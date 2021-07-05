using Index.BidningModels;
using Index.Configuraiton;
using Index.Controllers.Base;
using Index.Models;
using Index.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Index.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;

        public UsersController(IUserService userService, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginInputModel inputModel)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.BadRequest($"User is already logged in!");
            }

            var jwtToken = await _userService.Authenticate(inputModel.Username, inputModel.Password);

            if (string.IsNullOrWhiteSpace(jwtToken))
            {
                return this.BadRequest("Invalid Username or Password");
            }

            return jwtToken;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegisterInputModel inputModel)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.BadRequest($"User is already logged in!");
            }

            var user = await _userManager.FindByNameAsync(inputModel.Username);
            if (user != null)
            {
                return this.BadRequest($"User Already exists!");
            }

            var result = await _userManager.CreateAsync(new AppUser(inputModel.Username), inputModel.Password);
            if (!result.Succeeded)
            {
                return this.BadRequest(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
            }


            return $"Username registered: {inputModel.Username}";
        }

        //[Authorize]
        //[HttpGet("[action]")]
        //public ActionResult<string> Logout()
        //{
        //    var a = this.User;
        //    return string.Empty;
        //}
    }
}
