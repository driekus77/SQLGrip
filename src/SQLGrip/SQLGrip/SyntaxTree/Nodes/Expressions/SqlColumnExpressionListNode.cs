﻿using System;
using SQLGrip.ParserTree;
using Superpower;
using SQLGrip.SyntaxTree.Nodes;


namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlColumnExpressionListNode : SqlNode
    {
        public override Type NodeType => typeof(SqlColumnExpressionListNode);

    }
}