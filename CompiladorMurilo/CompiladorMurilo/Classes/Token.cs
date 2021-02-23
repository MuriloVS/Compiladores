using System;
using System.Collections.Generic;
using System.Text;

namespace CompiladorMurilo.Classes
{
    class Token
    {
        public string Type { get; set; }
        public string Text { get; set; }
       

        public Token(string type, string text)
        {
            Type = type;
            Text = text;
        }

        public override string ToString()
        {

            return $"({ Type } { Text })";
        }
    }
}
