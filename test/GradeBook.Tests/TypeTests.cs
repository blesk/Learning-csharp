using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
       [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = NewBook("Book 1");
            book1.ChangeName("New name");

            Assert.Equal("New name",
                         book1.GetName());
        }

        private Book NewBook(string name)
        {
            return new Book(name);
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.GetName());
            Assert.Equal("Book 2", book2.GetName());
        }

        [Fact]
        public void TwoWarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
