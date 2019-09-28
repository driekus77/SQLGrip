using System;
using SQLGrip.Database;
using Superpower;
using Superpower.Model;

namespace SQLGrip.Tree.Nodes
{
    public class SqlOperatorNode : BaseSqlNode, ISqlOperatorNode
    {
        public override Type NodeType => typeof(ISqlOperatorNode);

        public SqlOperatorNode(Token<SqlToken> capturedToken)
            : base(capturedToken)
        {
        }



    }
}
