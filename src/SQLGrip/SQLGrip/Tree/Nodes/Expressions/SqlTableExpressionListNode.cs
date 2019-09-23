using System;

namespace SQLGrip.Tree.Nodes
{
    public class SqlTableExpressionListNode : BaseSqlNode, ISqlTableExpressionListNode
    {
        public override Type NodeType => typeof(ISqlTableExpressionListNode);

    }
}
