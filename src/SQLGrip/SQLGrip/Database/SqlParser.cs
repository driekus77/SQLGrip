using SQLGrip.Tree.Nodes;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Database
{
    public class SqlParser
    {
        SqlTokenizer SqlTokenizer { get; }

        SqlTokenParsers SqlTokenParsers { get; }




        public SqlParser()
        {
            SqlTokenizer = new SqlTokenizer();
            SqlTokenParsers = new SqlTokenParsers();
        }


        public ISqlStatementNode Parse(string input)
        {
            var tokens = SqlTokenizer.Tokenize(input);

            return SqlTokenParsers.DoParse(tokens);
        }
    }
}
