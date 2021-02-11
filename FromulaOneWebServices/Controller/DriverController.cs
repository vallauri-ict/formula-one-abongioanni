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

        [HttpGet("")]
        [HttpGet("list")]
        public IEnumerable<Driver> Get() {
            var list = dbTools.GetDriverList(false);
            foreach (var driver in list) {
                driver.CountryCode = $"https://www.countryflags.io/{driver.CountryCode}/flat/64.png";
            }
            return list;
        }

        [HttpGet("{number}")]
        public Driver Get(int number) {
            var driver = dbTools.GetDriver(number);
            driver.CountryCode = $"https://www.countryflags.io/{driver.CountryCode}/flat/64.png";
            return driver;
        }
    }
}
