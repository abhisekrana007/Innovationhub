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
        [HttpPost("innovator/register")]
        public IActionResult RegisterInnovator([FromBody] Innovator innovator)
        {
            // You should add validation for required fields and other checks here.
            // For example, check if required fields are provided and if the username or email is unique.
            // You can also check for valid email format and other business logic validations.
            // Example validation checks:
            if (string.IsNullOrEmpty(innovator.Username))
            {
                return BadRequest("Username is required.");
            }

            if (string.IsNullOrEmpty(innovator.PasswordHash))
            {
                return BadRequest("Password is required.");
            }

            // Add logic to hash the innovator's password before storing it.
            // You should implement password hashing for security.
            // For simplicity, we assume the password is already hashed.
            // In reality, you should hash the password before storing it.

            // Set the registration date to the current UTC date and time
            innovator.RegistrationDate = DateTime.UtcNow;

            // Store the innovator in the database
            _innovatorsCollection.InsertOne(innovator);

            // Return a success response
            return Ok();
        }

        [HttpPost("expert/register")]
        public IActionResult RegisterExpert([FromBody] Expert expert)
        {
            // You should implement logic to hash the expert's password before storing it.
            // For simplicity, this example does not include password hashing.
            // You should also add validation and error handling as needed.
            _expertsCollection.InsertOne(expert);
            return Ok();
        }
    }
}




//        [AllowAnonymous]
//        [HttpPost("login")]
//        public IActionResult Login([FromBody] LoginModel model)
//        {
//            var user = GetUser(model.Username, model.Password);

//            if (user == null)
//            {
//                return Unauthorized("Invalid username or password");
//            }

//            var token = GenerateJwtToken(user);

//            return Ok(new { Token = token });
//        }

//        [AllowAnonymous]
//        [HttpPost("register")]
//        public IActionResult Register([FromBody] RegistrationModel model)
//        {
//            if (UserExists(model.Username))
//            {
//                return BadRequest("Username already exists");
//            }

//            var user = new Expert // Change to Innovator if needed
//            {
//                Username = model.Username,
//                Email = model.Email,
//                // Set other properties as needed
//            };

//            // Save user to your database or data store here

//            var token = GenerateJwtToken(user);
//            return Ok(new { Token = token });
//        }

//        private Expert GetUser(string username, string password)
//        {
//            // Implement logic to retrieve the user from your data store
//            // You may need to perform password hashing and validation here
//            // Replace this with your data access code
//            return null;
//        }

//        private bool UserExists(string username)
//        {
//            // Implement logic to check if the user already exists in your data store
//            // Replace this with your data access code
//            return false;
//        }

//        private string GenerateJwtToken(Expert user)
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(Configuration["JwtSettings:SecretKey"]);

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new[]
//                {
//                new Claim(ClaimTypes.Name, user.Username),
//                // Add any other claims as needed
//            }),
//                Expires = DateTime.UtcNow.AddHours(2), // Set token expiration time
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };

//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            return tokenHandler.WriteToken(token);
//        }
//    }

//    public class LoginModel
//    {
//        public string Email { get; set; }
//        public string Password { get; set; }
//    }

//    public class RegistrationModel
//    {
//        public string Username { get; set; }
//        public string Email { get; set; }
//        public string Password { get; set; }
//        // Add other registration properties here
//    }
//}