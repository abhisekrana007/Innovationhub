using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
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
       
        public IActionResult InnovatorLogin([FromBody]JObject innovator)
        {
            Innovator findInnovator = CheckInnovator(innovator["email"].ToObject<string>(), innovator["password"].ToObject<string>());
            if (findInnovator != null)
            {
                var tokenString = GenerateToken(findInnovator.Username);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }

        [HttpPost("expert/login")]
        public IActionResult ExpertLogin([FromBody] JObject expert)
        {
            Expert findExpert = CheckExpert(expert["email"].ToObject<string>(), expert["password"].ToObject<string>());
            if (findExpert != null)
            {
                var tokenString = GenerateToken(findExpert.Username);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }
        /*public IActionResult ExpertLogin([FromBody] User userM)
        {
            var user = CheckExpert(userM);
            if (user != null)
            {
                var tokenString = GenerateToken(user);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }*/

        private string GenerateToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
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

        private Innovator CheckInnovator(string innovatorEmail,string innovatorPassword)
        {
            return _innovatorsCollection.Find(u => u.Email == innovatorEmail && u.PasswordHash == innovatorPassword).SingleOrDefault();
        }

        private Expert CheckExpert(string expertEmail, string expertPassword)
        {
            return _expertsCollection.Find(u => u.Email == expertEmail && u.PasswordHash == expertPassword).SingleOrDefault();
        }
    }
}