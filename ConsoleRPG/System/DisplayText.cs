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
                _content.Add(line);
            }
        }

        public void Add(string line)
        {
            _content.Add(new DisplayTextLine(line));
        }

        public override string ToString()
        {
            if (LineCount == 1)
            {
                return _content[0].Text;
            }

            return null;
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public DisplayTextEnum GetEnumerator()
        {
            return new DisplayTextEnum(_content);
        }

        

    }

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class DisplayTextEnum : IEnumerator
    {
        public List<DisplayTextLine> _content;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public DisplayTextEnum(List<DisplayTextLine> list)
        {
            _content = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _content.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public DisplayTextLine Current
        {
            get
            {
                try
                {
                    return _content[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
