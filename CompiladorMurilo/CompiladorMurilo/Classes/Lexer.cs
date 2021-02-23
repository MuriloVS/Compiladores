using System;
using System.Collections.Generic;
using System.Text;

namespace CompiladorMurilo.Classes
{
    class Lexer
    {    
        public List<Token> ReturnTokens(string input)
        {
            input += "$";
            
            List<Token> tokens = new List<Token>();

            int i = 0;            

            while (true)
            {
                if (input[i] == ' ')
                {
                    i += 1;
                }
                else if (input[i] == '+')
                {
                    i += 1;
                    tokens.Add(new Token("PLUS", "+"));
                }
                else if (input[i] == '*')
                {
                    i += 1;
                    tokens.Add(new Token("TIMES", "*"));
                }
                else if (input[i] == '(')
                {
                    i += 1;
                    tokens.Add(new Token("OP_PAR", "("));
                }
                else if (input[i] == ')')
                {
                    i += 1;
                    tokens.Add(new Token("CL_PAR", ")"));
                }
                else if (Char.IsDigit(input[i]))
                {
                    StringBuilder number = new StringBuilder();
                    number.Append(input[i]);
                    i += 1;
                    while (Char.IsDigit(input[i]))
                    {
                        number.Append(input[i]);
                        i += 1;
                    }
                    tokens.Add(new Token("NUMBER", number.ToString()));
                }
                else if (input[i] == '$')
                {
                    tokens.Add(new Token("END", "$"));
                    break;
                }
                else
                {
                    Console.WriteLine($"Unknown character: { input[i] }");
                    i += 1;
                }
            }

            return tokens;
        }           
    }
}
