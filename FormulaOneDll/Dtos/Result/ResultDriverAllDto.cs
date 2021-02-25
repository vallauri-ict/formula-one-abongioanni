using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class ResultDriverAllDto {

        private int _driverNumber;
        private string _driverName;
        private string _countryCode;
        private string _teamName;
        private int _teamId;
        private int _points;

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

        public int DriverNumber { get => _driverNumber; set => _driverNumber = value; }
        public string DriverName { get => _driverName; set => _driverName = value; }
        public string CountryCode { get => _countryCode; set => _countryCode = value; }
        public string TeamName { get => _teamName; set => _teamName = value; }
        public int TeamId { get => _teamId; set => _teamId = value; }
        public int Points { get => _points; set => _points = value; }
    }
}
