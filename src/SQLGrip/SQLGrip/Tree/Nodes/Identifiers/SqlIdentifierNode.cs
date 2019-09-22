using System;
using System.Collections.Generic;
using System.Text;
using SQLGrip.Database;
using SQLGrip.Tree.Visitors;
using Superpower.Model;

namespace SQLGrip.Tree.Nodes
{
    public class SqlIdentifierNode : BaseSqlNode, ISqlIdentifierNode
    {
        public SqlIdentifierNode(Token<SqlToken> capturedToken)
            : base(capturedToken)
        {
            Name = "IDENTIFIER";
        }
    }
}
