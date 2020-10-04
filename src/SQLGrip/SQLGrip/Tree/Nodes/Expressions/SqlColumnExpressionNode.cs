using SQLGrip.Database;
using Superpower;
using System;

namespace SQLGrip.Tree.Nodes
{
    public class SqlColumnExpressionNode : BaseSqlNode, ISqlColumnExpressionNode
    {
        public override Type NodeType => typeof(ISqlColumnExpressionNode);


        public override TokenListParser<SqlToken, ISqlNode> Parser => throw new NotImplementedException();
    }
}
