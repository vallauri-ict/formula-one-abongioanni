using FormulaOneDll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FromulaOneWebServices.Controller {
    [Route("api/result")]
    [ApiController]
    public class ResultController : ControllerBase {

        Tools dbTools = new Tools(Paths.CONNECTION_STRING);

        // LISTING ALL ELEMENTS

        [HttpGet("race")]
        [HttpGet("race/list")]
        public IEnumerable<string> GetRace() {
            List<string> names = new List<string>();
            foreach (DataRow row in dbTools.GetTable("SELECT DISTINCT name FROM Race,Result WHERE race_id=Race.id ORDER BY name ASC;").Rows) {
                names.Add(row.Field<string>("name"));
            }
            return names;
        }

        [HttpGet("driver")]
        [HttpGet("driver/list")]
        public IEnumerable<string> GetDriver() {
            List<string> names = new List<string>();
            foreach (DataRow row in dbTools.GetTable("SELECT full_name FROM Driver ORDER BY full_name ASC;").Rows) {
                names.Add(row.Field<string>("full_name"));
            }
            return names;
        }

        [HttpGet("team")]
        [HttpGet("team/list")]
        public IEnumerable<string> GetTeam() {
            List<string> names = new List<string>();
            foreach (DataRow row in dbTools.GetTable("SELECT small_name FROM Team ORDER BY small_name ASC;").Rows) {
                names.Add(row.Field<string>("small_name"));
            }
            return names;
        }

        /* RACE ******************************************/

        [HttpGet("race/all/result")]
        public IEnumerable<ResultRaceAllDto> GetRacesResult() {
            List<ResultRaceAllDto> list = new List<ResultRaceAllDto>();
            DataTable resultTable = dbTools.GetTable($"SELECT race_id,Race.name,Race.date_start,Driver.full_name,Team.small_name,Race.laps_number,Result.time FROM Race,Driver,Team,Result WHERE Race.id=Result.race_id AND Result.driver_id=Driver.number AND Result.team_id=Team.id AND (Result.driver_id=Driver.number AND Result.position=1);");
            foreach (DataRow row in resultTable.Rows) {
                list.Add(new ResultRaceAllDto(row));
            }
            return list;
        }

        [HttpGet("race/{id}/result")]
        public IEnumerable<ResultRaceDto> GetRaceResult(int id) {
            List<ResultRaceDto> list = new List<ResultRaceDto>();
            DataTable resultTable = dbTools.GetTable($"SELECT race_id,position,number,Driver.full_name,Team.small_name,laps_number,time FROM Driver,Team,Result WHERE Result.driver_id=Driver.number AND Result.team_id=Team.id AND Result.race_id={id};");
            foreach (DataRow row in resultTable.Rows) {
                list.Add(new ResultRaceDto(row));
            }
            return list;
        }

        [HttpGet("race/{id}/grid")]
        public IEnumerable<ResultRaceGridDto> GetRaceGrid(int id) {
            List<ResultRaceGridDto> list = new List<ResultRaceGridDto>();
            DataTable resultTable = dbTools.GetTable($"SELECT race_id,number,Driver.full_name,Team.small_name,start_position,qualifying_time FROM Driver,Team,Result WHERE Result.driver_id=Driver.number AND Result.team_id=Team.id AND Result.race_id={id} ORDER BY start_position ASC;");
            foreach (DataRow row in resultTable.Rows) {
                list.Add(new ResultRaceGridDto(row));
            }
            return list;
        }

        [HttpGet("race/{id}/fastest")]
        public IEnumerable<ResultRaceFastestDto> GetRaceFastest(int id) {
            List<ResultRaceFastestDto> list = new List<ResultRaceFastestDto>();
            DataTable resultTable = dbTools.GetTable($"SELECT race_id,number,Driver.full_name,Team.small_name,fastest_lap FROM Driver,Team,Result WHERE Result.driver_id=Driver.number AND Result.team_id=Team.id AND Result.race_id={id} ORDER BY fastest_lap ASC;");
            foreach (DataRow row in resultTable.Rows) {
                list.Add(new ResultRaceFastestDto(row));
            }
            return list;
        }

        /* DRIVER ******************************************/

        [HttpGet("driver/all")]
        public IEnumerable<ResultDriverAllDto> GetDriverAllPoints() {
            List<ResultDriverAllDto> list = new List<ResultDriverAllDto>();
            int ausNumber = int.MinValue;
            int number;
            bool isFirstElement = true;
            int i = 0;
            ResultDriverAllDto result = new ResultDriverAllDto();
            ResultDriverAllDto prevResult = new ResultDriverAllDto();

            DataTable resultTable = dbTools.GetTable($"SELECT Driver.number,Team.id, Driver.full_name,Driver.country,Team.small_name,Result.position FROM Driver,Team,Result WHERE Driver.number=Result.driver_id AND Driver.team_id=Team.id ORDER BY Driver.number ASC;");
            foreach (DataRow row in resultTable.Rows) {
                number = row.Field<int>("number");
                if (number > ausNumber) {
                    result = new ResultDriverAllDto(number, row.Field<string>("full_name"), row.Field<string>("country"), row.Field<string>("small_name"), row.Field<int>("id"), 0);
                    if (!isFirstElement) {
                        list.Add(prevResult);
                    }
                    ausNumber = number;
                }
                result.AddPoints(row.Field<int>("position"));
                prevResult = result;
                isFirstElement = false;
            }
            list.Add(prevResult);

            list = list.OrderByDescending(o => o.Points).ToList();
            i = 0;
            foreach (var r in list) {
                r.Position = i++ + 1;
            }
            return list;
        }

        [HttpGet("driver/{number}")]
        public IEnumerable<ResultDriverDto> GetDriverPoints(int number) {
            List<ResultDriverDto> list = new List<ResultDriverDto>();
            DataTable resultTable = dbTools.GetTable($"SELECT race_id,Race.name,Team.small_name,Driver.full_name,date_start,position,number FROM Driver,Team,Result,Race WHERE Result.race_id=Race.id AND Result.driver_id=Driver.number AND Result.team_id=Team.id AND Driver.number={number} ORDER BY date_start ASC;");
            foreach (DataRow row in resultTable.Rows) {
                list.Add(new ResultDriverDto(row));
            }
            return list;
        }

        /* TEAM ******************************************/

        [HttpGet("team/all")]
        public IEnumerable<ResultTeamAllDto> GetTeamAllPoints() {
            List<ResultTeamAllDto> list = new List<ResultTeamAllDto>();
            int ausId = int.MinValue;
            int id;
            bool isFirstElement = true;
            int i = 0;
            ResultTeamAllDto result = new ResultTeamAllDto();
            ResultTeamAllDto prevResult = new ResultTeamAllDto();

            DataTable resultTable = dbTools.GetTable($"SELECT Team.id, Team.small_name,Result.position FROM Driver,Team,Result WHERE Driver.number=Result.driver_id AND Driver.team_id=Team.id ORDER BY Team.id ASC;");
            foreach (DataRow row in resultTable.Rows) {
                id = row.Field<int>("id");
                if (id > ausId) {
                    result = new ResultTeamAllDto(id, row.Field<string>("small_name"), 0);
                    if (!isFirstElement) {
                        list.Add(prevResult);
                    }
                    ausId = id;
                }
                result.AddPoints(row.Field<int>("position"));
                prevResult = result;
                isFirstElement = false;
            }
            list.Add(prevResult);

            list = list.OrderByDescending(o => o.Points).ToList();
            i = 0;
            foreach (var r in list) {
                r.Position = i++ + 1;
            }
            return list;
        }


        [HttpGet("team/{id}")]
        public IEnumerable<ResultTeamDto> GetTeamPoints(int id) {
            List<ResultTeamDto> list = new List<ResultTeamDto>();
            DataTable resultTable = dbTools.GetTable($"SELECT race_id,Race.name,Team.id,Team.small_name,date_start,position FROM Team,Result,Race WHERE Result.race_id=Race.id AND Result.team_id=Team.id AND Team.id={id} ORDER BY date_start ASC;");

            bool isFirstElement = true;
            int ausPosition = 0;
            ResultTeamDto result = new ResultTeamDto();

            foreach (DataRow row in resultTable.Rows) {
                if (isFirstElement) {
                    ausPosition = row.Field<int>("position");
                    isFirstElement=false;
                }
                else {
                    result = new ResultTeamDto(row);
                    result.SetPoints(ausPosition, row.Field<int>("position"));
                    list.Add(result);
                    isFirstElement = true;
                }
            }

            return list;
        }
    }
}
