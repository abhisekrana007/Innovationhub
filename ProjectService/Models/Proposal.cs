using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ProjectService.Models
{
    [Serializable,BsonIgnoreExtraElements]
    public class Proposal
    {
        [BsonId,BsonElement("_id"),BsonRepresentation(BsonType.ObjectId)]
        public string? ProposalId { get; set; }

        //[BsonElement("proposal_comment")]
        [BsonRepresentation(BsonType.String)]
        public string ProposalComment { get; set; }

        //[BsonElement("status")]
        [BsonRepresentation(BsonType.String)]
        public string? Status { get; set; } = "applied";
        
        //[BsonElement("submission_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime SubmissionDate { get; set; }=DateTime.Now;

        //[BsonElement("prposal_image")]
        [BsonRepresentation(BsonType.String)]
        public string? ProposalImage { get; set; }

        //[BsonElement("proposal_document")]
        [BsonRepresentation(BsonType.String)]
        public string? ProposalDocument { get; set; }


        //[BsonElement("project_id")]
        [BsonRepresentation(BsonType.String)]
        public string? ProjectId { get; set; } //Reference to the Project

        //[BsonElement("expert_id")]
        [BsonRepresentation(BsonType.String)]
        public string? ExpertId { get; set; } //Reference to the Expert

        


    }
}
