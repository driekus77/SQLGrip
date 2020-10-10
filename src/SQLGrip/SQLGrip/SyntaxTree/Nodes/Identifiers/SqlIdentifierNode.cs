using System;
using SQLGrip.Parsers;
using Superpower;
using Superpower.Model;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlIdentifierNode : SqlNode
    {
        public override Type NodeType => typeof(SqlIdentifierNode);


        public SqlIdentifierNode(Token<SqlToken> capturedToken)
            : base(capturedToken)
        {
        }
    }
}
