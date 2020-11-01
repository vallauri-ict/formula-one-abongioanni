using System;
using System.Data;

namespace FormulaOneDllProject {
    internal class Circuit {
        private string _circuitId;
        private string _circuitName;
        private string _countryCode;
        private int _lapNumber;
        private int _turnNumber;
        private int _circuitLength;
        private string _firstGpHostYear;
        private string _fastestLap;
        private string _thumbnailImage;
        private string _descriptionImage;
        private Country _country;

        public Circuit(string circuitId, string circuitName, string countryCode, int lapNumber, int turnNumber, int circuitLength, string firstGpHostYear, string fastestLap, string thumbnailImage, string descriptionImage) {
            _circuitId = circuitId;
            _circuitName = circuitName;
            _countryCode = countryCode;
            _lapNumber = lapNumber;
            _turnNumber = turnNumber;
            _circuitLength = circuitLength;
            _firstGpHostYear = firstGpHostYear;
            _fastestLap = fastestLap;
            _thumbnailImage = thumbnailImage;
            _descriptionImage = descriptionImage;
        }

        public Circuit(DataRow r) {
            _circuitId = r["circuitId"].ToString().Trim();
            _circuitName = r["circuitName"].ToString().Trim();
            _countryCode = r["countryCode"].ToString().Trim();
            _lapNumber = Convert.ToInt32(r["lapNumber"]);
            _turnNumber = Convert.ToInt32(r["turnNumber"]);
            _circuitLength = Convert.ToInt32(r["circuitLength"]);
            _firstGpHostYear = r["firstGpHostYear"].ToString().Trim();
            _fastestLap = r["fastestLap"].ToString().Trim();
            _thumbnailImage = r["thumbnailImg"].ToString().Trim();
            _descriptionImage = r["descIMG"].ToString().Trim();
        }

        public string CircuitId { get => _circuitId; set => _circuitId = value; }
        public string CircuitName { get => _circuitName; set => _circuitName = value; }
        public string CountryCode { get => _countryCode; set => _countryCode = value; }
        public int LapNumber { get => _lapNumber; set => _lapNumber = value; }
        public int TurnNumber { get => _turnNumber; set => _turnNumber = value; }
        public int CircuitLength { get => _circuitLength; set => _circuitLength = value; }
        public string FirstGpHostYear { get => _firstGpHostYear; set => _firstGpHostYear = value; }
        public string FastestLap { get => _fastestLap; set => _fastestLap = value; }
        public string ThumbnailImage { get => _thumbnailImage; set => _thumbnailImage = value; }
        public string DescriptionImage { get => _descriptionImage; set => _descriptionImage = value; }
        internal Country Country { get => _country; set => _country = value; }
    }
}
