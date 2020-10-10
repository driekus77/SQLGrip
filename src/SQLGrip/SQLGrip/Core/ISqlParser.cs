using SQLGrip.SyntaxTree.Nodes;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Parsers
{
    public interface ISqlParser
    {
        public string Language {get;}

        public string Dialect {get;}

        public string Version {get;}
        
        public SqlStatementNode Parse(string input);

    }
}