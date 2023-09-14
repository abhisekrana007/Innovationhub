using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;using UserService.Model;
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
        //[HttpPost("innovator/register")]
        //public IActionResult RegisterInnovator([FromBody] Innovator innovator)
        //{
        //    // You should add validation for required fields and other checks here.
        //  // For example, check if required fields are provided and if the username or email is unique.
        //    // You can also check for valid email format and other business logic validations.
        //    // Example validation checks:
        //    if (string.IsNullOrEmpty(innovator.Username))
        //    {
        //        return BadRequest("Username is required.");
        //    }

        //    if (string.IsNullOrEmpty(innovator.PasswordHash))
        //    {
        //        return BadRequest("Password is required.");
        //    }

        //    // Add logic to hash the innovator's password before storing it.
        //    // You should implement password hashing for security.
        //    // For simplicity, we assume the password is already hashed.
        //    // In reality, you should hash the password before storing it.

        //    // Set the registration date to the current UTC date and time
        //    innovator.RegistrationDate = DateTime.UtcNow;

        //   // Store the innovator in the database
        //    _innovatorsCollection.InsertOne(innovator);

        //    // Return a success response
        //    return Ok();
        //}

        //[HttpPost("expert/register")]
        //    public IActionResult RegisterExpert([FromBody] Expert expert)
        //    {
        //        // You should implement logic to hash the expert's password before storing it.
        //        // For simplicity, this example does not include password hashing.
        //        // You should also add validation and error handling as needed.
        //        _expertsCollection.InsertOne(expert);
        //        return Ok();
        //    }


        [HttpPost("innovator/login")]
        public IActionResult UserLogin([FromBody] UserLoginModel userLoginModel)
        {
            var user = CheckUser(userLoginModel.Username, userLoginModel.Password, _innovatorsCollection);
            if (user != null)
            {
                var tokenString = GenerateToken(user.Username);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }

        [HttpPost("expert/login")]
        public IActionResult ExpertLogin([FromBody] ExpertLoginModel expertLoginModel)
        {
            var expert = CheckExpert(expertLoginModel.Username, expertLoginModel.Password, _expertsCollection);
            if (expert != null)
            {
                var tokenString = GenerateToken(expert.Username);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }

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

        private Innovator CheckUser(string username, string password, IMongoCollection<Innovator> collection)
        {
            var filter = Builders<Innovator>.Filter.Eq(x => x.Username, username) &
                         Builders<Innovator>.Filter.Eq(x => x.PasswordHash, password);

            return collection.Find(filter).SingleOrDefault();
        }

        private Expert CheckExpert(string username, string password, IMongoCollection<Expert> collection)
        {
            var filter = Builders<Expert>.Filter.Eq(x => x.Username, username) &
                         Builders<Expert>.Filter.Eq(x => x.PasswordHash, password);

            return collection.Find(filter).SingleOrDefault();
        }
    }
}

public class UserLoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class ExpertLoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    


     