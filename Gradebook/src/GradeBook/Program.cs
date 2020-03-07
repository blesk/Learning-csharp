using System;
using System.Collections.Generic;

namespace GradeBook
{
 
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter book name: ");
            string name = Console.ReadLine();
            IBook book = new DiskBook(name);

            book.GradeAdded += OnGradeAdded;

            while (true)
            {
                Console.Write("Please enter grade or 'q' to quit: ");
                string grade = Console.ReadLine();
                
                if (grade == "Q" || grade == "q")
                    break;
                try
                {
                    var numGrade = double.Parse(grade);
                    book.AddGrade(numGrade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"Statistics for: {book.Name}");
            Console.WriteLine($"Average:        {stats.Average:N3}");
            Console.WriteLine($"High:           {stats.High}");
            Console.WriteLine($"Low:            {stats.Low}");
            Console.WriteLine($"The letter is:  {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added"); 
        }
    }
}