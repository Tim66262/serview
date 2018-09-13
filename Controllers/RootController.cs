using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace serview.Controllers
{
    [Route("/api")]
    public class RootController : Controller
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot), null),
                login = new
                {
                    Register = "api/authentification/registration",
                    Login = "api/authentification/login"
                },
                series = new
                {
                    GetSeries = "/api/series/",
                    GetSerie = "/api/series/{id}",
                    AddSerie = "/api/series/",
                    PutSerie = "/api/series/{id}",
                    DeleteSerie = "/api/series/{id}",
                }
            };
            return Ok(response);
        }
    }
}