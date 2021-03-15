using System;
using System.Data;

namespace FormulaOneDll {
    public class Team {
        public enum Fields {
            SmallName,
        }
        private int _id;
        private Byte[] _smallLogo;
        private Byte[] _fullLogo;
        private Byte[] _carImage;
        private string _color;
        private string _smallName;
        private string _fullName;
        private string _base;
        private string _teamChief;
        private string _puConstructor;
        private string _countryCode;
        private int _worldChampionships;
        private Country _baseCountry;
        private (Driver, Driver) _drivers;

        public Team(int id, Byte[] smallLogo, Byte[] fullLogo, Byte[] carImage, string color, string smallName, string fullName, string @base, string teamChief, string puConstructor, string countryCode, int worldChampionships) {
            _id = id;
            _smallLogo = smallLogo;
            _fullLogo = fullLogo;
            _carImage = carImage;
            _color = color;
            _smallName = smallName;
            _fullName = fullName;
            _base = @base;
            _teamChief = teamChief;
            _puConstructor = puConstructor;
            _countryCode = countryCode;
            _worldChampionships = worldChampionships;
        }

        public Team(DataRow r) {
            _color = r["color"].ToString().Trim();
            _smallName = r["small_name"].ToString().Trim();
            _id = Convert.ToInt32(r["id"]);

            if (r.ItemArray.Length > 3) {
                _smallLogo = (Byte[])r["small_image"];
                _carImage = (Byte[])r["car_image"];

                if (r.ItemArray.Length > 5) {
                    _fullLogo = (Byte[])r["full_image"];
                    _fullName = r["full_name"].ToString().Trim();
                    _base = r["base"].ToString().Trim();
                    _teamChief = r["chief"].ToString().Trim();
                    _puConstructor = r["pu_constructor"].ToString().Trim();
                    _countryCode = r["country"].ToString().Trim();
                    _worldChampionships = Convert.ToInt32(r["championships_number"]);
                }
            }
        }

        public void SetDrivers(Driver d1, Driver d2) {
            _drivers.Item1 = d1;
            _drivers.Item2 = d2;
        }

        public void SetDrivers((Driver, Driver) drivers) {
            _drivers.Item1 = drivers.Item1;
            _drivers.Item2 = drivers.Item2;
        }

        public int Id { get => _id; set => _id = value; }
        public Byte[] SmallLogo { get => _smallLogo; set => _smallLogo = value; }
        public Byte[] FullLogo { get => _fullLogo; set => _fullLogo = value; }
        public Byte[] CarImage { get => _carImage; set => _carImage = value; }
        public string Color { get => _color; set => _color = value; }
        public string SmallName { get => _smallName; set => _smallName = value; }
        public string FullName { get => _fullName; set => _fullName = value; }
        public string Base { get => _base; set => _base = value; }
        public string TeamChief { get => _teamChief; set => _teamChief = value; }
        public string PuConstructor { get => _puConstructor; set => _puConstructor = value; }
        public string CountryCode { get => _countryCode; set => _countryCode = value; }
        public int WorldChampionships { get => _worldChampionships; set => _worldChampionships = value; }
        public Country BaseCountry { get => _baseCountry; set => _baseCountry = value; }
        public (Driver, Driver) Drivers { get => _drivers; }
    }
}
