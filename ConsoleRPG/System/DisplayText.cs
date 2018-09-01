using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

//Deprecated

namespace ConsoleRPG.System
{
    public class DisplayText : IEnumerable
    {

        ////////////////////////////////////////////////////////////////////////////////////////
        //   CONSTRUCTORS
        //////////////////////////////////////////////////////////////////////////////////////// 
        
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

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC PROPS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        public int LineCount => _content.Count;

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PRIVATE FIELDS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        private List<DisplayTextLine> _content;


        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        //////////////////////////////////////////////////////////////////////////////////////// 
        
        /// <summary>
        /// Add string text
        /// </summary>
        /// <param name="line"></param>
        public void Add(string line)
        {            
            Add(new DisplayTextLine(line));
        }

        /// <summary>
        /// Add DisplayTextLine
        /// </summary>
        /// <param name="line"></param>
        public void Add(DisplayTextLine line)
        {
            _content.Add(line);
        }

        /// <summary>
        /// Add List of DisplayTextLine
        /// </summary>
        /// <param name="lines"></param>
        public void Add(List<DisplayTextLine> lines)
        {
            _content.AddRange(lines);
        }

        /// <summary>
        /// Concatenate DisplayText (can also use overloaded "+" operator)
        /// </summary>
        /// <param name="displayText"></param>
        public void Add(DisplayText displayText)
        {
            foreach(var line in displayText)
            {
                _content.Add((DisplayTextLine)line);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC OVERRIDE METHODS FROM BASE                          
        //////////////////////////////////////////////////////////////////////////////////////// 

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

        
        public static DisplayText operator +(DisplayText d1, DisplayText d2)
        {
            d1.Add(d2);

            return d1;
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   IENUMERATOR IMPLIMENTATION                          
        //////////////////////////////////////////////////////////////////////////////////////// 


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
    }    
}
