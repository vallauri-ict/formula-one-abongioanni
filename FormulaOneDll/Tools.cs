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

        public (bool, string) ExecuteCommand(string query) {
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

        public (bool, string) ExecuteCommand(string[] queries) {
            (bool, string) err = (true, "");
            foreach (var query in queries) {
                err = ExecuteCommand(query);
            }
            return err;
        }

        public (bool, string) ExecuteScript(string path) {
            string fileContent = File.ReadAllText(path);
            fileContent = fileContent.Replace("\r\n", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("\t", "");
            var err = ExecuteCommand(fileContent.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
            return err;
        }

        public (bool, string) ExecuteScript(string[] paths) {
            (bool, string) result = (true, "");
            foreach (var path in paths) {
                result = ExecuteScript(path);
            }
            return result;
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

        public List<Country> GetCountryList() {
            List<Country> countryList = new List<Country>();
            foreach (DataRow row in GetCountryTable().Rows) {
                countryList.Add(new Country(row));
            }
            return countryList;
        }

        public DataTable GetCountryTable() {
            var result = GetRecords("SELECT * FROM Country;");
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public Country GetCountry(string field, string value) {
            var result = GetRecords($"SELECT * FROM Country WHERE {field}='{value}';");
            if (!result.Item1) {
                return new Country(((DataTable)result.Item2).Rows[0]);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        /* DRIVER **************************************************************************/

        public List<Driver> GetDriverList(bool full = true) {
            List<Driver> driverList = new List<Driver>();
            var result = GetRecords($"SELECT {(full ? "*" : "number, full_name, full_image, country")} FROM Driver;");
            if (!result.Item1) {
                foreach (DataRow row in GetDriverTable().Rows) {
                    var driver = new Driver(row);
                    driver.Team = GetDriverTeam(driver.TeamId);
                    driverList.Add(driver);
                }
                return driverList;
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public Team GetDriverTeam(int teamId) {
            var result = GetRecords($"SELECT small_name,color FROM Team WHERE id={teamId};");
            if (!result.Item1) {
                return new Team(((DataTable)result.Item2).Rows[0]);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public DataTable GetDriverTable() {
            var result = GetRecords("SELECT * FROM Driver;");
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public Driver GetDriver(int number) {
            var result = GetRecords($"SELECT * FROM Driver WHERE number={number};");
            if (!result.Item1) {
                var driver = new Driver(((DataTable)result.Item2).Rows[0]);
                driver.Team = GetDriverTeam(driver.TeamId);
                return driver;
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        /* TEAM **************************************************************************/

        public List<Team> GetTeamList(bool full = true) {
            List<Team> teamList = new List<Team>();
            var result = GetRecords($"SELECT {(full ? "*" : "id, small_name, small_image, car_image, color")} FROM Team;");
            if (!result.Item1) {
                foreach (DataRow row in ((DataTable)result.Item2).Rows) {
                    var team = new Team(row);
                    team.SetDrivers(GetTeamDrivers(team.Id));
                    teamList.Add(team);
                }
                return teamList;
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public DataTable GetTeamTable() {
            var result = GetRecords("SELECT * FROM Team;");
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public Team GetTeam(int id) {
            var result = GetRecords($"SELECT * FROM Team WHERE id={id};");
            if (!result.Item1) {
                var team = new Team(((DataTable)result.Item2).Rows[0]);
                team.SetDrivers(GetTeamDrivers(id));
                return team;
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public (Driver, Driver) GetTeamDrivers(int id) {
            var result = GetRecords($"SELECT number,full_name,full_image,team_id FROM Driver WHERE team_id={id};");
            if (!result.Item1) {
                var drivers = ((DataTable)result.Item2).Rows;
                return (new Driver(drivers[0]), new Driver(drivers[1]));
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        /* RACE **************************************************************************/

        public List<Race> GetRaceList(bool full = true) {
            List<Race> raceList = new List<Race>();
            var result = GetRecords($"SELECT {(full ? "*" : "id, name, date_start, circuit_id")} FROM Race;");
            if (!result.Item1) {
                foreach (DataRow row in ((DataTable)result.Item2).Rows) {
                    var race = new Race(row);
                    race.Circuit = GetRaceCircuit(race.CircuitId);
                    raceList.Add(race);
                }
                return raceList;
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public Circuit GetRaceCircuit(string id) {
            var result = GetRecords($"SELECT small_image,country FROM Circuit WHERE id='{id}';");
            if (!result.Item1) {
                try {
                    return new Circuit(((DataTable)result.Item2).Rows[0]);
                }
                catch {
                    return new Circuit();
                }
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public DataTable GetRaceTable() {
            var result = GetRecords("SELECT * FROM Race;");
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public Race GetRace(int id) {
            var result = GetRecords($"SELECT * FROM Race WHERE id={id};");
            if (!result.Item1) {
                var race = new Race(((DataTable)result.Item2).Rows[0]);
                var circuitResult = GetRecords($"SELECT * FROM Circuit WHERE id={race.CircuitId};");

                if (!circuitResult.Item1) {
                    race.Circuit = new Circuit(((DataTable)circuitResult.Item2).Rows[0]);
                }
                else {
                    throw new Exception(circuitResult.Item2.ToString());
                }
                return race;
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        /* CIRCUIT **************************************************************************/

        public List<Circuit> GetCircuitList() {
            List<Circuit> circuitList = new List<Circuit>();
            foreach (DataRow row in GetCircuitTable().Rows) {
                circuitList.Add(new Circuit(row));
            }
            return circuitList;
        }

        public DataTable GetCircuitTable() {
            var result = GetRecords("SELECT * FROM Circuit;");
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public Circuit GetCircuit(string id) {
            var result = GetRecords($"SELECT * FROM Circuit WHERE id={id};");
            if (!result.Item1) {
                var circuit = new Circuit(((DataTable)result.Item2).Rows[0]);
                var countryResult = GetRecords($"SELECT * FROM Country WHERE iso2={circuit.CountryCode};");
                if (!countryResult.Item1) {
                    circuit.Country = new Country(((DataTable)countryResult.Item2).Rows[0]);
                }
                else {
                    throw new Exception(countryResult.Item2.ToString());
                }
                return circuit;
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public DataTable GetTable(string table) {
            var result = GetRecords($"SELECT * FROM {table};");
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public List<Result> GetResultList() {
            List<Result> resultList = new List<Result>();
            foreach (DataRow row in GetResultTable().Rows) {
                resultList.Add(new Result(row));
            }
            return resultList;
        }

        public DataTable GetResultTable() {
            var result = GetRecords("SELECT * FROM Result;");
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public Result GetResult(int id) {
            var result = GetRecords($"SELECT * FROM Result WHERE id={id};");
            if (!result.Item1) {
                return new Result(((DataTable)result.Item2).Rows[0]);
            }
            else {
                throw new Exception(result.Item2.ToString());
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
