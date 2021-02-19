using System;
using System.Data;

namespace FormulaOneDll {
    public class Circuit {
        private string _id;
        private string _name;
        private string _countryCode;
        private int _lapNumber;
        private int _turnNumber;
        private int _length;
        private string _firstRaceYear;
        private string _fastestLap;
        private Byte[] _smallImage;
        private Byte[] _fullImage;
        private Country _country;

        public Circuit() { }

        public Circuit(DataRow r) {
            SmallImage = (Byte[])r["small_image"];
            CountryCode = r["country"].ToString().Trim();
            if (r.ItemArray.Length > 2) {

                Id = r["id"].ToString().Trim();
                Name = r["name"].ToString().Trim();
                CountryCode = r["country"].ToString().Trim();
                TurnNumber = Convert.ToInt32(r["turns_number"]);
                Length = Convert.ToInt32(r["length"]);
                FirstRaceYear = r["first_race_year"].ToString().Trim();
                FastestLap = r["fastest_lap"].ToString().Trim();
                FullImage = (Byte[])r["full_image"];
            }
        }

        public Circuit(string id, string name, string countryIso2, int lapNumber, int turnNumber, int length, string firstRaceYear, string fastestLap, Byte[] smallImage, Byte[] fullImage) {
            Id = id;
            Name = name;
            CountryCode = countryIso2;
            LapNumber = lapNumber;
            TurnNumber = turnNumber;
            Length = length;
            FirstRaceYear = firstRaceYear;
            FastestLap = fastestLap;
            SmallImage = smallImage;
            FullImage = fullImage;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string CountryCode { get => _countryCode; set => _countryCode = value; }
        public int LapNumber { get => _lapNumber; set => _lapNumber = value; }
        public int TurnNumber { get => _turnNumber; set => _turnNumber = value; }
        public int Length { get => _length; set => _length = value; }
        public string FirstRaceYear { get => _firstRaceYear; set => _firstRaceYear = value; }
        public string FastestLap { get => _fastestLap; set => _fastestLap = value; }
        public Byte[] SmallImage { get => _smallImage; set => _smallImage = value; }
        public Byte[] FullImage { get => _fullImage; set => _fullImage = value; }
        public Country Country { get => _country; set => _country = value; }
    }
}
