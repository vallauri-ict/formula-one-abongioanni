using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class DriverCardDto {
        private Byte[] _fullImage;
        private string _fullName;
        private int _number;
        private string _countryImage;
        private int _teamId;
        private string _teamName;
        private string _teamColor;

        public DriverCardDto(Driver driver, Team team) {
            FullImage = driver.FullImage;
            FullName = driver.FullName;
            Number = driver.Number;
            CountryImage = $"https://www.countryflags.io/{driver.CountryCode}/flat/64.png";
            TeamId = team.Id;
            TeamName = team.SmallName;
            TeamColor = team.Color;
        }

        public DriverCardDto() { }

        public DriverCardDto(byte[] fullImage, string fullName, int number, string countryCode, int teamId, string teamName, string teamColor) {
            FullImage = fullImage;
            FullName = fullName;
            Number = number;
            CountryImage = $"https://www.countryflags.io/{countryCode}/flat/64.png";
            TeamId = teamId;
            TeamName = teamName;
            TeamColor = teamColor;
        }

        public Byte[] FullImage { get => _fullImage; set => _fullImage = value; }
        public string FullName { get => _fullName; set => _fullName = value; }
        public int Number { get => _number; set => _number = value; }
        public string CountryImage { get => _countryImage; set => _countryImage = value; }
        public int TeamId { get => _teamId; set => _teamId = value; }
        public string TeamName { get => _teamName; set => _teamName = value; }
        public string TeamColor { get => _teamColor; set => _teamColor = value; }
    }
}
