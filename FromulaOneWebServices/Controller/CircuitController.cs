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

        [HttpGet("")]
        [HttpGet("list")]
        public IEnumerable<Circuit> Get() {
            return dbTools.GetCircuitList();
        }

        [HttpGet("{id}")]
        public Circuit Get(string id) {
            return dbTools.GetCircuit(id);
        }

        // [HttpGet("{field}/{value}")]

    }
}
