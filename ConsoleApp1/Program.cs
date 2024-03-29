﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using ConsoleApp1.Classes;
using StringLanguageExtensions;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly string _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json", "PersonBirthdays.json");
        
        /// <summary>
        /// Silly comment
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<AllDoneCode> results = ReadAllDoneFile();
        }
        private static void FindByFirstAndLastName()
        {
            if (File.Exists(_fileName))
            {
                string fileContent   = File.ReadAllText(_fileName);
                List<Person1> people = fileContent.JSonToList<Person1>();

                var personResult = people
                    .FirstOrDefault(person => 
                        person.LastName == "Salinas");

                if (personResult is not null)
                {
                    Debug.WriteLine(personResult.Id);
                }
                else
                {
                    Debug.WriteLine("Is null");
                }

                // alternate syntax for last if statement
                if (personResult != null)
                {
                    Debug.WriteLine(personResult.Id);
                }
                else
                {
                    Debug.WriteLine("Is null");
                }

            }
            else
            {
                FileNotFound();
            }

        }
        private static List<AllDoneCode> ReadAllDoneFile()
        {
            return (
                from line in File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "textfiles", "all_done_codes.txt"))
                where line.Length > 0
                let Items = line.Split(',')
                let count = line.Length
                    select new AllDoneCode()
                    {
                        Code = Items[0],
                        Description = Items[1]
                    })
                .OrderBy(item => item.Code)
                .ToList();

        }
        private static void FileNotFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failed to find");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{ _fileName }");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
