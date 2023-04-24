using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjMongoAtividade24042023.Models;
using ProjMongoAtividade24042023.Services;

namespace ProjMongoAtividade24042023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<List<City>> Get() => _cityService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCity")]
        public ActionResult<City> Get(string id)
        {
            var city = _cityService.Get(id);
            if (city == null) return NotFound();
            return city;
        }
        [HttpPost]
        public ActionResult<City> Create(City city)
        {
            // _clientService.Create(client);
            //return CreatedAtRoute("GetClient", new { id = client.Id }, client);
            return _cityService.Create(city);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<City> Update(string id, City city)
        {
            var a = _cityService.Get(id);
            if (a == null) return NotFound();

            _cityService.Update(id, city);

            return Ok();
        }



        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();

            var city = _cityService.Get(id);
            if (city == null) return NotFound();
            _cityService.Delete(id);

            return Ok();
        }

    }
}
