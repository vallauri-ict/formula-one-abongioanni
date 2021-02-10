using FormulaOneDllProject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FromulaOneWebServices.Controller {
    [Route("api/circuit")]
    [ApiController]
    public class CircuitController : ControllerBase {

        Tools dbTools = new Tools(Paths.CONNECTION_STRING);

        // GET: api/<CircuitController>
        [HttpGet]
        public IEnumerable<Circuit> Get() {
            return dbTools.GetCircuitList();
        }

        // GET api/<CircuitController>/5
        [HttpGet("{id}")]
        public Circuit Get(string id) {
            return dbTools.GetCircuit(id);
        }

        // POST api/<CircuitController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<CircuitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<CircuitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
