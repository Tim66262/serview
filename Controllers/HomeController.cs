using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace serview.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.cookievalue = Request.Cookies["token"];
            if (ViewBag.cookievalue != null)
            {
                return View();
            }
            return Unauthorized();
        }

        [Route("/login")]
        public IActionResult Login()
        {
            return View("Authentification");
        }
    }
}