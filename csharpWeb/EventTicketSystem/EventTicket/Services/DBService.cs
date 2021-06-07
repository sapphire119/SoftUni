using EventTicket.Data;
using EventTicket.Models;
using EventTicket.Models.Enums;
using EventTicket.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTicket.Services
{
    public class DBService : IDbService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;

        public DBService(UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, 
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public async Task SeetheData()
        {
            if (!_roleManager.Roles.Any())
            {
                var adminUser = new User
                {
                    UserName = "pesho",
                    Role = Role.Administrator,
                    Email = "p@p.com",
                    FirstName = "pesho",
                    LastName = "peshev",
                    UCN = "999121"
                };

                adminUser.PasswordHash = _userManager.PasswordHasher.HashPassword(adminUser, "1");

                _dbContext.Users.Add(adminUser);
                await _dbContext.SaveChangesAsync();


                await _roleManager.CreateAsync(new IdentityRole(Role.Administrator.ToString()));
                await _roleManager.CreateAsync(new IdentityRole(Role.User.ToString()));

                await _userManager.AddToRoleAsync(adminUser, Role.Administrator.ToString());
            }
        }
    }
}
