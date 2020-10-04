using SQLGrip.Database;
using Superpower;
using System;

namespace SQLGrip.Tree.Nodes
{
    public class SqlTableExpressionListNode : BaseSqlNode, ISqlTableExpressionListNode
    {
        public override Type NodeType => typeof(ISqlTableExpressionListNode);


        public override TokenListParser<SqlToken, ISqlNode> Parser => throw new NotImplementedException();
    }
}
