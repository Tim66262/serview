using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace serview.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class UsersController : Controller
    {
        private readonly ServiewDBContext _context;

        public UsersController(ServiewDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_context.Users.Select(u => u.UserName).ToList());
        }
    }
}