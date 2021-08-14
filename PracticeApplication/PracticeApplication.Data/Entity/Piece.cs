using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApplication.Domain.Entity
{
    public class Piece
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("composer")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ComposerId { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; }
    }
}
