using FormulaOneDll;
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
        [HttpGet("cards")]
        public IEnumerable<TeamCardDto> Get() {
            List<TeamCardDto> teamList = new List<TeamCardDto>();
            foreach (Team team in dbTools.GetTeamList($"SELECT id, small_name, small_image, car_image, color FROM Team;")) {
                var driverResult = dbTools.GetDriverList($"SELECT number,full_image,full_name FROM Driver WHERE team_id={team.Id}");
                teamList.Add(new TeamCardDto(team, (driverResult[0], driverResult[1])));
            }
            return teamList;
        }

        [HttpGet("{id}")]
        public TeamDto GetById(int id) {

            var team = dbTools.GetTeamList($"SELECT * FROM Team WHERE id={id};")[0];
            var drivers = dbTools.GetDriverList($"SELECT number,full_image,full_name FROM Driver WHERE team_id={team.Id}");
            var country = dbTools.GetCountryList($"SELECT name FROM Country WHERE iso2='{team.CountryCode}';")[0];

            return new TeamDto(team, drivers, country);
        }
    }
}
