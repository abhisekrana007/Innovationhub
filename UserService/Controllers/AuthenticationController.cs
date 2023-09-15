using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using UserService.Model;
using UserService.Repository;

namespace UserService.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
        {
            private readonly IConfiguration _config;
            private readonly IMongoCollection<Innovator> _innovatorsCollection;
            private readonly IMongoCollection<Expert> _expertsCollection;

            public AuthenticationController(IConfiguration config, IMongoDatabase database)
            {
                _config = config;
                _innovatorsCollection = database.GetCollection<Innovator>("innovators");
                _expertsCollection = database.GetCollection<Expert>("experts");
            }

        [HttpPost("innovator/login")]
       
        public IActionResult InnovatorLogin([FromBody] string email, [FromBody] string password)
        {
            var user = CheckInnovator(email, password);
            if (user != null)
            {
                var tokenString = GenerateToken(user);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }

        [HttpPost("expert/login")]
        public IActionResult ExpertLogin([FromBody] User userM)
        {
            var user = CheckExpert(userM);
            if (user != null)
            {
                var tokenString = GenerateToken(user);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                // Add more claims if needed
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(7), // Token expiration time
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User CheckInnovator(User userLoginModel)
        {
            return _innovatorsCollection.Find(u => u.Username == userLoginModel.Username && u.Password == userLoginModel.Password).SingleOrDefault();
        }

        private User CheckExpert(User userLoginModel)
        {
            return _expertsCollection.Find(u => u.Username == userLoginModel.Username && u.Password == userLoginModel.Password).SingleOrDefault();
        }
    }
}