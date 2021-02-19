using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class ResultRaceFastestDto {
        private int _raceId;
        private int _position;
        private int _driverNumber;
        private string _driverName;
        private string _teamName;
        private string _time;

        public ResultRaceFastestDto(int position, int driverNumber, string driverName, string teamName, string time, int raceId) {
            this._position = position;
            this._driverNumber = driverNumber;
            this._driverName = driverName;
            this._teamName = teamName;
            this._time = time;
            this.RaceId = raceId;
        }

        public ResultRaceFastestDto(DataRow row) {
            this.DriverNumber = row.Field<int>("number");
            this.DriverName = row.Field<string>("full_name");
            this.TeamName = row.Field<string>("small_name");
            this.Time = row.Field<string>("fastest_lap");
            this.RaceId = row.Field<int>("race_id");
        }

        public int Position { get => this._position; set => this._position = value; }
        public int DriverNumber { get => this._driverNumber; set => this._driverNumber = value; }
        public string DriverName { get => this._driverName; set => this._driverName = value; }
        public string TeamName { get => this._teamName; set => this._teamName = value; }
        public string Time { get => this._time; set => this._time = value; }
        public int RaceId { get => this._raceId; set => this._raceId = value; }
    }
}
