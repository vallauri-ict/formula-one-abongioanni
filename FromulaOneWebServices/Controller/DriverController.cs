﻿using FormulaOneDll;
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

        [HttpGet("")]
        [HttpGet("list")]
        [HttpGet("cards")]
        public IEnumerable<DriverCardDto> Get() {
            List<DriverCardDto> driverList = new List<DriverCardDto>();
            foreach (Driver driver in dbTools.GetDriverList($"SELECT number, full_name, full_image, country,team_id FROM Driver;")) {
                driverList.Add(new DriverCardDto(driver, dbTools.GetTeamList($"SELECT id,small_name,color FROM Team WHERE id={driver.TeamId};")[0]));
            }
            return driverList;
        }

        [HttpGet("{number}")]
        [HttpGet("{id}")]
        public DriverDto Get(int number) {
            var driver = dbTools.GetDriverList($"SELECT * FROM Driver WHERE number={number};")[0];
            var team = dbTools.GetTeamList($"SELECT id,small_name,color FROM Team WHERE id={driver.TeamId};")[0];
            var country = dbTools.GetCountryList($"SELECT name FROM Country WHERE iso2='{driver.CountryCode}';")[0];

            return new DriverDto(driver, team, country);
        }
    }
}
