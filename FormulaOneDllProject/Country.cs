using System.Data;

namespace FormulaOneDllProject {
    internal class Country {
        private string _countryCode;
        private string _countryName;

        public Country(string countryCode, string countryName) {
            _countryCode = countryCode;
            _countryName = countryName;
        }

        public Country(DataRow r) {
            _countryCode = r["countryCode"].ToString().Trim();
            _countryName = r["countryName"].ToString().Trim();
        }

        public string CountryCode { get => _countryCode; set => _countryCode = value; }
        public string CountryName { get => _countryName; set => _countryName = value; }
    }
}
