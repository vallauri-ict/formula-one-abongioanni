using System;
using System.Data;

namespace FormulaOneDllProject {
    internal class Driver {
        private string _helmetImage;
        private string _fullImage;
        private string _fullName;
        private int _number;
        private int _podiums;
        private string _countryIso2;
        private DateTime _dob;
        private Country _driverCountry;
        private int _teamId;

        public Driver(string helmetImage, string fullImage, string fullName, int number, string countryIso2, int podiums, DateTime dob, int teamId) {
            _helmetImage = helmetImage;
            _fullImage = fullImage;
            _fullName = fullName;
            _number = number;
            _podiums = podiums;
            _countryIso2 = countryIso2;
            _dob = dob;
            TeamId = teamId;
        }

        public Driver(DataRow r) {
            _helmetImage = r["helmet_image"].ToString().Trim();
            _fullImage = r["full_image"].ToString().Trim();
            _fullName = r["full_name"].ToString().Trim();
            _number = Convert.ToInt32(r["number"]);
            _podiums = Convert.ToInt32(r["podiums_number"]);
            _countryIso2 = r["country"].ToString().Trim();
            _teamId = Convert.ToInt32(r["team_id"]);
        }

        public string HelmetImage { get => _helmetImage; set => _helmetImage = value; }
        public string FullImage { get => _fullImage; set => _fullImage = value; }
        public string FullName { get => _fullName; set => _fullName = value; }
        public int Number { get => _number; set => _number = value; }
        public int Podiums { get => _podiums; set => _podiums = value; }
        public DateTime DateBirth { get => _dob; set => _dob = value; }
        public string CountryCode { get => _countryIso2; set => _countryIso2 = value; }
        public Country DriverCountry { get => _driverCountry; set => _driverCountry = value; }
        public int TeamId { get => _teamId; set => _teamId = value; }
    }
}
