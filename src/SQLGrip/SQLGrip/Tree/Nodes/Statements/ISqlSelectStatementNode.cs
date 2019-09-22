using SQLGrip.Database;
using SQLGrip.Tree.Visitors;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Tree.Nodes
{
    public interface ISqlSelectStatementNode : ISqlStatementNode
    {
        ISqlSelectClauseNode SelectClause { get; }

        ISqlFromClauseNode FromClause { get; }

        ISqlWhereClauseNode WhereClause { get; }

        ISqlGroupByClauseNode GroupByClause { get; }

        ISqlOrderByClauseNode OrderByClause { get; }

    }
}
