using System.Collections.Generic;
using System;

namespace GradeBook
{
    public class Book : NamedObject
    {
        public Book(string name) : base(name)
        {
            grades = new List<double>();
        }
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;
        
        public double GetLowestGrade()
        {
            var result = double.MaxValue;
            foreach (double i in grades)
            {
                result = Math.Min(i, result);
            }
            return result;
        }

        public double GetHighestGrade()
        {
            var result = double.MinValue;
            foreach (double i in grades)
            {
                result = Math.Max(i, result);
            }
            return result;
        }

        public double GetAverageGrade()
        {
            var avg = 0.0;

            foreach (double i in grades)
            {
                avg += i;
            }
            return avg / grades.Count;
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();


            result.Average = GetAverageGrade();
            result.Low = GetLowestGrade();
            result.High = GetHighestGrade();
            result.Letter = AddLetter(result.Average);

            return result;
        }

        private char AddLetter(double average)
        {
            switch (average)
            {
                case var d when d >= 90:
                    return 'A';
                    
                case var d when d >= 80:
                    return 'B';
                    
                case var d when d >= 70:
                    return 'C';
                    
                case var d when d >= 60:
                    return 'D';
                    
                default:
                    return 'F';
            }
        }

        List<double> grades;
    }
}