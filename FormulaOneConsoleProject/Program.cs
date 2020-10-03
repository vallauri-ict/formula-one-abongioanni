using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace FormulaOneConsoleProject {
    internal class Program {
        public const string WORKINGPATH = @"C:\data\FormulaOne\";

        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + "FormulaOne.mdf;Integrated Security=True;Connect Timeout=30";

        private static void Main(string[] args) {
            CheckFile();
            Console.WriteLine("\t\t\t=== FORMULA ONE - BATCH ACTIONS ===");

            string scelta;
            do {
                Console.Clear();
                Console.WriteLine("MENU'");
                Console.WriteLine("1: Create Countries");
                Console.WriteLine("2: Create Teams");
                Console.WriteLine("3: Create Drivers");
                Console.WriteLine("4: Drop Countries");
                Console.WriteLine("5: Drop Teams");
                Console.WriteLine("6: Drop Drivers");
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

        private static void CheckFile() {
            var imageFolder = Path.Combine(WORKINGPATH, "img");
            if (!File.Exists(Path.Combine(WORKINGPATH, "FormulaOne.mdf"))) {
                File.Copy(@"..\..\..\..\Data\FormulaOne.mdf", Path.Combine(WORKINGPATH, "FormulaOne.mdf"));
            }
            if (!File.Exists(Path.Combine(WORKINGPATH, "drivers.sql"))) {
                File.Copy(@"..\..\..\..\Data\drivers.sql", Path.Combine(WORKINGPATH, "drivers.sql"));
            }
            if (!File.Exists(Path.Combine(WORKINGPATH, "teams.sql"))) {
                File.Copy(@"..\..\..\..\Data\teams.sql", Path.Combine(WORKINGPATH, "teams.sql"));
            }
            if (!File.Exists(Path.Combine(WORKINGPATH, "countries.sql"))) {
                File.Copy(@"..\..\..\..\Data\countries.sql", Path.Combine(WORKINGPATH, "countries.sql"));
            }
            if (!Directory.Exists(imageFolder) || Directory.GetFiles(imageFolder).Length != Directory.GetFiles(@"..\..\..\..\Data\img").Length) {
                Directory.CreateDirectory(imageFolder);
                foreach (string newPath in Directory.GetFiles(@"..\..\..\..\Data\img", "*.*", SearchOption.AllDirectories)) {
                    var filename = newPath.Split("\\").Last();
                    File.Copy(Path.Combine(@"..\..\..\..\Data\img\", filename), Path.Combine(imageFolder, filename), true);
                }
            }
        }

        private static void ExecuteSqlScript(string path) {
            string fileContent = File.ReadAllText(WORKINGPATH + path);
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
