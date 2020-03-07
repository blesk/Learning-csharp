using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public abstract class BookBase : IBook
    {
        public BookBase(string name)
        {
            Name = name;
        }
        public string Name
        {
            get;
            set;
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
}
