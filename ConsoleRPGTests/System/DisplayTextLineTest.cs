using ConsoleRPG.System;
using System;
using System.Linq;
using Xunit;

namespace ConsoleRPGTests.System
{
    public class DisplayTextLineTest
    {
        
        [Fact]
        public void CanInstantiateWithString()
        {
            var value = "Hello World!";
            var displayTextLine = new DisplayTextLine(value);
            Assert.Equal(value, displayTextLine.Text);
        }

        [Fact]
        public void CanInstantiateWithStringAndColor()
        {
            var value = "Hello World!";
            ConsoleColor color = ConsoleColor.Blue;
            var displayTextLine = new DisplayTextLine(value, color);
            Assert.Equal(value, displayTextLine.Text);
            Assert.Equal(color, displayTextLine.Color);
        }

        [Fact]
        public void ToStringMethodReturnsText()
        {
            var value = "Hello World!";
            var displayTextLine = new DisplayTextLine(value);
            Assert.Equal(value, displayTextLine.ToString());
        }
    }
}
