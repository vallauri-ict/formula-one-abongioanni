using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace FormulaOneConsoleProject {
    internal class Program {
        public const string WORKINGPATH = @"C:\data\FormulaOne\";
        public const string DATAPATH = @"..\..\..\..\Data";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + "FormulaOne.mdf;Integrated Security=True;Connect Timeout=30";

        private static void Main(string[] args) {
            CheckFilesIntoWorkingSpace();
            Console.WriteLine("\t\t\t=== FORMULA ONE - BATCH ACTIONS ===");
            //ExecuteSqlScript("checkDb.sql");

            string scelta;
            do {
                Console.Clear();
                Console.WriteLine("MENU'");
                Console.WriteLine("1: Create Countries");
                Console.WriteLine("2: Create Teams");
                Console.WriteLine("3: Create Drivers");
                Console.WriteLine("X: Exit");
                Console.Write("# ");
                scelta = Console.ReadLine();
                switch (scelta) {
                    case "1":
                        ExecuteSqlScript("countries.sql");
                        break;
                    case "2":
                        ExecuteSqlScript("teams.sql");
                        break;
                    case "3":
                        ExecuteSqlScript("drivers.sql");
                        break;
                    case "X": break;
                    default:
                        break;
                }

            } while (scelta.ToUpper() != "X");
        }

        private static void CheckFilesIntoWorkingSpace() {
            if (!Directory.Exists(WORKINGPATH)) {
                Directory.CreateDirectory(WORKINGPATH);
            }
            foreach (var file in Directory.GetFiles(DATAPATH)) {
                if (!File.Exists(Path.Combine(WORKINGPATH, file))) {
                    File.Copy(file, Path.Combine(WORKINGPATH, file));
                }
            }
            CheckFolder(Path.Combine(WORKINGPATH, "font"), Path.Combine(DATAPATH, "font"));
            CheckFolder(Path.Combine(WORKINGPATH, "img"), Path.Combine(DATAPATH, "img"));
        }

        private static void CheckFolder(string oldFolder, string newFolder) {
            if (!Directory.Exists(oldFolder) || Directory.GetFiles(oldFolder).Length != Directory.GetFiles(newFolder).Length) {
                Directory.CreateDirectory(oldFolder);
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

            string[] queries = fileContent.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("query", conn);
                int i = 0;
                foreach (var query in queries) {
                    cmd.CommandText = query;
                    i++;
                    try {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException se) {
                        Console.WriteLine($"Errore nell'esecizione della query n°. {i}\n{se.Message}");
                    }
                }
                Console.WriteLine("\nThe table's creation has completed succesfully!\n");
            }
            Console.ReadKey();
        }
    }
}
