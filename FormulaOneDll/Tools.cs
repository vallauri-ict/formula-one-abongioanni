using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FormulaOneDll {
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

        private (bool, object) GetRecords(SqlCommand query) {
            bool err = false;
            object result = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING)) {
                connection.Open();
                query.Connection = connection;
                query.Prepare();
                try {
                    SqlDataAdapter sqlData = new SqlDataAdapter(query);
                    sqlData.Fill((DataTable)result);
                }
                catch (SqlException se) {
                    err = true;
                    result = se.Message;
                }
            }

            return (err, result);
        }

        public DataTable GetTable(string query) {
            var result = GetRecords(query);
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
        }

        public DataTable GetTable(SqlCommand query) {
            var result = GetRecords(query);
            if (!result.Item1) {
                return ((DataTable)result.Item2);
            }
            else {
                throw new Exception(result.Item2.ToString());
            }
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

        public List<Country> GetCountryList(string query = "SELECT * FROM Country") {
            List<Country> countryList = new List<Country>();
            foreach (DataRow row in GetTable(query).Rows) {
                countryList.Add(new Country(row));
            }
            return countryList;
        }

        /* DRIVER **************************************************************************/

        public List<Driver> GetDriverList(string query = "SELECT * FROM Driver") {
            List<Driver> driverList = new List<Driver>();
            foreach (DataRow row in GetTable(query).Rows) {
                driverList.Add(new Driver(row));
            }
            return driverList;
        }

        public List<Driver> GetDriverList(SqlCommand query) {
            List<Driver> driverList = new List<Driver>();
            foreach (DataRow row in GetTable(query).Rows) {
                driverList.Add(new Driver(row));
            }
            return driverList;
        }

        public SqlCommand GenerateDriverQuery(Driver.Fields field, string value) {
            SqlCommand query = new SqlCommand();
            switch (field) {
                case Driver.Fields.Name:
                    query = new SqlCommand() {
                        CommandText = "SELECT number,Driver.full_name,color FROM Driver,Team WHERE Driver.team_id = Team.id AND EXISTS(SELECT value FROM STRING_SPLIT(Driver.full_name, ' ') WHERE value LIKE @NAME); "
                    };
                    query.Parameters.Add(@"@NAME", SqlDbType.VarChar, 50).Value = value + "%";
                    break;
                default:
                    break;
            }
            return query;
        }

        /* TEAM **************************************************************************/

        public List<Team> GetTeamList(string query = "SELECT * FROM Team;") {
            List<Team> teamList = new List<Team>();
            foreach (DataRow row in GetTable(query).Rows) {
                teamList.Add(new Team(row));
            }
            return teamList;
        }

        /* RACE **************************************************************************/

        public List<Race> GetRaceList(string query = "SELECT * FROM Race;") {
            List<Race> raceList = new List<Race>();
            foreach (DataRow row in GetTable(query).Rows) {
                raceList.Add(new Race(row));
            }
            return raceList;
        }

        /* CIRCUIT **************************************************************************/

        public List<Circuit> GetCircuitList(string query = "SELECT * FROM Circuit;") {
            List<Circuit> circuitList = new List<Circuit>();
            foreach (DataRow row in GetTable(query).Rows) {
                circuitList.Add(new Circuit(row));
            }
            return circuitList;
        }

        /* RESULT **************************************************************************/

        public List<Result> GetResultList(string query = "SELECT * FROM Result;") {
            List<Result> resultList = new List<Result>();
            foreach (DataRow row in GetTable(query).Rows) {
                resultList.Add(new Result(row));
            }
            return resultList;
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
