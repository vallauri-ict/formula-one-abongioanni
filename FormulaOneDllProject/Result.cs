using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FormulaOneDllProject {
    class Result {
        int _raceId;
        int _driverId;
        int _teamId;
        int _position;
        string _time;
        int _laps;
        string _fastestLap;
        int _startPosition;
        string _qualifyingTime;
        string _notes;
        Driver _driver;
        Race _race;
        Team _team;

        public Result(int raceId, int driverId, int teamId, int position, string time, int laps, string fastestLap, int startPosition, string qualifyingTime, string notes) {
            _raceId = raceId;
            _driverId = driverId;
            _teamId = teamId;
            _position = position;
            _time = time;
            _laps = laps;
            _fastestLap = fastestLap;
            _startPosition = startPosition;
            _qualifyingTime = qualifyingTime;
            _notes = notes;
        }

        public Result(DataRow r) {
            _raceId = Convert.ToInt32(r["race_id"]);
            _driverId = Convert.ToInt32(r["driver_id"]);
            _teamId = Convert.ToInt32(r["team_id"]);
            _position = Convert.ToInt32(r["position"]);
            _time = r["time"].ToString().Trim();
            _time = $"{_time[0]}:{_time.Substring(1,2)}:{_time.Substring(3, 2)}.{_time.Substring(5)}";
            _laps = Convert.ToInt32(r["laps_number"]);
            _fastestLap = r["fastest_lap"].ToString().Trim();
            _fastestLap = $"{_fastestLap[0]}:{_fastestLap.Substring(1, 2)}.{_fastestLap.Substring(3)}";
            _startPosition = Convert.ToInt32(r["start_position"]);
            _qualifyingTime = r["qualifying_time"].ToString().Trim();
            _qualifyingTime = $"{_qualifyingTime[0]}:{_qualifyingTime.Substring(1, 2)}.{_qualifyingTime.Substring(3)}";
            _notes = r["notes"].ToString().Trim();
        }

        public int RaceId { get => _raceId; set => _raceId = value; }
        public int DriverId { get => _driverId; set => _driverId = value; }
        public int TeamId { get => _teamId; set => _teamId = value; }
        public int Position { get => _position; set => _position = value; }
        public string Time { get => _time; set => _time = value; }
        public int Laps { get => _laps; set => _laps = value; }
        public string FastestLap { get => _fastestLap; set => _fastestLap = value; }
        public int StartPosition { get => _startPosition; set => _startPosition = value; }
        public string QualifyingTime { get => _qualifyingTime; set => _qualifyingTime = value; }
        public string Notes { get => _notes; set => _notes = value; }
        public Driver Driver { get => _driver; set => _driver = value; }
        public Race Race { get => _race; set => _race = value; }
        public Team Team { get => _team; set => _team = value; }
    }
}
