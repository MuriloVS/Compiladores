using System;
using System.Collections.Generic;
using System.Text;

namespace CompiladorMurilo.Classes
{
    class Compiler
    {
        const string header = ".source Test.src\n" +
                                ".class  public Test\n" +
                                ".super  java/lang/Object\n" +
                                "\n" +
                                ".method public <init>()V\n" +
                                "    aload_0\n" +
                                "    invokenonvirtual java/lang/Object/<init>()V\n" +
                                "    return\n" +
                                ".end method\n" +
                                "\n" +
                                ".method public static main([Ljava/lang/String;)V\n" +
                                "\n" +
                                "    getstatic java/lang/System/out Ljava/io/PrintStream;\n\n";

        const string footer = "\n" +
                              "    invokevirtual java/io/PrintStream/println(I)V\n" +
                              "\n" +
                              "    return\n" +
                              ".limit stack 10\n" +
                              ".end method";

        public List<Token> Tokens { get; set; }
        StringBuilder textFile = new StringBuilder();

        public Compiler(List<Token> tokens)
        {
            Tokens = tokens;
        }

        internal string ByteCode()
        {
            textFile.Append(header);
            Expression();
            textFile.Append(footer);

            return textFile.ToString();
        }

        private void Expression()
        {
            Term();
            if (Tokens[0].Type == "PLUS")
            {                
                Tokens.RemoveAt(0);
                Expression();
                textFile.Append("    iadd\n");
            }
        }

        private void Term()
        {
            Factor();
            if (Tokens[0].Type == "TIMES")
            {
                Tokens.RemoveAt(0);
                Term();
                textFile.Append("    imul\n");
            }
        }

        private void Factor()
        {
            var temp = Tokens[0];
            Tokens.RemoveAt(0);
            if (temp.Type == "NUMBER")
            {
                textFile.Append($"    ldc{ temp.Text }\n");                
            }
            else if (temp.Type == "OP_PAR")
            {
                Expression();
                temp = Tokens[0];
                Tokens.RemoveAt(0);
            }
        }
    }
}
