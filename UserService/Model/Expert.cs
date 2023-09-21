using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserService.Model
{
    public class Expert 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? ExpertID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Skills { get; set; }
        public double Rating { get; set; }
        public decimal Budget { get; set; }
        public DateTime? RegistrationDate { get; set; } = DateTime.Now;

    }
}