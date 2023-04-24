using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjMongoAtividade24042023.Models;
using ProjMongoAtividade24042023.Services;

namespace ProjMongoAtividade24042023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
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
