using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjMongoAtividade24042023.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Street { get; set; }

        public int Number { get; set; }

        public string NeighborHood { get; set; }

        public string ZipCode { get; set; }

        public string Complement { get; set; }

        public City City { get; set; }

        public DateTime Dt_Register { get; set; }
    }
}
