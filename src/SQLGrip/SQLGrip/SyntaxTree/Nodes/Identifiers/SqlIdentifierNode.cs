using System;
using SQLGrip.Parsers;
using Superpower;
using Superpower.Model;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlIdentifierNode : SqlNode
    {
        public TextSpan Identifier {get;set;}

        public override string ToString()
        {
            return Identifier.ToStringValue();
        }

    }
}
