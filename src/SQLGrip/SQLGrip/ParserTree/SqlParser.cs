using SQLGrip.SyntaxTree.Nodes;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.ParserTree
{
    public class SqlParser
    {
        public static SqlTokenizer Tokenizer { get; } = new SqlTokenizer();

        public static SqlTokenParsers TokenParsers { get; } = new SqlTokenParsers();



        public SqlStatementNode Parse(string input)
        {
            var tokens = Tokenizer.Tokenize(input);

            return TokenParsers.DoParse(tokens);
        }
    }
}
