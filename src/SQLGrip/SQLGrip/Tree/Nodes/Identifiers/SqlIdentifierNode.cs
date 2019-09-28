using System;
using SQLGrip.Database;
using Superpower;
using Superpower.Model;

namespace SQLGrip.Tree.Nodes
{
    public class SqlIdentifierNode : BaseSqlNode, ISqlIdentifierNode
    {
        public override Type NodeType => typeof(ISqlIdentifierNode);


        public SqlIdentifierNode(Token<SqlToken> capturedToken)
            : base(capturedToken)
        {
        }
    }
}
