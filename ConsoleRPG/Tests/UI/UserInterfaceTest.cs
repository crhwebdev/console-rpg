using ConsoleRPG.Core;
using Xunit;

namespace ConsoleRPG.Tests
{
    public class UserInterfaceTest
    {
        [Fact]
        public void TestTest()
        {
            var test = new Test()
            {
                Name = "Bob"
            };

            Assert.Equal("Bob", test.Name);
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
