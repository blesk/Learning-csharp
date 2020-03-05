using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStats()
        {
            //arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal('B', result.Letter);
         }

        [Fact]
        public void CheckOutOfBounds()
        {
            //arrange
            var book = new Book("OOB");
            double[] values = { -1, 0, 20, 100, 101 };
            foreach(double i in values)
            {
                try
                {
                    book.AddGrade(i);
                }
                catch (ArgumentException ex)
                {
                }
            }

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(0, result.Low);
            Assert.Equal(100, result.High);
            Assert.Equal(40, result.Average);
        }
    }
}
