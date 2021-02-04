using System.Data;

namespace FormulaOneDllProject {
    public class Country {
        private string _isoCode;
        private string _name;

        public Country(string countryCode, string countryName) {
            _isoCode = countryCode;
            _name = countryName;
        }

        public Country(DataRow r) {
            _isoCode = r["iso2"].ToString().Trim();
            _name = r["name"].ToString().Trim();
        }

        public Country() {
        }

        public string IsoCode { get => _isoCode; set => _isoCode = value; }
        public string Name { get => _name; set => _name = value; }
    }
}
