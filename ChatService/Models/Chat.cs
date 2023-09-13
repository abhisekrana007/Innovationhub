using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChatService.Models
{
    public class Chat
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ChatId { get; set; }
        public string InnovatorId { get; set; }
        public string ExpertId { get; set; }
        public Message Messages { get; set; }

    }
}
