using MongoDB.Driver;
using ProjMongoAtividade24042023.Config;
using ProjMongoAtividade24042023.Models;

namespace ProjMongoAtividade24042023.Services
{
    public class CityService
    {

        private readonly IMongoCollection<City> _city;

        public CityService(IProjMongoAtividadeSettings settings)
        {
            var city = new MongoClient(settings.ConnectionString); // recebe a conexao
            var database = city.GetDatabase(settings.DatabaseName);
            _city = database.GetCollection<City>(settings.DatabaseName);
        }

        public List<City> Get() => _city.Find(c => true).ToList();


        public City Get(string Id) => _city.Find(c => c.Id == Id).FirstOrDefault();
        public City Create(City city)
        {
            _city.InsertOne(city);
            return city;
        }

        public void Update(string id, City city) => _city.ReplaceOne(a => a.Id == id, city);

        public void Delete(string id) => _city.DeleteOne(c => c.Id == id);

        public void Delete(Address address) => _city.DeleteOne(a => a.Id == address.Id);
    }
}
