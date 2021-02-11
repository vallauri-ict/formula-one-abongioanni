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

        [HttpGet("")]
        [HttpGet("list")]
        public IEnumerable<Country> Get() {
            return dbTools.GetCountryList();
        }

        [HttpGet("{id}")]
        public Country Get(string id) {
            return dbTools.GetCountry("iso2", id);
        }

        [HttpGet("{field}/{value}")]
        public Country Get(string field, string value) {
            return dbTools.GetCountry(field, value);
        }
    }
}
