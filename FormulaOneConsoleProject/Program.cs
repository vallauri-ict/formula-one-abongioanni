using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace FormulaOneConsoleProject
{
    internal class Program
    {
        public const string WORKINGPATH = @"C:\data\FormulaOne\";

        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + "FromulaOne.mdf;Integrated Security=True;Connect Timeout=30";

        private static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t=== FORMULA ONE - BATCH ACTIONS ===");

            char scelta;
            do
            {
                Console.WriteLine("MENU'");
                Console.WriteLine("1: Create Countries' table");
                Console.WriteLine("2: Create Teams' table");
                Console.WriteLine("3: Create Drivers' table");
                Console.WriteLine("X: Exit");
                Console.Write("SCEGLI: ");
                scelta = Console.ReadKey().KeyChar;
                Console.Write("\n");
                switch (scelta)
                {
                    case '1':
                        ExecuteSqlScript("countries.sql");
                        break;
                    case '2':
                        ExecuteSqlScript("teams.sql");
                        break;
                    case '3':
                        ExecuteSqlScript("drivers.sql");
                        break;
                    default:
                        break;
                }

            } while (scelta == 'x' || scelta == 'X');
        }

        private static void ExecuteSqlScript(string path)
        {
            string fileContent = File.ReadAllText(WORKINGPATH + path);
            fileContent = fileContent.Replace("\r\n", "");
            fileContent = fileContent.Replace("\r", "");
            fileContent = fileContent.Replace("\n", "");
            fileContent = fileContent.Replace("\t", "");

            string[] queries = fileContent.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("query", conn);
                int i = 0;
                foreach (var query in queries)
                {
                    cmd.CommandText = query;
                    i++;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException se)
                    {
                        Console.WriteLine($"Errore nell'esecizione della query n°. {i}");
                    }
                }
                Console.WriteLine("The table's creation has completed succesfully!");
            }
        }
    }
}
