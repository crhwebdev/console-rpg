using ConsoleRPG.System;
using System;
using System.Collections.Generic;
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
            var displayText = new DisplayText();
            Assert.Empty(displayText);                       
        }

        //can instantiate class with a string and enumerate over values
        [Fact]
        public void CanInstantiateWithStringAndEnumerateOverValues()
        {
            var value = "Hello World!";
            var displayText = new DisplayText(value);
            foreach(var line in displayText)
            {
                Assert.Equal(value, line.ToString());
            }
            
        }

        //can instantiate class with a DisplayTextLine and enumerate over values
        [Fact]
        public void CanInstantiateWithDisplayTextLineAndEnumerateOverValues()
        {
            var value = "Hello World!";
            var displayTextLine = new DisplayTextLine(value);
            var displayText = new DisplayText(displayTextLine);
            foreach(var line in displayText)
            {
                Assert.Equal(value, line.ToString());
            }
            
        }
        //can instantiate class with List<DisplayTextLine> and enumerate over values
        [Fact]
        public void CanInstantiateWithListAndEnumerateOverValues()
        {
            var value = "Hello World!";
            var displayTextLineList = new List<DisplayTextLine>
            {
                new DisplayTextLine(value),
                new DisplayTextLine(value)
            };

            var displayText = new DisplayText(displayTextLineList);

            foreach(var line in displayText)
            {
                Assert.Equal(value, line.ToString());
            }
            
        }
        //can add a string and enumerate over values
        [Fact]
        public void CanAddStringAndEnumerateOverValues()
        {
            var value = "Hello World!";
            var displayText = new DisplayText();
            Assert.Empty(displayText);
            displayText.Add(value);
            foreach(var line in displayText)
            {
                Assert.Equal(value, line.ToString());
            }            
        }
        //can add a DisplayTextLine and enumerate over values
        [Fact]
        public void CanAddDisplayTextLineAndEnumerateOverValues()
        {
            var value = "Hello World!";
            var displayText = new DisplayText();
            Assert.Empty(displayText);
            displayText.Add(new DisplayTextLine(value));

            foreach (var line in displayText)
            {
                Assert.Equal(value, line.ToString());
            }
            
        }
        //can add a List<DisplayTextLine> and enumerate over values
        [Fact]
        public void CanAddListAndEnumerateOverValues()
        {
            var value = "Hello World!";
            var displayText = new DisplayText(value);            
            var displayTextLineList = new List<DisplayTextLine>
            {
                new DisplayTextLine(value),
                new DisplayTextLine(value)
            };

            displayText.Add(displayTextLineList);

            Assert.Equal(3, displayText.LineCount);

            foreach (var line in displayText)
            {
                Assert.Equal(value, line.ToString());
            }
        }
        //can add another DisplayText and enumerate over values
        [Fact]
        public void CanAddDisplayTextAndEnumerateOverValues()
        {
            var value = "Hello World!";
            var displayText = new DisplayText(value);            
            var displayTextSecond = new DisplayText(value);

            displayText.Add(displayTextSecond);
            Assert.Equal(2, displayText.LineCount);

            foreach (var line in displayText)
            {
                Assert.Equal(value, line.ToString());
            }


        }
        //ToString method returns a single string value if only one item or a string divided by line breaks if multipel values
        [Fact]
        public void ToStringMethodWorksCorrectly()
        {
            
            var displayText = new DisplayText();

            //return empty string if it contains nothing
            Assert.Equal("", displayText.ToString());

            //returns single line if it has only one line
            var value = "Hello World!";
            displayText.Add(value);
            Assert.Equal(value, displayText.ToString());

            //returns multiple lines seperated by '/r/n' if it has multiple lines
            displayText.Add(value);
            Assert.Equal(value + "/r/n" + value, displayText.ToString());

        }

    }
}
