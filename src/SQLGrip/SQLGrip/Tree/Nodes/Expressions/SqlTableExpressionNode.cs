using SQLGrip.Database;
using Superpower;
using System;

namespace SQLGrip.Tree.Nodes
{
    public class SqlTableExpressionNode : BaseSqlNode, ISqlTableExpressionNode
    {
        public override Type NodeType => typeof(ISqlTableExpressionNode);


        public override TokenListParser<SqlToken, ISqlNode> Parser => throw new NotImplementedException();
    }
}
