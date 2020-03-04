using System.Collections.Generic;
using System;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public double GetLowestGrade()
        {
            var result = double.MaxValue;
            foreach(double i in grades)
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

            foreach(double i in grades)
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

            return result;
        }

        public string GetName()
        {
            return name;
        }

        public void ChangeName(string name) => this.name = name;

        List<double> grades;
        private string name;
    }
}