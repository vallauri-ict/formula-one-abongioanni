using FormulaOneDllProject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FromulaOneWebServices {
    [Route("api/driver")]
    [ApiController]
    public class DriverController : ControllerBase {

        Tools dbTools = new Tools(Paths.CONNECTION_STRING);

        // GET: api/<DriverController>
        [HttpGet]
        public IEnumerable<Driver> Get() {
            return dbTools.GetDriverList();
        }

        // GET api/<DriverController>/5
        [HttpGet("{number}")]
        public Driver Get(int number) {
            return dbTools.GetDriver(number);
        }

        // POST api/<DriverController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
