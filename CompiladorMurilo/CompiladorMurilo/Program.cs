using CompiladorMurilo.Classes;
using System;
using System.Collections.Generic;
using System.IO;

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

            string file = @"C:\Users\mvs_r\OneDrive\Documents\GitHub\Compiladores\Test.j";

            File.WriteAllText(file, output);

            Console.WriteLine(output);
        }
    }
}
