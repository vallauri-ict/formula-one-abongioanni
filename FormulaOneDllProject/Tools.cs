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

        public (bool, object) GetRecords(string query) {
            bool err = false;
            object result = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING)) {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("query", connection)) {
                    cmd.CommandText = query;
                    try {
                        SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                        sqlData.Fill((DataSet)result);
                    }
                    catch (SqlException se) {
                        err = true;
                        result = se.Message;
                    }
                }
            }
            return (err, result);
        }

        public bool ExecuteSqlScript(string[] paths) {
            bool result = true;
            foreach (var path in paths) {
                result = ExecuteSqlScript(path);
            }
            return result;
        }

        public bool ExecuteSqlScript(string path) {
            string fileContent = File.ReadAllText(path);
            fileContent = fileContent.Replace("\r\n", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("\t", "");
            var err = ExecuteSqlCommands(fileContent.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
            return !err.Item1;
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
                        tables[^1] = row["TABLE_NAME"].ToString();
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

        public (bool, string) DropConstraints() {
            return ExecuteSqlCommands(new string[]{
                            "IF EXISTS(SELECT * FROM [Team]) DROP TABLE[Team];",
                            "IF EXISTS(SELECT * FROM [Driver]) DROP TABLE[Driver];",
                            "IF EXISTS(SELECT * FROM [Country]) DROP TABLE[Country];",
                            "IF EXISTS(SELECT * FROM [Circuit]) DROP TABLE[Circuit];",
                            "IF EXISTS(SELECT * FROM [GP]) DROP TABLE[GP];"
                        });
        }

        public List<Country> GetCountries() {
            List<Country> countryList = new List<Country>();
            var result = GetRecords("SELECT * FROM Country;");
            if (!result.Item1) {
                foreach (DataRow row in ((DataTable)result.Item2).Rows) {
                    countryList.Add(new Country(row));
                }
                return countryList;
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
