﻿using SQLGrip.ParserTree;
using Superpower;
using System;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlWhereClauseNode : SqlClauseNode
    {
        public override Type NodeType => typeof(SqlWhereClauseNode);

    }
}