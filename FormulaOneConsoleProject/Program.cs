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
        Thread th;
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
                Console.WriteLine("R: Reset DB");
                Console.WriteLine("X: Exit");
                Console.Write("# ");
                scelta = Console.ReadLine();
                stopWait = false;

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
                    case "R":
                    case "r":
                        bool err = ExecuteSqlCommands(new string[]{
                            "IF EXISTS(SELECT * FROM [Team]) DROP TABLE[Team];",
                            "IF EXISTS(SELECT * FROM [Driver]) DROP TABLE[Driver];",
                            "IF EXISTS(SELECT * FROM [Country]) DROP TABLE[Country];"
                        });
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (!err) {
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
                                });
                            }
                        }
                        Console.ReadKey();

                        break;
                    case "X":
                    default:
                        stopWait = true;
                        break;
                }
            } while (scelta.ToUpper() != "X");
        }

        private static void ConsoleWaiting() {
            ConsoleSpinner spin = new ConsoleSpinner();
            Console.Write("\nCreating tables ");

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
            bool err = ExecuteSqlCommands(fileContent.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
            stopWait = true;
            if (!err) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{path} has been completed succesfully!");
            }
        }


        private static bool ExecuteSqlCommands(string[] queries) {
            bool err = false;
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
                            stopWait = err = true;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Errore nell'esecizione della query n°. {i}\n{se.Message}");
                        }
                    }
                }
            }
            return err;
        }

        private static void ExecuteSqlScript(string[] paths) {
            foreach (var path in paths) {
                ExecuteSqlScript(path);
            }
        }
    }
}
