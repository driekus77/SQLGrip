using System;

namespace SQLGrip.Tree.Nodes
{
    public class SqlColumnExpressionListNode : BaseSqlNode, ISqlColumnExpressionListNode
    {
        public override Type NodeType => typeof(ISqlColumnExpressionListNode);

    }
}
