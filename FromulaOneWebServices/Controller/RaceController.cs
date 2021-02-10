using FormulaOneDllProject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FromulaOneWebServices.Controller {
    [Route("api/race")]
    [ApiController]
    public class RaceController : ControllerBase {

        Tools dbTools = new Tools(Paths.CONNECTION_STRING);

        // GET: api/<RaceController>
        [HttpGet]
        public IEnumerable<Race> Get() {
            return dbTools.GetRaceList();
        }

        // GET api/<RaceController>/5
        [HttpGet("{id}")]
        public Race Get(int id) {
            return dbTools.GetRace(id);
        }

        // POST api/<RaceController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<RaceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<RaceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
