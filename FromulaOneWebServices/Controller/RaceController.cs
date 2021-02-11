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

        [HttpGet("")]
        [HttpGet("list")]
        public IEnumerable<Race> Get() {
            var list = dbTools.GetRaceList(false);
            foreach (var race in list) {
                race.Circuit.CountryCode = $"https://www.countryflags.io/{race.Circuit.CountryCode}/flat/64.png";
            }
            return list;
        }

        [HttpGet("{id}")]
        public Race Get(int id) {
            return dbTools.GetRace(id);
        }
    }
}
