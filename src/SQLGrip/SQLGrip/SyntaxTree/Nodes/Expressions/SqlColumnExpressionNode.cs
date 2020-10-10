using SQLGrip.Parsers;
using Superpower;
using System;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlColumnExpressionNode : SqlNode
    {
        public override Type NodeType => typeof(SqlColumnExpressionNode);


        public override TokenListParser<SqlToken, SqlNode> Parser => throw new NotImplementedException();
    }
}
