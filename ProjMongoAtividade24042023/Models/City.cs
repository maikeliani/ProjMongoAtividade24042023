using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjMongoAtividade24042023.Models
{
    public class City
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime Dt_Register { get; set; }
    }
}
