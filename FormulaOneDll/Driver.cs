using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FormulaOneDllProject {
    public class Paths {
        public const string WORKINGPATH = @"C:\data\FormulaOne\";
        public const string DATAPATH = @"..\..\..\..\Data";
        public const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + "FormulaOne.mdf;Integrated Security=True;Connect Timeout=30";
    }

    public class Driver {
        private Byte[] _helmetImage;
        private Byte[] _fullImage;
        private string _fullName;
        private int _number;
        private int _podiums;
        private string _countryIso2;
        private DateTime _dob;
        private Country _driverCountry;
        private int _teamId;

        public Driver(Byte[] helmetImage, Byte[] fullImage, string fullName, int number, string countryIso2, int podiums, DateTime dob, int teamId) {
            _helmetImage = helmetImage;
            _fullImage = fullImage;
            _fullName = fullName;
            _number = number;
            _podiums = podiums;
            _countryIso2 = countryIso2;
            _dob = dob;
            TeamId = teamId;
        }

        public Driver(DataRow r) {
            _helmetImage = (Byte[])r["helmet_image"];
            _fullImage = (Byte[])r["full_image"];
            _fullName = r.Field<string>("full_name").Trim();
            _number = r.Field<int>("number");
            _podiums = r.Field<int>("podiums_number");
            _countryIso2 = r.Field<string>("country").Trim();
            _teamId = r.Field<int>("team_id");
        }

        public static IEnumerable<Driver> GetDrivers() {
            List<Driver> drivers = new List<Driver>();
            using (SqlConnection connection = new SqlConnection(Paths.CONNECTION_STRING)) {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Driver;", connection)) {
                    var t = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(t);
                    foreach (DataRow r in t.Rows) {
                        drivers.Add(new Driver(r));
                    }
                    return drivers;
                }
            }
        }

        public Byte[] HelmetImage { get => _helmetImage; set => _helmetImage = value; }
        public Byte[] FullImage { get => _fullImage; set => _fullImage = value; }
        public string FullName { get => _fullName; set => _fullName = value; }
        public int Number { get => _number; set => _number = value; }
        public int Podiums { get => _podiums; set => _podiums = value; }
        public DateTime DateBirth { get => _dob; set => _dob = value; }
        public string CountryCode { get => _countryIso2; set => _countryIso2 = value; }
        public Country DriverCountry { get => _driverCountry; set => _driverCountry = value; }
        public int TeamId { get => _teamId; set => _teamId = value; }
    }
}
