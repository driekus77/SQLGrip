using System;
using SQLGrip.Parsers;
using SQLGrip.SyntaxTree.Nodes;
using Superpower;
using Superpower.Model;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlSpecialCharactersNode : SqlNode
    {
        public TextSpan Span {get;set;}


        public override string ToString()
        {
            return Span.ToStringValue();
        }
    }
}
