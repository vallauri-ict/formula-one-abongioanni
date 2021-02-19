using FormulaOneDll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FromulaOneWebServices.Controller {
    [Route("api/race")]
    [ApiController]
    public class RaceController : ControllerBase {

        Tools dbTools = new Tools(Paths.CONNECTION_STRING);

        [HttpGet("")]
        [HttpGet("list")]
        public IEnumerable<RaceCardDto> Get() {
            List<RaceCardDto> raceList = new List<RaceCardDto>();
            foreach (Race race in dbTools.GetRaceList()) {

                var circuit = dbTools.GetCircuitList($"SELECT small_image,country FROM Circuit WHERE id='{race.CircuitId}';")[0];
                var country = dbTools.GetCountryList($"SELECT name FROM Country WHERE iso2='{circuit.CountryCode}';")[0];
                raceList.Add(new RaceCardDto(race, circuit, country));
            }
            return raceList;
        }

        [HttpGet("{id}")]
        public RaceCardDto Get(int id) {
            Race race = dbTools.GetRaceList($"SELECT * FROM Race WHERE id={id};")[0];
            var circuit = dbTools.GetCircuitList($"SELECT small_image,country FROM Circuit WHERE id='{race.CircuitId}';")[0];
            var country = dbTools.GetCountryList($"SELECT name FROM Country WHERE iso2='{circuit.CountryCode}';")[0];

            return new RaceCardDto(race, circuit, country);
        }
    }
}
