using System;
using System.Data;

namespace FormulaOneDllProject {
    internal class Team {
        private int _id;
        private string _smallLogo;
        private string _fullLogo;
        private string _carImage;
        private string _color;
        private string _smallName;
        private string _fullName;
        private string _base;
        private string _teamChief;
        private string _powerUnit;
        private string _countryCode;
        private int _worldChampionships;
        private Country _baseCountry;

        public Team(int id, string smallLogo, string fullLogo, string carImage, string color, string smallName, string fullName, string @base, string teamChief, string powerUnit, string countryCode, int worldChampionships) {
            _id = id;
            _smallLogo = smallLogo;
            _fullLogo = fullLogo;
            _carImage = carImage;
            _color = color;
            _smallName = smallName;
            _fullName = fullName;
            _base = @base;
            _teamChief = teamChief;
            _powerUnit = powerUnit;
            _countryCode = countryCode;
            _worldChampionships = worldChampionships;
        }

        public Team(DataRow r) {
            _id = Convert.ToInt32(r["id"]);
            _smallLogo = r["SmallLogo"].ToString().Trim();
            _fullLogo = r["FullLogo"].ToString().Trim();
            _carImage = r["CarImage"].ToString().Trim();
            _color = r["Color"].ToString().Trim();
            _smallName = r["SmallName"].ToString().Trim();
            _fullName = r["FullName"].ToString().Trim();
            _base = r["Base"].ToString().Trim();
            _teamChief = r["TeamChief"].ToString().Trim();
            _powerUnit = r["PowerUnit"].ToString().Trim();
            _countryCode = r["CountryCode"].ToString().Trim();
            _worldChampionships = Convert.ToInt32(r["WorldChampionships"]);
        }

        public int Id { get => _id; set => _id = value; }
        public string SmallLogo { get => _smallLogo; set => _smallLogo = value; }
        public string FullLogo { get => _fullLogo; set => _fullLogo = value; }
        public string CarImage { get => _carImage; set => _carImage = value; }
        public string Color { get => _color; set => _color = value; }
        public string SmallName { get => _smallName; set => _smallName = value; }
        public string FullName { get => _fullName; set => _fullName = value; }
        public string Base { get => _base; set => _base = value; }
        public string TeamChief { get => _teamChief; set => _teamChief = value; }
        public string PowerUnit { get => _powerUnit; set => _powerUnit = value; }
        public string CountryCode { get => _countryCode; set => _countryCode = value; }
        public int WorldChampionships { get => _worldChampionships; set => _worldChampionships = value; }
        public Country BaseCountry { get => _baseCountry; set => _baseCountry = value; }

    }
}
