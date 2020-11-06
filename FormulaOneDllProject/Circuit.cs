﻿using System;
using System.Data;

namespace FormulaOneDllProject {
    internal class Circuit {
        private string _id;
        private string _name;
        private string _countryIso2;
        private int _lapNumber;
        private int _turnNumber;
        private int _length;
        private string _firstRaceYear;
        private string _fastestLap;
        private string _smallImage;
        private string _fullImage;
        private Country _country;



        public Circuit(DataRow r) {
            Id = r["id"].ToString().Trim();
            Name = r["name"].ToString().Trim();
            CountryIso2 = r["country"].ToString().Trim();
            LapNumber = Convert.ToInt32(r["laps_number"]);
            TurnNumber = Convert.ToInt32(r["turns_number"]);
            Length = Convert.ToInt32(r["length"]);
            FirstRaceYear = r["first_race_year"].ToString().Trim();
            FastestLap = r["fastest_lap"].ToString().Trim();
            SmallImage = r["full_image"].ToString().Trim();
            FullImage = r["small_image"].ToString().Trim();
        }

        public Circuit(string id, string name, string countryIso2, int lapNumber, int turnNumber, int length, string firstRaceYear, string fastestLap, string smallImage, string fullImage) {
            Id = id;
            Name = name;
            CountryIso2 = countryIso2;
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
        public string CountryIso2 { get => _countryIso2; set => _countryIso2 = value; }
        public int LapNumber { get => _lapNumber; set => _lapNumber = value; }
        public int TurnNumber { get => _turnNumber; set => _turnNumber = value; }
        public int Length { get => _length; set => _length = value; }
        public string FirstRaceYear { get => _firstRaceYear; set => _firstRaceYear = value; }
        public string FastestLap { get => _fastestLap; set => _fastestLap = value; }
        public string SmallImage { get => _smallImage; set => _smallImage = value; }
        public string FullImage { get => _fullImage; set => _fullImage = value; }
        public Country Country { get => _country; set => _country = value; }
    }
}
