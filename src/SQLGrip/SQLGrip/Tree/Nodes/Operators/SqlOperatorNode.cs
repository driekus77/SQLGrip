using System;
using System.Collections.Generic;
using System.Text;
using SQLGrip.Database;
using SQLGrip.Keyword;
using SQLGrip.Tree.Visitors;
using Superpower.Model;

namespace SQLGrip.Tree.Nodes
{
    public class SqlOperatorNode : BaseSqlNode, ISqlOperatorNode
    {
        public SqlOperatorNode(Token<SqlToken> capturedToken)
            : base(capturedToken)
        {
            Name = $"OPERATOR:{capturedToken.ToStringValue()}";
        }



    }
}
