using FormulaOneDll;
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
        [HttpGet("card")]
        public IEnumerable<CircuitDto> GetCards() {
            List<CircuitDto> circuitList = new List<CircuitDto>();
            foreach (Circuit circuit in dbTools.GetCircuitList()) {
                var country = dbTools.GetCountryList($"SELECT name FROM Country WHERE iso2='{circuit.CountryCode}';")[0];
                circuitList.Add(new CircuitDto(circuit, country));
            }
            return circuitList;
        }

        [HttpGet("{id}")]
        public CircuitDto GetById(string id) {
            Circuit circuit = dbTools.GetCircuitList($"SELECT * FROM Circuit WHERE id='{id}';")[0];
            var country = dbTools.GetCountryList($"SELECT name FROM Country WHERE iso2='{circuit.CountryCode}';")[0];

            return new CircuitDto(circuit, country);
        }

        // [HttpGet("{field}/{value}")]

    }
}
