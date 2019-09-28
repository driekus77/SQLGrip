using SQLGrip.Tree.Nodes;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Database
{
    public class SqlParser
    {
        public static SqlTokenizer Tokenizer { get; } = new SqlTokenizer();

        public static SqlNodeFactory NodeFactory { get; } = new SqlNodeFactory();

        public static SqlTokenParsers TokenParsers { get; } = new SqlTokenParsers(NodeFactory);



        public ISqlStatementNode Parse(string input)
        {
            var tokens = Tokenizer.Tokenize(input);

            return TokenParsers.DoParse(tokens);
        }
    }
}
