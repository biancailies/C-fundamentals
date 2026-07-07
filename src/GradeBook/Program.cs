using System;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using GradeBook;
using System.Dynamic;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("smt");

            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            
            // TIPS
            //var input = Console.ReadLine();
            //var grade = double.Parse(input);

            System.Console.WriteLine("Please write a grade: ");
            var input = Console.ReadLine();
            double grade = 0.0;

            while(input != "q" && input != "Q")
            {
                try
                {
                    grade = double.Parse(input);
                    book.AddGrade(grade);
                }catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
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

            var stats = book.GetStatistics();

            System.Console.WriteLine(Book.CATEGORY);
            System.Console.WriteLine($"Lowest grade {stats.lowGrade}");
            System.Console.WriteLine($"Highest grade {stats.highGrade}");
            System.Console.WriteLine($"Average grade {stats.Average:N1}");
            System.Console.WriteLine($"Letter grade {stats.LetterGrade}");

        }

        static void OnGradeAdded(Object sender, EventArgs args)
        {
            Console.WriteLine("A grade was added");
        }
    }
}