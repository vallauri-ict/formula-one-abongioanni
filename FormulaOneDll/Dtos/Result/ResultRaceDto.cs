using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class ResultRaceDto {
        private int _raceId;
        private int _position;
        private int _driverNumber;
        private string _driverName;
        private string _teamName;
        private int _lapNumber;
        private string _time;

        public ResultRaceDto(DataRow row) {
            this.Position = row.Field<int>("position");
            this.DriverNumber = row.Field<int>("number");
            this.DriverName = row.Field<string>("full_name");
            this.TeamName = row.Field<string>("small_name");
            this.LapNumber = row.Field<int>("laps_number");
            this.Time = row.Field<string>("time");
            this.RaceId = row.Field<int>("race_id");
        }

        public ResultRaceDto(int position, int driverNumber, string driverName, string teamName, int lapNumber, string time, int raceId) {
            this.Position = position;
            this.DriverNumber = driverNumber;
            this.DriverName = driverName;
            this.TeamName = teamName;
            this.LapNumber = lapNumber;
            this.Time = time;
            this.RaceId = raceId;
        }

        public int Position { get => this._position; set => this._position = value; }
        public int DriverNumber { get => this._driverNumber; set => this._driverNumber = value; }
        public string DriverName { get => this._driverName; set => this._driverName = value; }
        public string TeamName { get => this._teamName; set => this._teamName = value; }
        public int LapNumber { get => this._lapNumber; set => this._lapNumber = value; }
        public string Time { get => this._time; set => this._time = value; }
        public int RaceId { get => this._raceId; set => this._raceId = value; }
    }
}
