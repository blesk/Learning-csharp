using System.Collections.Generic;
using System;

namespace GradeBook
{
    public class InMemoryBook : BookBase, IBook
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
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

        
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            
            foreach (double i in grades)
            {
                result.Add(i);
            }

            return result;
        }

        List<double> grades;
    }
}