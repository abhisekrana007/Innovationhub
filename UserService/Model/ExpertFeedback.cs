using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserService.Model
{
   public class ExpertFeedback
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? FeedbackID { get; set; }

        public string ExpertID { get; set; }

        public string InnovatorID { get; set; }

        public string FeedbackContent { get; set; }
        public int Rating { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
