using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class ResultDriverDto {

        private int _raceId;
        private string _raceName;
        private int _driverNumber;
        private string _driverName;
        private DateTime _raceDate;
        private string _teamName;
        private int _position;
        private int[] points = { 25, 18, 15, 12, 10, 8, 6, 4, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public ResultDriverDto(DataRow row) {
            RaceId = row.Field<int>("race_id");
            RaceName = row.Field<string>("name");
            DriverNumber = row.Field<int>("number");
            DriverName = row.Field<string>("full_name");
            RaceDate = row.Field<DateTime>("date_start");
            Position = row.Field<int>("position");
        }

        public ResultDriverDto(int raceId, string raceName, int driverNumber, string driverName, DateTime raceDate, string teamName, int position, int points) {
            RaceId = raceId;
            RaceName = raceName;
            DriverNumber = driverNumber;
            DriverName = driverName;
            RaceDate = raceDate;
            TeamName = teamName;
            Position = position;
        }

        public int RaceId { get => _raceId; set => _raceId = value; }
        public string RaceName { get => _raceName; set => _raceName = value; }
        public int DriverNumber { get => _driverNumber; set => _driverNumber = value; }
        public string DriverName { get => _driverName; set => _driverName = value; }
        public DateTime RaceDate { get => _raceDate; set => _raceDate = value; }
        public string TeamName { get => _teamName; set => _teamName = value; }
        public int Position { get => _position; set => _position = value; }
        public int Points { get => points[Position-1];  }
    }
}
