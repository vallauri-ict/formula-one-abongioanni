using System;
using System.Data.SqlClient;
using System.IO;

namespace FormulaOneConsoleProject {
    internal class Program {
        public const string WORKINGPATH = @"C:\data\FormulaOne\";

        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + "FromulaOne.mdf;Integrated Security=True;Connect Timeout=30";

        private static void Main(string[] args) {
            CheckFile();
            Console.WriteLine("\t\t\t=== FORMULA ONE - BATCH ACTIONS ===");

            string scelta;
            do {
                Console.WriteLine("MENU'");
                Console.WriteLine("1: Create Countries");
                Console.WriteLine("2: Create Teams");
                Console.WriteLine("3: Create Drivers");
                Console.WriteLine("4: Show Drivers");
                Console.WriteLine("5: Show Drivers");
                Console.WriteLine("6: Show Drivers");
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
            if (!File.Exists(WORKINGPATH)) {
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
        }
    }
}
