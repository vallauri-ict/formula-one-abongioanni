using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FormulaOneDllProject {
    public class Tools {

        private string connection_string;

        public Tools(string CONNECTION_STRING) {
            this.CONNECTION_STRING = CONNECTION_STRING;
        }

        public string CONNECTION_STRING { get => connection_string; set => connection_string = value; }

        public (bool, string) ExecuteSqlCommands(string query) {
            bool err = false;
            string strErr = "";
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING)) {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("query", connection)) {
                    cmd.CommandText = query;
                    try {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException se) {
                        err = true;
                        strErr = se.Message;
                    }
                }
            }
            return (err, strErr);
        }

        public (bool, string) ExecuteSqlCommands(string[] queries) {
            (bool, string) err = (true, "");
            foreach (var query in queries) {
                err = ExecuteSqlCommands(query);
            }
            return err;
        }

        private (bool, object) GetRecords(string query) {
            bool err = false;
            object result = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING)) {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("query", connection)) {
                    cmd.CommandText = query;
                    try {
                        SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                        sqlData.Fill((DataTable)result);
                    }
                    catch (SqlException se) {
                        err = true;
                        result = se.Message;
                    }
                }
            }
            return (err, result);
        }

        public (bool, string) ExecuteSqlScript(string[] paths) {
            (bool, string) result = (true, "");
            foreach (var path in paths) {
                result = ExecuteSqlScript(path);
            }
            return result;
        }

        public (bool, string) ExecuteSqlScript(string path) {
            string fileContent = File.ReadAllText(path);
            fileContent = fileContent.Replace("\r\n", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("\t", "");
            var err = ExecuteSqlCommands(fileContent.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
            return err;
        }

        public string[] ShowTables() {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING)) {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME  FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'", connection)) {
                    DataTable t = new DataTable();
                    string[] tables = new string[0];
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(t);
                    foreach (DataRow row in t.Rows) {
                        Array.Resize(ref tables, tables.Length + 1);
                        tables[tables.Length - 1] = row["TABLE_NAME"].ToString();
                    }
                    return tables;
                }
            }
        }

        public void Backup(string WORKINGPATH) {
            try {
                using (SqlConnection dbConn = new SqlConnection()) {
                    dbConn.ConnectionString = CONNECTION_STRING;
                    dbConn.Open();

                    using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand()) {
                        multiuser_rollback_dbcomm.Connection = dbConn;
                        multiuser_rollback_dbcomm.CommandText = @"ALTER DATABASE [" + WORKINGPATH + "FormulaOne.mdf] SET MULTI_USER WITH ROLLBACK IMMEDIATE";

                        multiuser_rollback_dbcomm.ExecuteNonQuery();
                    }
                    dbConn.Close();
                }

                SqlConnection.ClearAllPools();

                using (SqlConnection backupConn = new SqlConnection()) {
                    backupConn.ConnectionString = CONNECTION_STRING;
                    backupConn.Open();

                    using (SqlCommand backupcomm = new SqlCommand()) {
                        backupcomm.Connection = backupConn;
                        backupcomm.CommandText = @"BACKUP DATABASE [" + WORKINGPATH + "FormulaOne.mdf] TO DISK='" + WORKINGPATH + @"\prova.bak'";
                        backupcomm.ExecuteNonQuery();
                    }
                    backupConn.Close();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Backup has been created succesfully!");
            }

            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public (bool, string) DropTable() {
            return ExecuteSqlCommands(new string[]{
                            "IF EXISTS(SELECT * FROM [Team]) DROP TABLE[Team];",
                            "IF EXISTS(SELECT * FROM [Driver]) DROP TABLE[Driver];",
                            "IF EXISTS(SELECT * FROM [Country]) DROP TABLE[Country];",
                            "IF EXISTS(SELECT * FROM [Circuit]) DROP TABLE[Circuit];",
                            "IF EXISTS(SELECT * FROM [Race]) DROP TABLE[Race];"
                        });
        }

        public List<Country> GetCountryList() {
            List<Country> countryList = new List<Country>();
            foreach (DataRow row in GetCountry().Rows) {
                countryList.Add(new Country(row));
            }
            return countryList;
        }

        public DataTable GetCountry() {
            var result = GetRecords("SELECT * FROM Country;");
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public List<Driver> GetDriverList() {
            List<Driver> driverList = new List<Driver>();
            foreach (DataRow row in GetDriver().Rows) {
                driverList.Add(new Driver(row));
            }
            return driverList;
        }

        public DataTable GetDriver() {
            var result = GetRecords("SELECT * FROM Driver;");
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public List<Team> GetTeamList() {
            List<Team> teamList = new List<Team>();
            foreach (DataRow row in GetTeam().Rows) {
                teamList.Add(new Team(row));
            }
            return teamList;
        }

        public DataTable GetTeam() {
            var result = GetRecords("SELECT * FROM Team;");
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public List<Circuit> GetCircuitList() {
            List<Circuit> circuitList = new List<Circuit>();
            foreach (DataRow row in GetCircuit().Rows) {
                circuitList.Add(new Circuit(row));
            }
            return circuitList;
        }

        public DataTable GetCircuit() {
            var result = GetRecords("SELECT * FROM Circuit;");
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public List<Race> GetRaceList() {
            List<Race> raceList = new List<Race>();
            foreach (DataRow row in GetRace().Rows) {
                raceList.Add(new Race(row));
            }
            return raceList;
        }

        public DataTable GetRace() {
            var result = GetRecords("SELECT * FROM Race;");
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public List<Result> GetResultList() {
            List<Result> resultList = new List<Result>();
            foreach (DataRow row in GetResult().Rows) {
                resultList.Add(new Result(row));
            }
            return resultList;
        }

        public DataTable GetResult() {
            var result = GetRecords("SELECT * FROM Result;");
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public void Restore(string WORKINGPATH) {
            try {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING)) {
                    con.Open();
                    string sqlStmt2 = string.Format(@"ALTER DATABASE [" + WORKINGPATH + "FormulaOne.mdf] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                    bu2.ExecuteNonQuery();

                    string sqlStmt3 = @"USE MASTER RESTORE DATABASE [" + WORKINGPATH + "FormulaOne.mdf] FROM DISK='" + WORKINGPATH + @"\prova.bak' WITH REPLACE;";
                    SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                    bu3.ExecuteNonQuery();

                    string sqlStmt4 = string.Format(@"ALTER DATABASE [" + WORKINGPATH + "FormulaOne.mdf] SET MULTI_USER");
                    SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                    bu4.ExecuteNonQuery();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("database restoration done successefully");
                    con.Close();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
