using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;

namespace FormulaOneConsoleProject {
    internal class Program {
        public class ConsoleSpinner {
            private int counter;
            public ConsoleSpinner() {
                counter = 0;
            }

            public void Turn() {
                counter++;
                switch (counter % 4) {
                    case 0: Console.Write("/"); break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write("\\"); break;
                    case 3: Console.Write("|"); break;
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }
        public const string WORKINGPATH = @"C:\data\FormulaOne\";
        public const string DATAPATH = @"..\..\..\..\Data";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + "FormulaOne.mdf;Integrated Security=True;Connect Timeout=30";
        private static bool stopWait;
        private static void Main(string[] args) {
            CheckWorkData();
            Console.WriteLine("\t\t\t=== FORMULA ONE - BATCH ACTIONS ===");
            //ExecuteSqlScript("checkDb.sql");

            string scelta;
            do {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("MENU'");
                Console.WriteLine("1: Create Countries");
                Console.WriteLine("2: Create Teams");
                Console.WriteLine("3: Create Drivers");
                Console.WriteLine("4: Create Circuits");
                Console.WriteLine("5: Create Gps");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("R: Reset DB");
                Console.WriteLine("C: Create Constraints");
                Console.WriteLine("B: Backup DB");
                Console.WriteLine("G: Get Backup DB");
                Console.WriteLine("X: Exit");
                Console.Write("# ");
                scelta = Console.ReadLine();
                stopWait = false;
                (bool, string) err;
                switch (scelta) {
                    case "1":
                        Thread th = new Thread(ConsoleWaiting);
                        th.Start();
                        ExecuteSqlScript("countries.sql");
                        Console.ReadKey();

                        break;
                    case "2":
                        th = new Thread(ConsoleWaiting);
                        th.Start();
                        ExecuteSqlScript("teams.sql");
                        Console.ReadKey();

                        break;
                    case "3":
                        th = new Thread(ConsoleWaiting);
                        th.Start();
                        ExecuteSqlScript("drivers.sql");
                        Console.ReadKey();

                        break;
                    case "4":
                        th = new Thread(ConsoleWaiting);
                        th.Start();
                        ExecuteSqlScript("circuits.sql");
                        Console.ReadKey();

                        break;
                    case "5":
                        th = new Thread(ConsoleWaiting);
                        th.Start();
                        ExecuteSqlScript("gps.sql");
                        Console.ReadKey();

                        break;
                    case "R":
                    case "r":
                        err = ExecuteSqlCommands(new string[]{
                            "IF EXISTS(SELECT * FROM [Team]) DROP TABLE[Team];",
                            "IF EXISTS(SELECT * FROM [Driver]) DROP TABLE[Driver];",
                            "IF EXISTS(SELECT * FROM [Country]) DROP TABLE[Country];",
                            "IF EXISTS(SELECT * FROM [Circuit]) DROP TABLE[Circuit];",
                            "IF EXISTS(SELECT * FROM [GP]) DROP TABLE[GP];"
                        });
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (!err.Item1) {
                            Console.WriteLine($"\nTables have been deleted succesfully!");
                            Console.ReadKey();
                            string c;
                            Console.ForegroundColor = ConsoleColor.White;
                            do {
                                Console.Write("Do you want to recreate all the tables? [y/n]: ");
                                c = Console.ReadLine().ToUpper();
                            } while (c != "Y" && c != "N");
                            if (c == "Y") {
                                th = new Thread(ConsoleWaiting);
                                th.Start();
                                ExecuteSqlScript(new string[]{
                                    "countries.sql",
                                    "teams.sql",
                                    "drivers.sql",
                                    "circuits.sql",
                                    "gps.sql"
                                });
                                Console.ForegroundColor = ConsoleColor.White;
                                do {
                                    Console.Write("Do you want to create all the constraints? [y/n]: ");
                                    c = Console.ReadLine().ToUpper();
                                } while (c != "Y" && c != "N");
                                if (c == "Y") {
                                    ExecuteSqlScript("constraints.sql");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error while deleting tables: {err.Item2}");
                            Console.ReadKey();
                        }
                        break;
                    case "B":
                    case "b":
                        Backup();
                        Console.ReadKey();

                        break;
                    case "C":
                    case "c":
                        ExecuteSqlScript("constraints.sql");
                        Console.ReadKey();

                        break;
                    case "G":
                    case "g":
                        Restore();
                        Console.ReadKey();

                        break;
                    case "X":
                    default:
                        stopWait = true;
                        break;
                }
            } while (scelta.ToUpper() != "X");
        }

        private static void Backup() {
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

        private static void Restore() {
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


        private static void ConsoleWaiting() {
            ConsoleSpinner spin = new ConsoleSpinner();
            Console.Write("\nCreating table ");

            while (!stopWait) {
                spin.Turn();
                Thread.Sleep(250);
            }
        }

        private static void CheckWorkData() {
            if (!Directory.Exists(WORKINGPATH)) {
                Directory.CreateDirectory(WORKINGPATH);
            }
            foreach (var file in Directory.GetFiles(DATAPATH)) {
                if (!File.Exists(Path.Combine(WORKINGPATH, file.Split("\\").Last()))) {
                    File.Copy(file, Path.Combine(WORKINGPATH, file.Split("\\").Last()));
                }
            }
            CheckFolderFiles(Path.Combine(DATAPATH, "font"), Path.Combine(WORKINGPATH, "font"));
            CheckFolderFiles(Path.Combine(DATAPATH, "img"), Path.Combine(WORKINGPATH, "img"));
        }

        private static void CheckFolderFiles(string oldFolder, string newFolder) {
            if (!Directory.Exists(newFolder)) {
                Directory.CreateDirectory(newFolder);
            }
            if (Directory.GetFiles(oldFolder).Length != Directory.GetFiles(newFolder).Length) {
                foreach (string newPath in Directory.GetFiles(newFolder, "*.*", SearchOption.AllDirectories)) {
                    var filename = newPath.Split("\\").Last();
                    File.Copy(Path.Combine(newFolder, filename), Path.Combine(oldFolder, filename), true);
                }
            }
        }

        private static void ExecuteSqlScript(string path) {
            string fileContent = File.ReadAllText(Path.Combine(WORKINGPATH, path));
            fileContent = fileContent.Replace("\r\n", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("\t", "");
            var err = ExecuteSqlCommands(fileContent.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
            stopWait = true;
            if (!err.Item1) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{path} has been completed succesfully!");
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError executing the script {path}: {err.Item2}");
            }
        }

        private static (bool, string) ExecuteSqlCommands(string query) {
            return ExecuteSqlCommands(new string[] { query });
        }

        private static (bool, string) ExecuteSqlCommands(string[] queries) {
            bool err = false;
            string strErr = "";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING)) {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("query", conn)) {
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

        private static void ExecuteSqlScript(string[] paths) {
            foreach (var path in paths) {
                ExecuteSqlScript(path);
            }
        }
    }
}
