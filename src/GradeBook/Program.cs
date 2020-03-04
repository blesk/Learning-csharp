using System;
using System.Collections.Generic;

namespace GradeBook
{
 
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Confederacy of Dunces");
            book.AddGrade(98.2);
            book.AddGrade(18.3);
            book.AddGrade(99.9);

            var stats = book.GetStatistics();

            Console.WriteLine($"Statistics for: {book.GetName()}");
            Console.WriteLine($"Average:{stats.Average:N3}");
            Console.WriteLine($"High:   {stats.High}");
            Console.WriteLine($"Low:    {stats.Low}");
        }
    }
}