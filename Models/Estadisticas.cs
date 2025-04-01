
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TodoApi.Models
{
    public class Estadisticas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nick")]
        public string Nick { get; set; }

        [BsonElement("score")]
        public int Score { get; set; }

        [BsonElement("time")]
        public TimeSpan Time { get; set; }

        [BsonElement("date")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Date { get; set; }
    }
}