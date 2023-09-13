using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserService.Model
{
    public class Innovator
    
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? InnovatorID { get; set; }


        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime RegistrationDate { get; set; }
    }

}