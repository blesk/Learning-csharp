using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double Low;
        public double High;
        public double Sum;
        public double Count;
        public char Letter
        {
            get
            {
                switch (Average)
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
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(Low, number);
            High = Math.Max(High, number);
        }

        public Statistics()
        {
            Low = double.MaxValue;
            High = double.MinValue;
            Sum = 0;
            Count = 0;
        }
    }


}