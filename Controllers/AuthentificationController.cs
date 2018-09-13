using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using serview.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace serview.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class AuthentificationController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AuthentificationController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("registration")]
        public async Task<IActionResult> Registration(Registration credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            User user = new User()
            {
                Email = credentials.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = credentials.UserName
            };

            var result = await _userManager.CreateAsync(user, credentials.Password);

            SetJwtToken(user);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("login")]
        public async Task<IActionResult> Login(Login credentials)
        {
            var user = await _userManager.FindByNameAsync(credentials.UserName);
            if(user != null)
            {
                var password = await _userManager.CheckPasswordAsync(user, credentials.Password);
                if (password)
                {
                    SetJwtToken(user);

                    return RedirectToAction("Index", "Home");
                }
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("logout")]
        public void Logout()
        {
            HttpContext.Response.Cookies.Delete("token");
        }

        private void SetJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authnetication"));

            var token = new JwtSecurityToken(
                issuer: "http://oec.com",
                audience: "http://oec.com",
                expires: DateTime.Now,
                claims: claims,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            );

            var access = new Token
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            };
            var response = HttpContext.Response;
            response.Cookies.Append("token", access.token);
            response.Cookies.Append("expiration", access.expiration.ToLongTimeString());
        }
    }
}