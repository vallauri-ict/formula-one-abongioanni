using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class ResultRaceAllDto {
        int _raceId;
        string _raceName;
        DateTime date;
        string _winnerName;
        string _winnerConstructor;
        int _lapsNumber;
        string _time;

        public ResultRaceAllDto(int raceId, string raceName, DateTime date, string winnerName, string winnerConstructor, int lapsNumber, string time) {
            this.RaceId = raceId;
            this.RaceName = raceName;
            this.Date = date;
            this.WinnerName = winnerName;
            this.WinnerConstructor = winnerConstructor;
            this.LapsNumber = lapsNumber;
            this.Time = time;
        }

        public ResultRaceAllDto(DataRow row) {
            this.RaceName = row.Field<string>("name");
            this.date = row.Field<DateTime>("date_start");
            this.WinnerName = row.Field<string>("full_name");
            this.WinnerConstructor = row.Field<string>("small_name");
            this.LapsNumber = row.Field<int>("laps_number");
            this.Time = row.Field<string>("time");
            this.RaceId = row.Field<int>("race_id");
        }

        public int RaceId { get => this._raceId; set => this._raceId = value; }
        public string RaceName { get => this._raceName; set => this._raceName = value; }
        public DateTime Date { get => this.date; set => this.date = value; }
        public string WinnerName { get => this._winnerName; set => this._winnerName = value; }
        public string WinnerConstructor { get => this._winnerConstructor; set => this._winnerConstructor = value; }
        public int LapsNumber { get => this._lapsNumber; set => this._lapsNumber = value; }
        public string Time { get => this._time; set => this._time = value; }
    }
}
