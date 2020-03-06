using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class DiskBook : BookBase, IBook
    {
        public DiskBook(string name) : base(name)
        {
            Name = name;
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                using (StreamWriter sw = File.AppendText($"{Name}.txt"))
                {
                    sw.WriteLine(grade.ToString());
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
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

            if (File.Exists($"{Name}.txt"))
            {
                using (StreamReader reader = File.OpenText($"{Name}.txt")) 
                {
                    string text = "";
                    while ((text = reader.ReadLine()) != null)
                    {
                        result.Add(double.Parse(text));
                    }
                }
            }

            return result;
        }

    }
}
