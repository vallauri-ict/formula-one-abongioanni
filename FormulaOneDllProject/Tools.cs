using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FormulaOneDllProject {
    public class Tools {

        public static (bool, string) ExecuteSqlCommands(string query, string CONNECTION_STRING) {
            return ExecuteSqlCommands(new string[] { query }, CONNECTION_STRING);
        }

        public static (bool, string) ExecuteSqlCommands(string[] queries, string CONNECTION_STRING) {
            bool err = false;
            string strErr = "";
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING)) {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("query", connection)) {
                    int i = 0;
                    foreach (var query in queries) {
                        cmd.CommandText = query;
                        i++;
                        try {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException se) {
                            err = true;
                            strErr = se.Message;
                        }
                    }
                }
            }
            return (err, strErr);
        }

        public static bool ExecuteSqlScript(string[] paths, string CONNECTION_STRING) {
            bool result = true;
            foreach (var path in paths) {
                result = Tools.ExecuteSqlScript(path, CONNECTION_STRING);
            }
            return result;
        }

        public static bool ExecuteSqlScript(string path, string CONNECTION_STRING) {
            string fileContent = File.ReadAllText(path);
            fileContent = fileContent.Replace("\r\n", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("\t", "");
            var err = Tools.ExecuteSqlCommands(fileContent.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries), CONNECTION_STRING);
            return !err.Item1;
        }

        public static string[] ShowTables(string CONNECTION_STRING) {
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

        public static void BackupDb(string CONNECTION_STRING, string WORKINGPATH) {
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

        public static (bool, string) DropConstraints(string CONNECTION_STRING) {
            return Tools.ExecuteSqlCommands(new string[]{
                            "IF EXISTS(SELECT * FROM [Team]) DROP TABLE[Team];",
                            "IF EXISTS(SELECT * FROM [Driver]) DROP TABLE[Driver];",
                            "IF EXISTS(SELECT * FROM [Country]) DROP TABLE[Country];",
                            "IF EXISTS(SELECT * FROM [Circuit]) DROP TABLE[Circuit];",
                            "IF EXISTS(SELECT * FROM [GP]) DROP TABLE[GP];"
                        }, CONNECTION_STRING);
        }

        public static void RestoreDb(string CONNECTION_STRING, string WORKINGPATH) {
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
