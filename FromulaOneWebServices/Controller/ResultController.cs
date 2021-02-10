using FormulaOneDllProject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FromulaOneWebServices.Controller {
    [Route("api/result")]
    [ApiController]
    public class ResultController : ControllerBase {

        Tools dbTools = new Tools(Paths.CONNECTION_STRING);

        // GET: api/<ResultController>
        [HttpGet]
        public IEnumerable<Result> Get() {
            return dbTools.GetResultList();
        }

        // GET api/<ResultController>/5
        [HttpGet("{id}")]
        public Result Get(int id) {
            return dbTools.GetResult(id);
        }

        // POST api/<ResultController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<ResultController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<ResultController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
