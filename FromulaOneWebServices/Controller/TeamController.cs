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

        [HttpGet("")]
        [HttpGet("list")]
        public IEnumerable<Team> Get() {
            return dbTools.GetTeamList(false);
        }

        [HttpGet("{id}")]
        public Team Get(int id) {
            return dbTools.GetTeam(id);
        }
    }
}
