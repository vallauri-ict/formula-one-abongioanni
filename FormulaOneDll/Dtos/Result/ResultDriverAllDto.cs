using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class ResultDriverAllDto {

        private int _position;
        private int _driverNumber;
        private string _driverName;
        private string _countryCode;
        private string _teamName;
        private int _teamId;
        private int _points;
        private int[] points = { 25, 18, 15, 12, 10, 8, 6, 4, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0 ,0,0};

        public ResultDriverAllDto(DataRow row) {
        }

        public ResultDriverAllDto(int driverNumber, string driverName, string countryCode, string teamName, int teamId, int points) {
            DriverNumber = driverNumber;
            DriverName = driverName;
            CountryCode = countryCode;
            TeamName = teamName;
            TeamId = teamId;
            Points = points;
        }

        public ResultDriverAllDto() {
        }

        public void AddPoints(int position) {
            this.Points += points[position - 1];
        }

        public int Position { get => _position; set => _position = value; }
        public int DriverNumber { get => _driverNumber; set => _driverNumber = value; }
        public string DriverName { get => _driverName; set => _driverName = value; }
        public string CountryCode { get => _countryCode; set => _countryCode = value; }
        public string TeamName { get => _teamName; set => _teamName = value; }
        public int TeamId { get => _teamId; set => _teamId = value; }
        public int Points { get => _points; set => _points = value; }
    }
}
