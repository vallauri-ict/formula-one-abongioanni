using System.Data;

namespace FormulaOneDll {
    public class Country {
        private string _isoCode;
        private string _name;

        public Country(string countryCode, string countryName) {
            _isoCode = countryCode;
            _name = countryName;
        }

        public Country(DataRow r) {
            _name = r["name"].ToString().Trim();
            if (r.ItemArray.Length > 1) {
                _isoCode = r["iso2"].ToString().Trim();
            }
        }

        public Country() {
        }

        public string IsoCode { get => _isoCode; set => _isoCode = value; }
        public string Name { get => _name; set => _name = value; }
    }
}
