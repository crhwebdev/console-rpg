using Xunit;
using System.Collections.Generic;
using ConsoleRPG.System;

namespace ConsoleRPG.Tests.System
{
    public class DisplayTextTest
    {

        //Can initialize a message with nothing, a string, or a list
        //Message has Add method to add additional strings
        //Message has a property for its contents that returns a List
        //Message has a ToString method that either prints out a single string (if Contents only contains one item, or a string with line breaks for each item)
        //Message has an Equals and GetHash that allows comparing two messages directly???

        //can set and get Contents property 

        //[Fact]
        //public void CanCreateMessageWithStringAndGetContent()
        //{
        //    string content = "Hello World!";
        //    var message = new DisplayText("Hello World!");
        //    Assert.Equal(new List<string> { content }, message.Content);
        //}

        //[Fact]
        //public void CanCreateMessageWithEmptyAndGetContent()
        //{            
        //    var message = new DisplayText();
        //    Assert.True(message.Content.Count == 0);
        //}

        //[Fact]
        //public void CanCreateMessageWithListAndGetContent()
        //{
        //    var contents = new List<string> { "Hello World!", "From Me" };
        //    var message = new DisplayText(contents);
        //    Assert.Equal(contents, message.Content);
        //}

        //[Fact]
        //public void CanAddTextToMessage()
        //{
        //    string contents = "Hello World!";
        //    var message = new Message("Hello World!");
        //    Assert.Equal(message.Contents, contents);
        //}



    }
}
