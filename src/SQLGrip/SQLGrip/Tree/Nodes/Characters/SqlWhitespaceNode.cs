﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLGrip.Database;
using SQLGrip.Tree.Visitors;
using Superpower.Model;

namespace SQLGrip.Tree.Nodes
{
    public class SqlWhitespaceNode : BaseSqlNode, ISqlWhitespaceNode
    {
        public SqlWhitespaceNode(Token<SqlToken> capturedToken)
            : base(capturedToken)
        {
            Name = "WS";
        }
    }
}
