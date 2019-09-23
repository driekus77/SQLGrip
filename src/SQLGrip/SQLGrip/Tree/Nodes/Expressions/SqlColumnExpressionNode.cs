using System;

namespace SQLGrip.Tree.Nodes
{
    public class SqlColumnExpressionNode : BaseSqlNode, ISqlColumnExpressionNode
    {
        public override Type NodeType => typeof(ISqlColumnExpressionNode);

    }
}
