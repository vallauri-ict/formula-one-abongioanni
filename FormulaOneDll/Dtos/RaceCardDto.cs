using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class RaceCardDto {
        private string _id;
        private string _name;
        private string _circuitId;
        private DateTime _dateStart;
        private Byte[] _circuitSmallImage;
        private string _countryImage;
        private string _countryName;

        public RaceCardDto(string id, string name, string circuitId, DateTime dateStart, Byte[] circuitSmallImage, string countryCode, string countryName) {
            Id = id;
            Name = name;
            CircuitId = circuitId;
            DateStart = dateStart;
            CircuitSmallImage = circuitSmallImage;
            CountryImage = $"https://www.countryflags.io/{countryCode}/flat/64.png";
            CountryName = countryName;
        }

        public RaceCardDto(Race race,Circuit circuit,Country country) {
            Id = race.Id;
            Name = race.Name;
            CircuitId = race.CircuitId;
            DateStart = race.DateStart;
            CircuitSmallImage = circuit.SmallImage;
            CountryImage = $"https://www.countryflags.io/{country.IsoCode}/flat/64.png";
            CountryName = country.Name;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string CircuitId { get => _circuitId; set => _circuitId = value; }
        public DateTime DateStart { get => _dateStart; set => _dateStart = value; }
        public Byte[] CircuitSmallImage { get => _circuitSmallImage; set => _circuitSmallImage = value; }
        public string CountryImage { get => _countryImage; set => _countryImage = value; }
        public string CountryName { get => _countryName; set => _countryName = value; }
    }
}
