using MongoDB.Driver;
using ProjMongoAtividade24042023.Config;
using ProjMongoAtividade24042023.Models;

namespace ProjMongoAtividade24042023.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;
        
          

        public AddressService(IProjMongoAtividadeSettings settings)
        {
            var address = new MongoClient(settings.ConnectionString); // recebe a conexao
            var database = address.GetDatabase(settings.DatabaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);     //atenção no nome da collection!       

        }



        public List<Address> Get() => _address.Find(a => true).ToList(); 


        public Address Get(string Id) => _address.Find(c => c.Id == Id).FirstOrDefault();
        public Address Create(Address address)
        {
            _address.InsertOne(address);
            return address;
        }

        public void Update(string id, Address address) => _address.ReplaceOne(a => a.Id == id, address);

        public void Delete(string id) => _address.DeleteOne(a => a.Id == id);

        public void Delete(Address address) => _address.DeleteOne(a => a.Id == address.Id);
    }
}
