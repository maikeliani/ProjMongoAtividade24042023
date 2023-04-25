using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProjMongoAtividade24042023.Config;
using ProjMongoAtividade24042023.Models;
using ProjMongoAtividade24042023.Services;

namespace ProjMongoAtividade24042023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        private CityService _cityService; // criei pra teste
        
       

        public AddressController(AddressService addressService, CityService cityService) // o segundo parametro ( CityService cityService) fui eu que colokei pra teste
        {
            _addressService = addressService;
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id)
        {
            var address = _addressService.Get(id);
            if (address == null) return NotFound();
            return address;
        }
        [HttpPost]
        public ActionResult<Address> Create(Address address)
        {
            var city = _cityService.Get(address.City.Id); // meu testeee

            if(city == null) //meu testee
            {
                NotFound();
            }
            address.City = city; // meu testeeee

            // _clientService.Create(client);
            //return CreatedAtRoute("GetClient", new { id = client.Id }, client);

            return _addressService.Create(address);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<Address> Update(string id, Address address)
        {
            var a = _addressService.Get(id);
            if (a == null) return NotFound();

            _addressService.Update(id, address);

            return Ok();
        }



        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();

            var client = _addressService.Get(id);
            if (client == null) return NotFound();
            _addressService.Delete(id);

            return Ok();
        }




    }

}
