using FormulaOneDllProject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FromulaOneWebServices {
    [Route("api/team")]
    [ApiController]
    public class TeamController : ControllerBase {

        Tools dbTools = new Tools(Paths.CONNECTION_STRING);

        // GET: api/<TeamController>
        [HttpGet]
        public IEnumerable<Team> Get() {
            return dbTools.GetTeamList();
        }

        // GET api/<TeamController>/5
        [HttpGet("{id}")]
        public Team Get(int id) {
            return dbTools.GetTeam(id);
        }

        // POST api/<TeamController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<TeamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<TeamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
