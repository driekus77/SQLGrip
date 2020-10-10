using System;
using SQLGrip.Parsers;
using Superpower;
using Superpower.Model;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlOperatorNode : SqlNode
    {
        public override Type NodeType => typeof(SqlOperatorNode);

        public override TokenListParser<SqlToken, SqlNode> Parser => throw new NotImplementedException();

        public SqlOperatorNode(Token<SqlToken> capturedToken)
            : base(capturedToken)
        {
        }



    }
}
