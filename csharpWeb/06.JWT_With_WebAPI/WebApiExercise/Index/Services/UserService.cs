using Index.Configuraiton;
using Index.Data;
using Index.Models;
using Index.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Index.Services
{
    public class UserService : IUserService
    {
        private readonly JwtSettingsOptions _jwtSettings;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserService(
            IOptions<JwtSettingsOptions> options, 
            AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _jwtSettings = options.Value;
            _context = context;
            _userManager = userManager;
        }

        public async Task<string> Authenticate(string username, string password)
        {
            var currentUser = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);

            if (currentUser == null && !await _userManager.CheckPasswordAsync(currentUser, password))  
                return null;

            var key = Encoding.UTF8.GetBytes(_jwtSettings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(15),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, currentUser.Id),
                    new Claim(ClaimTypes.Name, currentUser.UserName)
                }),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptior);
            var jwt = tokenHandler.WriteToken(token);

            return jwt;
        }
    }
}
