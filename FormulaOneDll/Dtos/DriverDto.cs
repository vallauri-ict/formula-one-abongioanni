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
        private int _podiumsCount;
        private string _countryCode;
        private string _countryName;
        private string _countryImage;
        private DateTime _dob;
        private int _teamId;
        private string _teamName;
        private Dictionary<string, string> _seasonStats;

        public DriverDto() { }

        public DriverDto(Driver driver,Team team,Country country,DataRow stats) {
            HelmetImage = driver.HelmetImage;
            FullImage = driver.FullImage;
            FullName = driver.FullName;
            Number = driver.Number;
            PodiumsCount = driver.Podiums;
            CountryCode = driver.CountryCode;
            CountryName = country.Name;
            Dob = driver.DateBirth;
            TeamId = team.Id;
            TeamName = team.SmallName;
            CountryImage = $"https://www.countryflags.io/{driver.CountryCode}/flat/64.png";
            
            _seasonStats = new Dictionary<string, string>() {
                {"points", stats.Field<int>("points").ToString() },
                {"winCount", stats.Field<int>("win_count").ToString() },
                {"secondCount", stats.Field<int>("second_count").ToString() },
                {"thirdCount", stats.Field<int>("third_count").ToString() },
                {"podiumCount", (stats.Field<int>("win_count")+stats.Field<int>("second_count")+stats.Field<int>("third_count")).ToString() },
                {"poleCount", stats.Field<int>("pole_count").ToString() },
                {"fastLapCount", stats.Field<int>("fast_count").ToString() },
                {"pointAvg", stats.Field<double>("points_avg").ToString() },
            };
        }

        public byte[] HelmetImage { get => _helmetImage; set => _helmetImage = value; }
        public byte[] FullImage { get => _fullImage; set => _fullImage = value; }
        public string FullName { get => _fullName; set => _fullName = value; }
        public int Number { get => _number; set => _number = value; }
        public int PodiumsCount { get => _podiumsCount; set => _podiumsCount = value; }
        public string CountryCode { get => _countryCode; set => _countryCode = value; }
        public string CountryName { get => _countryName; set => _countryName = value; }
        public DateTime Dob { get => _dob; set => _dob = value; }
        public int TeamId { get => _teamId; set => _teamId = value; }
        public string TeamName { get => _teamName; set => _teamName = value; }
        public string CountryImage { get => _countryImage; set => _countryImage = value; }
        public Dictionary<string, string> SeasonStats { get => _seasonStats; }
    }
}
