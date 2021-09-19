using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Reada_Backend.Models;
using Reada_Backend.Repo;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private IAuthRepo _authRepo;

        public LoginController(IConfiguration config , IAuthRepo authRepo)
        {
            _config = config;
            _authRepo = authRepo;

        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] UsreDto login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(UsreDto userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
        new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
        //new Claim("DateOfJoing", userInfo.DateOfJoing.ToString("yyyy-MM-dd")),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UsreDto AuthenticateUser(UsreDto login)
        {
            UsreDto user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.Username == "Jignesh")
            {
                user = new UsreDto { Username = "Jignesh Trivedi", EmailAddress = "test.btest@gmail.com" };
            }
            return user;
        }
    }
}

