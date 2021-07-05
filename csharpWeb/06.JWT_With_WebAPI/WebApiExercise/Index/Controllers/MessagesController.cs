using Index.BidningModels;
using Index.Controllers.Base;
using Index.Data;
using Index.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Index.Controllers
{
    public class MessagesController : ApiController
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MessagesController(
            AppDbContext context, 
            UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<AllUserViewModel>> GetMessages()
        {
            return _context.Messages
                .Include(x => x.User)
                .OrderBy(x => x.CreatedOn)
                .AsNoTracking()
                .Select(m => new AllUserViewModel(m.User.UserName, m.Content))
                .ToArray();
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<ActionResult<MessageOutputModel>> CreateMessage(Message message)
        {
            var currentUser = await _userManager.GetUserAsync(this.User);
            if (currentUser == null)
            {
                return this.BadRequest($"User is not logged in!");
            }
            _context.Messages.Add(message);
            _context.SaveChanges();

            return new MessageOutputModel(currentUser.UserName, message.Content);
        }
    }
}
