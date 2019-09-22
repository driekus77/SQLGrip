using System;
using System.Collections.Generic;
using System.Text;
using SQLGrip.Database;
using SQLGrip.Keyword;
using SQLGrip.Tree.Visitors;
using Superpower.Model;

namespace SQLGrip.Tree.Nodes
{
    public class SqlFromClauseNode : BaseSqlClauseNode, ISqlFromClauseNode
    {
        public SqlFromClauseNode()
        {
            Name = "FROM-CLAUSE";
        }

    }
}
