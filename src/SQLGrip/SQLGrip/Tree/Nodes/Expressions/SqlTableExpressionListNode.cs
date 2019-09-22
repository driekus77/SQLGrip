using System;
using System.Collections.Generic;
using System.Text;
using SQLGrip.Database;
using SQLGrip.Tree.Visitors;
using Superpower.Model;

namespace SQLGrip.Tree.Nodes
{
    public class SqlTableExpressionListNode : BaseSqlNode, ISqlExpressionListNode
    {
        public SqlTableExpressionListNode()
        {
            Name = "TABLE-EXPRESSION-LIST";
        }
    }
}
