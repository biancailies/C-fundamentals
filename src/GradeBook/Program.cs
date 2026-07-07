using System;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using GradeBook;
using System.Dynamic;
using static GradeBook.InMemoryBook;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("smt");

            book.GradeAdded += OnGradeAdded;

            System.Console.WriteLine("Please write a grade: ");
            var input = Console.ReadLine();
            double grade = 0.0;

            EnterGrades(book, ref input, ref grade);

            var stats = book.GetStatistics();

            System.Console.WriteLine($"Lowest grade {stats.lowGrade}");
            System.Console.WriteLine($"Highest grade {stats.highGrade}");
            System.Console.WriteLine($"Average grade {stats.Average:N1}");
            System.Console.WriteLine($"Letter grade {stats.LetterGrade}");

        }

        private static void EnterGrades(IBook book, ref string? input, ref double grade)
        {
            while (input != "q" && input != "Q")
            {
                try
                {
                    grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("***");
                }

                System.Console.WriteLine("Please write another grade or q / Q for exit: ");
                input = Console.ReadLine();
            }
        }

        static void OnGradeAdded(Object sender, EventArgs args)
        {
            Console.WriteLine("A grade was added");
        }
    }

}