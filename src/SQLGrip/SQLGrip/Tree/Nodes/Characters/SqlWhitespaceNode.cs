using System;
using SQLGrip.Database;
using Superpower;
using Superpower.Model;

namespace SQLGrip.Tree.Nodes
{
    public class SqlWhitespaceNode : BaseSqlNode, ISqlWhitespaceNode
    {
        public override Type NodeType => typeof(ISqlWhitespaceNode);

        public SqlWhitespaceNode(Token<SqlToken> capturedToken)
            : base(capturedToken)
        {
        }
    }
}
