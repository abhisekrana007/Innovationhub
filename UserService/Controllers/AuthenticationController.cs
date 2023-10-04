using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using BCrypt.Net;
using UserService.Model;
using UserService.MongoDBSettings;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.Security.Authentication;

namespace UserService.Controllers
{


    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMongoCollection<Innovator> _innovatorsCollection;
        private readonly IMongoCollection<Expert> _expertsCollection;
        public AuthenticationController(IUserDatabaseSettings settings, IConfiguration config)
        {
            string connectionString =
   @"mongodb://innovationaccount:nOw32mZu5c1N1AR8564qtpLTtKnRKAEmTB2Vf1iS2z1183HWZuz6T0mjUvaXZwBipXzXi2HdxWZaACDblyAUkw==@innovationaccount.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@innovationaccount@";
            MongoClientSettings settings1 = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings1.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings1);
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _innovatorsCollection = database.GetCollection<Innovator>(settings.InnovatorsCollectionName);
           
            _expertsCollection = database.GetCollection<Expert>(settings.ExpertsCollectionName);
            _config = config;
        }



        [HttpPost("innovator/login")]
        public IActionResult InnovatorLogin([FromBody] JObject innovator)
        {
            string innovatorEmail = innovator["Email"].ToObject<string>();
            string innovatorPassword = innovator["Password"].ToObject<string>();

            Innovator findInnovator = CheckInnovator(innovatorEmail, innovatorPassword);
            if (findInnovator != null)
            {
                var tokenString = GenerateToken(findInnovator.InnovatorID,"Innovator");
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }

        [HttpPost("expert/login")]
        public IActionResult ExpertLogin([FromBody] JObject expert)
        {
            string expertEmail = expert["Email"].ToObject<string>();
            string expertPassword = expert["Password"].ToObject<string>();

            Expert findExpert = CheckExpert(expertEmail, expertPassword);
            if (findExpert != null)
            {
                var tokenString = GenerateToken(findExpert.ExpertID,"Expert");
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }
        private string GenerateToken(string id,string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[]
            {
                    new Claim(ClaimTypes.Name, id),
                    new Claim(ClaimTypes.Role, role)
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
        private Innovator CheckInnovator(string innovatorEmail, string innovatorPassword)
        {
            Innovator innovator = _innovatorsCollection.Find(u => u.Email == innovatorEmail).SingleOrDefault();

            if (innovator != null && BCrypt.Net.BCrypt.Verify(innovatorPassword, innovator.Password))
            {
                return innovator;
            }

            return null;
        }

        private Expert CheckExpert(string expertEmail, string expertPassword)
        {
            Expert expert = _expertsCollection.Find(u => u.Email == expertEmail).SingleOrDefault();

            if (expert != null && BCrypt.Net.BCrypt.Verify(expertPassword, expert.Password))
            {
                return expert;
            }

            return null;
        }
    }
}





