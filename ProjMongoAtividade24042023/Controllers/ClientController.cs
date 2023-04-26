using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProjMongoAtividade24042023.Models;
using ProjMongoAtividade24042023.Services;

namespace ProjMongoAtividade24042023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;
        private  AddressService _addressService;//testee
        private CityService _citiservice;//testee


        public ClientController(ClientService clientService, AddressService addressService, CityService citiservice) //teste com o segundo e o terceiro parametro
        {
            _clientService = clientService;
            _addressService = addressService;//teste
            _citiservice = citiservice;//testeee
        }

        [HttpGet]
        public ActionResult<List<Client>> Get() => _clientService.Get();

        [HttpGet("{id:length(24)}", Name = "GetClient")]
        public ActionResult<Client> Get(string id)
        {
            var client = _clientService.Get(id);
            if (client == null) return NotFound();
            return client;
        }
        [HttpPost]
        public ActionResult<Client> Create(Client client)
        {           
            var address = _addressService.Get(client.Adress.Id);//testeee
            if (address == null) return NotFound();//testee
            var city = _citiservice.Get(address.City.Id); // testeee pega a cidade pelo Id, se existir
            if (city == null) return NotFound(); // testeeeeee
            address.City = city; //testeee
            client.Adress = address; //testee
            
            return _clientService.Create(client); // clientService vai enviar esse client e la  na service vai dar replace colocando esse client no lugar do atual
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<Client> Update(string id, Client client)
        {
            var c = _clientService.Get(id);
            if (c == null) return NotFound();

            _clientService.Update(id, client);

            return Ok();
        }



        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();

            var client = _clientService.Get(id);
            if (client == null) return NotFound();
            _clientService.Delete(id); // chama o metodo Delete do ClientService

            return Ok();
        }




    }

}
