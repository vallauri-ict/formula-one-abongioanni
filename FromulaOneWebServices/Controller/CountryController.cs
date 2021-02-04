using FormulaOneDllProject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FromulaOneWebServices {
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase {

        Tools dbTools = new Tools(Paths.CONNECTION_STRING);

        // GET: api/<CountryController>
        [HttpGet]
        public IEnumerable<Country> Get() {
            return dbTools.GetCountryList();
        }

        // GET api/<CountryController>/IT
        [HttpGet("{id}")]
        public Country Get(string id) {
            return dbTools.GetCountry(id);
        }

        // POST api/<CountryController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
