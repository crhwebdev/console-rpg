using ConsoleRPG.System;
using System;
using System.Linq;
using Xunit;

namespace ConsoleRPGTests.System
{
    public class DisplayTextTest
    {
        //can instantiate with nothing and class is successfully formed
        [Fact]
        public void CanInstantiateWithNoArguments()
        {
            DisplayText displayText;
            
            displayText = new DisplayText();
            Assert.Empty(displayText);                       
        }

        //can instantiate class with a string and enumerate over values
        [Fact]
        public void CanInstantiateWithStringAndEnumerateOverValues()
        {
            Assert.True(false);
        }

        //can instantiate class with a DisplayTextLine and enumerate over values
        [Fact]
        public void CanInstantiateWithDisplayTextLineAndEnumerateOverValues()
        {
            Assert.True(false);
        }
        //can instantiate class with List<DisplayTextLine> and enumerate over values
        [Fact]
        public void CanInstantiateWithListAndEnumerateOverValues()
        {
            Assert.True(false);
        }
        //can add a string and enumerate over values
        [Fact]
        public void CanAddStringAndEnumerateOverValues()
        {
            Assert.True(false);
        }
        //can add a DisplayTextLine and enumerate over values
        [Fact]
        public void CanAddDisplayTextLineAndEnumerateOverValues()
        {
            Assert.True(false);
        }
        //can add a List<DisplayTextLine> and enumerate over values
        [Fact]
        public void CanAddListAndEnumerateOverValues()
        {
            Assert.True(false);
        }
        //can add another DisplayText and enumerate over values
        [Fact]
        public void CanAddDisplayTextAndEnumerateOverValues()
        {
            Assert.True(false);
        }
        //ToString method returns a single string value if only one item or a string divided by line breaks if multipel values
        [Fact]
        public void ToStringMethodWorksCorrectly()
        {
            Assert.True(false);
        }

    }
}
