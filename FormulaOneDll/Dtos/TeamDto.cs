using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class TeamDto {
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
        private string _countryName;
        private int _worldChampionships;
        private TeamDriverDto[] _drivers;

        public TeamDto(Team team, Driver first, Driver second, Country country) {
            Id = team.Id;
            SmallLogo = team.SmallLogo;
            FullLogo = team.FullLogo;
            CarImage = team.CarImage;
            Color = team.Color;
            SmallName = team.SmallName;
            FullName = team.FullName;
            Base = team.Base;
            TeamChief = team.TeamChief;
            PuConstructor = team.PuConstructor;
            CountryName = country.Name;
            WorldChampionships = team.WorldChampionships;
            Drivers = new TeamDriverDto[] {
                new TeamDriverDto(first.Number,first.FullName,first.FullImage),
                new TeamDriverDto(second.Number,second.FullName,second.FullImage)
            };
        }

        public TeamDto(Team team, List<Driver> drivers, Country country) : this(team, drivers[0], drivers[1], country) { }

        public TeamDto(Team team,Driver[] drivers, Country country) : this(team, drivers[0], drivers[1], country) { }

        public TeamDto(Team team, (Driver, Driver) drivers, Country country) : this(team, drivers.Item1, drivers.Item2, country) { }

        public TeamDto(int id, byte[] smallLogo, byte[] fullLogo, byte[] carImage, string color, string smallName, string fullName, string @base, string teamChief, string puConstructor, string countryName, int worldChampionships, TeamDriverDto[] drivers) {
            Id = id;
            SmallLogo = smallLogo;
            FullLogo = fullLogo;
            CarImage = carImage;
            Color = color;
            SmallName = smallName;
            FullName = fullName;
            Base = @base;
            TeamChief = teamChief;
            PuConstructor = puConstructor;
            CountryName = countryName;
            WorldChampionships = worldChampionships;
            Drivers = drivers;
        }

        public int Id { get => _id; set => _id = value; }
        public byte[] SmallLogo { get => _smallLogo; set => _smallLogo = value; }
        public byte[] FullLogo { get => _fullLogo; set => _fullLogo = value; }
        public byte[] CarImage { get => _carImage; set => _carImage = value; }
        public string Color { get => _color; set => _color = value; }
        public string SmallName { get => _smallName; set => _smallName = value; }
        public string FullName { get => _fullName; set => _fullName = value; }
        public string Base { get => _base; set => _base = value; }
        public string TeamChief { get => _teamChief; set => _teamChief = value; }
        public string PuConstructor { get => _puConstructor; set => _puConstructor = value; }
        public string CountryName { get => _countryName; set => _countryName = value; }
        public int WorldChampionships { get => _worldChampionships; set => _worldChampionships = value; }
        public TeamDriverDto[] Drivers { get => _drivers; set => _drivers = value; }
    }
}
