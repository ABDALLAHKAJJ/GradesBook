using Xunit;

namespace GradesBook.Test
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPonitToMethod()
        {
            WriteLogDelegate log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessage;
            log += ReturnMessage;
            string TheMessage = log("test message");
            Assert.Equal("test message", TheMessage);
        }

        private string ReturnMessage(string message)
        {
            //coment
            return message;
        }

        [Fact]
        public void test1()
        {
            // Arrange
            InMemoryBook book1 = GetBook("Book 1");

            // Act
            GetBookSetName(book1, "New Name");
            //Assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void GetBookReturnsDiffrentObjects()
        {
            // Arrange
            InMemoryBook book1 = GetBook("Book 1");
            InMemoryBook book2 = GetBook("Book 2");

            // Act

            //Assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}