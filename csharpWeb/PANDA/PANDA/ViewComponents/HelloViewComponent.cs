using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Panda.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.ViewComponents
{
    public class HelloViewComponent : ViewComponent
    {
        private readonly PandaDbContext _context;

        public HelloViewComponent(PandaDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string text)
        {
            var currentUserName = await _context.Users.FirstOrDefaultAsync();
            var vm = new HelloViewComponentViewModel
            {
                Username = currentUserName.Username,
                Text = text
            };
            return this.View(vm);
        }
    }

    public class HelloViewComponentViewModel
    {
        public string Username { get; set; }

        public string Text { get; set; }
    }
}
