using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class ResultTeamDto {
        private int _raceId;
        private string _raceName;
        private int _teamId;
        private string _teamName;
        private DateTime _date;
        private int _points;
        private int[] points = { 25, 18, 15, 12, 10, 8, 6, 4, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public ResultTeamDto() {
        }

        public ResultTeamDto(DataRow row) {
            RaceId =row.Field<int>("race_id");
            RaceName = row.Field<string>("name");
            Date = row.Field<DateTime>("date_start");
            TeamId = row.Field<int>("id");
            TeamName = row.Field<string>("small_name");
        }

        public ResultTeamDto(int raceId, string raceName, DateTime date, int points, int teamId, string teamName) {
            RaceId = raceId;
            RaceName = raceName;
            Date = date;
            TeamId = teamId;
            TeamName = teamName;
        }

        public int RaceId { get => _raceId; set => _raceId = value; }
        public string RaceName { get => _raceName; set => _raceName = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public int Points { get => _points; }
        public int TeamId { get => _teamId; set => _teamId = value; }
        public string TeamName { get => _teamName; set => _teamName = value; }

        public void SetPoints(int p1,int p2) {
            _points = points[p1 - 1] + points[p2 - 1];
        }
    }
}
