using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Test.IServices;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private ILogin<Login> repo;

        public LoginController(IConfiguration config, ILogin<Login> repo)
        {
            _config = config;
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult Login(string email, string password)
        {
            Login login = new Login();
            login.Email = email;
            login.Password = password;

            var user = AuthenticateUser(login);
            if (user == null)
            {
                return Unauthorized();
            }
            var tokenStr = GenerateJSONWebToken(user);
            return Ok(new { TokenContext = tokenStr });
        }

        private Login AuthenticateUser(Login login)
        {
            var temp = repo.Retrive(login.Email);

            if (temp != null && login.Password== temp.Password)
            {
                return temp;
            }

            return null;
        }

        private string GenerateJSONWebToken(Login userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is a custom secret key for auth"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["BlaBla.com"],
                audience: _config["BlaBla.com"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedToken;
        }

        [HttpGet]
        [Authorize]
        [Route("BlaBla")]
        public IActionResult blabla()
        {
            return Ok("Blaaaaaaaaaaaaa");
        }

    }
}
