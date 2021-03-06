﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FormulaOneDll;

namespace FormulaOneConsoleProject {
    internal class Program {

        private struct Scripts {
            public static string[] Tables => new string[] {
                Path.Combine(WORKINGPATH, "countries.sql"),
                Path.Combine(WORKINGPATH, "teams.sql"),
                Path.Combine(WORKINGPATH, "drivers.sql"),
                Path.Combine(WORKINGPATH, "circuits.sql"),
                Path.Combine(WORKINGPATH, "races.sql"),
                Path.Combine(WORKINGPATH, "results.sql")
            };
            public static Dictionary<string, string> Constraints => new Dictionary<string, string> {
                {"set", Path.Combine(WORKINGPATH,"setConstraints.sql" )},
                {"delete", Path.Combine(WORKINGPATH,"deleteConstraints.sql") }
            };
            public static string DropTables = Path.Combine(WORKINGPATH, "dropTables.sql");
        }

        public const string WORKINGPATH = @"C:\data\FormulaOne\";
        public const string DATAPATH = @"..\..\..\..\Data";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + "FormulaOne.mdf;Integrated Security=True;Connect Timeout=30";

        private static void Main(string[] args) {
            CheckWorkData();
            Console.WriteLine("\t\t\t=== FORMULA ONE - BATCH ACTIONS ===");
            Tools dbTools = new Tools(CONNECTION_STRING);

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
                Console.WriteLine("6: Create Results");
                Console.WriteLine("0: Create all tables");
                Console.WriteLine("---------------- DATABASE MANIPULATION ----------------");
                Console.WriteLine("S: Show tables");
                Console.WriteLine("R: Reset DB");
                Console.WriteLine("C: Create Constraints");
                Console.WriteLine("D: Delete Constraints");
                Console.WriteLine("B: Backup DB");
                Console.WriteLine("G: Get Backup DB");
                Console.WriteLine("X: Exit\n");
                Console.Write("# ");
                scelta = Console.ReadLine();
                Console.WriteLine();
                (bool, string) err;
                switch (scelta) {
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                        if (scelta == "0") {
                            err = dbTools.ExecuteScript(Scripts.Tables);
                        }
                        else {
                            string file = Scripts.Tables[Convert.ToInt32(scelta) - 1];
                            err = dbTools.ExecuteScript(file);
                        }
                        if (!err.Item1) {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Done!");
                        }
                        else {
                            Console.WriteLine(err.Item2);
                        }
                        Console.ReadKey();

                        break;
                    case "R":
                    case "r":
                        dbTools.ExecuteScript(Scripts.Constraints["delete"]);
                        err = dbTools.ExecuteScript(Scripts.DropTables);
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
                                err = dbTools.ExecuteScript(Scripts.Tables);
                                if (!err.Item1) {
                                    Console.WriteLine("Done!");
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                do {
                                    Console.Write("Do you want to create all the constraints? [y/n]: ");
                                    c = Console.ReadLine().ToUpper();
                                } while (c != "Y" && c != "N");
                                if (c == "Y") {
                                    dbTools.ExecuteScript(Scripts.Constraints["set"]);
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
                        dbTools.Backup(WORKINGPATH);
                        Console.ReadKey();

                        break;
                    case "C":
                    case "c":
                    case "D":
                    case "d":
                        if (scelta.ToUpper() == "C") {
                            dbTools.ExecuteScript(Scripts.Constraints["set"]);
                        }
                        else {
                            dbTools.ExecuteScript(Scripts.Constraints["delete"]);
                        }
                        Console.ReadKey();

                        break;
                    case "G":
                    case "g":
                        dbTools.Restore(WORKINGPATH);
                        Console.ReadKey();

                        break;
                    case "S":
                    case "s":
                        var tables = dbTools.ShowTables();
                        if (tables.Length > 0) {
                            Console.ForegroundColor = ConsoleColor.Green;
                            foreach (var t in tables) {
                                Console.WriteLine($"{t}");
                            }
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("No tables");
                        }
                        Console.ReadKey();

                        break;
                    case "X":
                    default:
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
            } while (scelta.ToUpper() != "X");
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
            CheckFolderFiles(Path.Combine(DATAPATH, "img/circuits"), Path.Combine(WORKINGPATH, "img/circuits"));
        }

        private static void CheckFolderFiles(string oldFolder, string newFolder) {
            if (!Directory.Exists(newFolder)) {
                Directory.CreateDirectory(newFolder);
            }
            if (Directory.GetFiles(oldFolder).Length != Directory.GetFiles(newFolder).Length) {
                foreach (string newPath in Directory.GetFiles(oldFolder, "*.*")) {
                    var filename = newPath.Split("\\").Last();
                    File.Copy(Path.Combine(oldFolder, filename), Path.Combine(newFolder, filename), true);
                }
            }
        }
    }
}
