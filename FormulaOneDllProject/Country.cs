using System.Data;

namespace FormulaOneDllProject {
    internal class Country {
        private string _iso2;
        private string _name;

        public Country(string countryCode, string countryName) {
            _iso2 = countryCode;
            _name = countryName;
        }

        public Country(DataRow r) {
            _iso2 = r["iso2"].ToString().Trim();
            _name = r["name"].ToString().Trim();
        }

        public string Iso2 { get => _iso2; set => _iso2 = value; }
        public string Name { get => _name; set => _name = value; }
    }
}
