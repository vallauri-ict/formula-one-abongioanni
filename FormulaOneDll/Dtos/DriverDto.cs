using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class DriverDto {
        private Byte[] _helmetImage;
        private Byte[] _fullImage;
        private string _fullName;
        private int _number;
        private int _podiums;
        private string _countryCode;
        private string _countryName;
        private string _countryImage;
        private DateTime _dob;
        private int _teamId;
        private string _teamName;

        public DriverDto() { }

        public DriverDto(byte[] helmetImage, byte[] fullImage, string fullName, int number, int podiums, string countryCode, string countryName, DateTime dob, int teamId, string teamName) {
            HelmetImage = helmetImage;
            FullImage = fullImage;
            FullName = fullName;
            Number = number;
            Podiums = podiums;
            CountryCode = countryCode;
            CountryName = countryName;
            Dob = dob;
            TeamId = teamId;
            TeamName = teamName;
            CountryImage = $"https://www.countryflags.io/{countryCode}/flat/64.png";
        }

        public DriverDto(Driver driver,Team team,Country country) {
            HelmetImage = driver.HelmetImage;
            FullImage = driver.FullImage;
            FullName = driver.FullName;
            Number = driver.Number;
            Podiums = driver.Podiums;
            CountryCode = driver.CountryCode;
            CountryName = country.Name;
            Dob = driver.DateBirth;
            TeamId = team.Id;
            TeamName = team.SmallName;
            CountryImage = $"https://www.countryflags.io/{driver.CountryCode}/flat/64.png";
        }

        public byte[] HelmetImage { get => _helmetImage; set => _helmetImage = value; }
        public byte[] FullImage { get => _fullImage; set => _fullImage = value; }
        public string FullName { get => _fullName; set => _fullName = value; }
        public int Number { get => _number; set => _number = value; }
        public int Podiums { get => _podiums; set => _podiums = value; }
        public string CountryCode { get => _countryCode; set => _countryCode = value; }
        public string CountryName { get => _countryName; set => _countryName = value; }
        public DateTime Dob { get => _dob; set => _dob = value; }
        public int TeamId { get => _teamId; set => _teamId = value; }
        public string TeamName { get => _teamName; set => _teamName = value; }
        public string CountryImage { get => _countryImage; set => _countryImage = value; }
    }
}
