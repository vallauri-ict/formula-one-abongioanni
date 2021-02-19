using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class CircuitDto {
        private string _id;
        private string _name;
        private string _countryImage;
        private string _countryName;
        private int _lapNumber;
        private int _turnNumber;
        private int _length;
        private string _firstRaceYear;
        private string _fastestLap;
        private Byte[] _fullImage;

        public CircuitDto(string id, string name, string countryImage, string countryName, int lapNumber, int turnNumber, int length, string firstRaceYear, string fastestLap, byte[] fullImage) {
            Id = id;
            Name = name;
            CountryImage = countryImage;
            CountryName = countryName;
            LapNumber = lapNumber;
            TurnNumber = turnNumber;
            Length = length;
            FirstRaceYear = firstRaceYear;
            FastestLap = fastestLap;
            FullImage = fullImage;
        }

        public CircuitDto(Circuit circuit,Country country) {
            Id = circuit.Id;
            Name = circuit.Name;
            CountryImage = $"https://www.countryflags.io/{circuit.CountryCode}/flat/64.png";
            CountryName = country.Name;
            LapNumber = circuit.LapNumber;
            TurnNumber = circuit.TurnNumber;
            Length = circuit.Length;
            FirstRaceYear = circuit.FirstRaceYear;
            FastestLap = circuit.FastestLap;
            FullImage = circuit.FullImage;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string CountryImage { get => _countryImage; set => _countryImage = value; }
        public string CountryName { get => _countryName; set => _countryName = value; }
        public int LapNumber { get => _lapNumber; set => _lapNumber = value; }
        public int TurnNumber { get => _turnNumber; set => _turnNumber = value; }
        public int Length { get => _length; set => _length = value; }
        public string FirstRaceYear { get => _firstRaceYear; set => _firstRaceYear = value; }
        public string FastestLap { get => _fastestLap; set => _fastestLap = value; }
        public byte[] FullImage { get => _fullImage; set => _fullImage = value; }
    }
}
