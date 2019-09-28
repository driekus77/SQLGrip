using System;
using System.Collections.Generic;
using SQLGrip.Database;
using Superpower;

namespace SQLGrip.Tree.Nodes
{
    public class SqlSelectStatementNode : BaseSqlNode, ISqlSelectStatementNode
    {
        public override Type NodeType => typeof(ISqlSelectStatementNode);


        public IList<ISqlNode> FlatNodeTree { get; set; }

        public ISqlSelectClauseNode SelectClause => Children[0] as ISqlSelectClauseNode;

        public ISqlFromClauseNode FromClause => Children[1] as ISqlFromClauseNode;

        public ISqlWhereClauseNode WhereClause => Children[2] as ISqlWhereClauseNode;

        public ISqlGroupByClauseNode GroupByClause => throw new NotImplementedException();

        public ISqlOrderByClauseNode OrderByClause => throw new NotImplementedException();

    }
}
