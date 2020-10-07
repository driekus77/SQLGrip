﻿using System;
using System.Collections.Generic;
using SQLGrip.ParserTree;
using Superpower;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlStatementNode : SqlNode
    {
        public override Type NodeType => typeof(SqlStatementNode);


        public SqlSelectClauseNode SelectClause => Children[0] as SqlSelectClauseNode;

        public SqlFromClauseNode FromClause => Children[1] as SqlFromClauseNode;

        public SqlWhereClauseNode WhereClause => Children[2] as SqlWhereClauseNode;

        //public SqlGroupByClauseNode GroupByClause => throw new NotImplementedException();

        //public SqlOrderByClauseNode OrderByClause => throw new NotImplementedException();

    }
}