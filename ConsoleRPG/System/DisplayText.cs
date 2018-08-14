using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

//Deprecated

namespace ConsoleRPG.System
{
    public class DisplayText : IEnumerable
    {
        private List<DisplayTextLine> _content;
        public int LineCount => _content.Count;

        //Constructor methods that intializes _content with different types
        public DisplayText()
        {
            _content = new List<DisplayTextLine>();
        }

        public DisplayText(string message)
        {
            _content = new List<DisplayTextLine> { new DisplayTextLine(message) };            
        }

        public DisplayText(DisplayTextLine line)
        {
            _content = new List<DisplayTextLine> { line };
        }

        public DisplayText(List<DisplayTextLine> messages)
        {
            _content = messages;
        }

        //Various Add methods for different types
        public void Add(string line)
        {            
            Add(new DisplayTextLine(line));
        }

        public void Add(DisplayTextLine line)
        {
            _content.Add(line);
        }

        public void Add(List<DisplayTextLine> lines)
        {
            _content.AddRange(lines);
        }

        public void Add(DisplayText displayText)
        {
            foreach(var line in displayText)
            {
                _content.Add((DisplayTextLine)line);
            }
        }
            
        public override string ToString()
        {
            var displayTextAsString = "";

            if (LineCount > 0)
            {
                
                for (var i = 0; i < _content.Count; i++)
                {
                    if(i == _content.Count - 1)
                    {
                        displayTextAsString += _content[i].Text;
                    }
                    else
                    {
                        displayTextAsString += _content[i].Text + "/r/n";
                    }
                    
                }
            }
            

            return displayTextAsString; 
        }

        //Implementation for the GetEnumerator method
        IEnumerator IEnumerable.GetEnumerator()
        {

            return (IEnumerator) GetEnumerator();
            
        }

        public IEnumerator GetEnumerator()
        {
            //return new DisplayTextEnum(_content);
            foreach(var line in _content)
            {
                yield return line;
            }
        }

        //overload + operator

        public static DisplayText operator +(DisplayText d1, DisplayText d2)
        {
            d1.Add(d2);

            return d1;
        }
                               
    }

    //public class DisplayTextEnum : IEnumerator
    //{
    //    public List<DisplayTextLine> Content;

    //    int position = -1;

    //    public DisplayTextEnum(List<DisplayTextLine> lines)
    //    {
    //        Content = lines;
    //    }

    //    public bool MoveNext()
    //    {
    //        position++;
    //        return (position < Content.Count);
    //    }

    //    public void Reset()
    //    {
    //        position = -1;
    //    }

    //    object IEnumerator.Current
    //    {
    //        get
    //        {
    //            return Current;
    //        }
    //    }

    //    public DisplayTextLine Current
    //    {
    //        get
    //        {
    //            try
    //            {
    //                return Content[position];
    //            }
    //            catch (IndexOutOfRangeException)
    //            {
    //                throw new InvalidOperationException();
    //            }
    //        }
    //    }
    //}

}
