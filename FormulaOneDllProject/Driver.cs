using System;
using System.Data;

namespace FormulaOneDllProject {
    internal class Driver {
        private int _id;
        private string _helmetImage;
        private string _fullImage;
        private string _fullName;
        private int _number;
        private int _podiums;
        private string _countryCode;
        private DateTime _dob;
        private Country _driverCountry;

        public Driver(int id, string helmetImage, string fullImage, string fullName, int number, string countryCode, int podiums, DateTime dob) {
            _id = id;
            _helmetImage = helmetImage;
            _fullImage = fullImage;
            _fullName = fullName;
            _number = number;
            _podiums = podiums;
            _countryCode = countryCode;
            _dob = dob;
        }

        public Driver(DataRow r) {
            _id = Convert.ToInt32(r["id"]);
            _helmetImage = r["HelmetImage"].ToString().Trim();
            _fullImage = r["FullImage"].ToString().Trim();
            _fullName = r["FullName"].ToString().Trim();
            _number = Convert.ToInt32(r["Number"]);
            _podiums = Convert.ToInt32(r["Podiums"]);
            _countryCode = r["CountryCode"].ToString().Trim();
        }

        public int Id { get => _id; set => _id = value; }
        public string HelmetImage { get => _helmetImage; set => _helmetImage = value; }
        public string FullImage { get => _fullImage; set => _fullImage = value; }
        public string FullName { get => _fullName; set => _fullName = value; }
        public int Number { get => _number; set => _number = value; }
        public int Podiums { get => _podiums; set => _podiums = value; }
        public DateTime Dob { get => _dob; set => _dob = value; }
        public string CountryCode { get => _countryCode; set => _countryCode = value; }
        public Country DriverCountry { get => _driverCountry; set => _driverCountry = value; }
    }
}
