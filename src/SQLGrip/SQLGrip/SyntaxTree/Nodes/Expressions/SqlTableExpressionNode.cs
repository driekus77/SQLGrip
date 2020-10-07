using SQLGrip.ParserTree;
using Superpower;
using System;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlTableExpressionNode : SqlNode
    {
        public override Type NodeType => typeof(SqlTableExpressionNode);


        public override TokenListParser<SqlToken, SqlNode> Parser => throw new NotImplementedException();
    }
}
