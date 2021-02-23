using CompiladorMurilo.Classes;
using System;
using System.Collections.Generic;

namespace CompiladorMurilo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input: ");
            string input = Console.ReadLine();

            var lexer = new Lexer();
            List<Token> tokens = lexer.ReturnTokens(input);

            var compiler = new Compiler(tokens);
            string output = compiler.ByteCode();

            foreach (var token in tokens)
            {
                Console.WriteLine(token.ToString());
            }

            Console.WriteLine(output);
        }
    }
}
