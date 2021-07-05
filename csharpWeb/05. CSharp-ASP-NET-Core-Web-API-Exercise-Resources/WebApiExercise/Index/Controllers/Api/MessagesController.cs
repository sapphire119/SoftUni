using Index.Controllers.Base;
using Index.Data;
using Index.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Index.Controllers
{
    public class MessagesController : ApiController
    {
        private readonly AppDbContext _context;

        public MessagesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/all")]
        public ActionResult<IEnumerable<Message>> GetMessages()
        {
            return _context.Messages.OrderBy(x => x.CreatedOn).ToArray();
        }

        [HttpPost("/create")]
        public ActionResult<Message> CreateMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            return message;
        }
    }
}
