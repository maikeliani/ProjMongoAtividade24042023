using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjMongoAtividade24042023.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }

        public Address Adress { get; set; }

        public DateTime Dt_Register { get; set; }
    }
}
