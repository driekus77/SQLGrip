using System;
using System.Collections.Generic;
using System.Text;
using SQLGrip.Database;
using SQLGrip.Tree.Visitors;
using Superpower.Model;

namespace SQLGrip.Tree.Nodes
{
    public class SqlColumnExpressionListNode : BaseSqlNode, ISqlExpressionListNode
    {
        public SqlColumnExpressionListNode()
        {
            Name = "COLUMN-EXPRESSION-LIST";
        }
    }
}
