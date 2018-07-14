using System;
using System.Linq;
using Dashboard.API.Data;
using Dashboard.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dashboard.API.Controllers
{
    [Route("api/[controller]")]
    public class ServerController : Controller
    {
        private readonly ApiContext _context;
        ILogger<ServerController> _logger;

        public ServerController(ApiContext context, ILogger<ServerController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _context.Servers.OrderBy(s => s.Id).ToList();

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetServer")]
        public IActionResult Get(int id)
        {
            var response = _context.Servers.Find(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Message(int id, [FromForm] ServerMessage msg)
        {
            var server = _context.Servers.Find(id);
            
            if (server == null)
            {
                return NotFound();
            }
            if (msg.Payload == "activate")
            {
                server.IsOnline = true;
                _context.SaveChanges();
            }
            if (msg.Payload == "deactivated")
            {
                server.IsOnline = false;
            }
            
            _context.SaveChanges();
            return Ok();
        }
    }
}
