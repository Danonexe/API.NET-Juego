using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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
        public double Score { get; set; }

        [BsonElement("time")]
        public double Time { get; set; }
    }
}