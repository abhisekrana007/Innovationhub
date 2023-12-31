﻿using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ProjectService.Models
{
    public class Project
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? ProjectID { get; set; }

        public string? ProjectTitle { get; set; }

        
        public string? ProjectDoc { get; set; }

        public string? Description { get; set; }

        public string? RequiredSkills { get; set; }

        public string? InnovatorID { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreationDate { get; set; }=DateTime.Now;

        public string? Status { get; set; } = "Can Apply";

        public string? ExpertId { get; set; }
    }
}
