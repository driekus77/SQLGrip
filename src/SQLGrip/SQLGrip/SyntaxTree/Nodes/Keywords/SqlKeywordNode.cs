using System;
using SQLGrip.Parsers;
using Superpower;
using Superpower.Model;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlKeywordNode : SqlNode
    {
        public TextSpan Keyword { get; set; }

        public override string ToString()
        {
            return Keyword.ToStringValue();
        }

    }
}
