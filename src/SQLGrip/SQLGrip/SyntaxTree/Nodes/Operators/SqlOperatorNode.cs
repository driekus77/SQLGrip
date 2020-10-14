using System;
using SQLGrip.Parsers;
using Superpower;
using Superpower.Model;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlOperatorNode : SqlNode
    {
        public TextSpan Operator {get; set;}


        public override string ToString()
        {
            return Operator.ToStringValue();
        }
    }
}
