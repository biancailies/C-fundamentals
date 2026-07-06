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
            book.AddGrade(89.1);
            book.AddGrade(9.1);
            book.AddGrade(86.1);

            var stats = book.GetStatistics();

            System.Console.WriteLine($"Lowest grade {stats.lowGrade}");
            System.Console.WriteLine($"Highest grade {stats.highGrade}");
            System.Console.WriteLine($"Average grade {stats.Average:N1}");

        }
    }
}