using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class TeamDriverDto {
        private int _driverNumber;
        private string _driverName;
        private Byte[] _driverImage;

        public TeamDriverDto(int driverNumber, string driverName, byte[] driverImage) {
            DriverNumber = driverNumber;
            DriverName = driverName;
            DriverImage = driverImage;
        }

        public int DriverNumber { get => _driverNumber; set => _driverNumber = value; }
        public string DriverName { get => _driverName; set => _driverName = value; }
        public byte[] DriverImage { get => _driverImage; set => _driverImage = value; }
    }

    public class TeamCardDto {
        private int _id;
        private Byte[] _smallLogo;
        private Byte[] _carImage;
        private string _color;
        private string _smallName;
        private TeamDriverDto[] _drivers;


        public TeamCardDto(Team team, Driver first, Driver second) {
            Id = team.Id;
            SmallLogo = team.SmallLogo;
            CarImage = team.CarImage;
            Color = team.Color;
            SmallName = team.SmallName;
            Drivers = new TeamDriverDto[] {
                new TeamDriverDto(first.Number,first.FullName,first.FullImage),
                new TeamDriverDto(second.Number,second.FullName,second.FullImage)
            };
        }

        public TeamCardDto(Team team, List<Driver> drivers, Country country) : this(team, drivers[0], drivers[1]) { }

        public TeamCardDto(Team team, Driver[] drivers, Country country) : this(team, drivers[0], drivers[1]) { }

        public TeamCardDto(Team team, (Driver, Driver) drivers) : this(team,drivers.Item1,drivers.Item2) { }

        public TeamCardDto(int id, byte[] smallLogo, byte[] carImage, string color, string smallName, TeamDriverDto[] drivers) {
            Id = id;
            SmallLogo = smallLogo;
            CarImage = carImage;
            Color = color;
            SmallName = smallName;
            Drivers = drivers;
        }

        public int Id { get => _id; set => _id = value; }
        public byte[] SmallLogo { get => _smallLogo; set => _smallLogo = value; }
        public byte[] CarImage { get => _carImage; set => _carImage = value; }
        public string Color { get => _color; set => _color = value; }
        public string SmallName { get => _smallName; set => _smallName = value; }
        public TeamDriverDto[] Drivers { get => _drivers; set => _drivers = value; }
    }
}
