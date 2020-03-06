using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public interface IBook
    {
        string Name { get; }
        void AddGrade(double grade);
        event GradeAddedDelegate GradeAdded;
        Statistics GetStatistics();
    }
}
