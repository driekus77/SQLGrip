using System;
using System.Collections.Generic;
using System.Text;
using SQLGrip.Database;
using SQLGrip.Keyword;
using SQLGrip.Tree.Visitors;
using Superpower.Model;

namespace SQLGrip.Tree.Nodes
{
    public class SqlSpecialCharNode : BaseSqlNode, ISqlSpecialCharactersNode
    {
        public SqlSpecialCharNode(Token<SqlToken> capturedToken)
            : base(capturedToken)
        {
            Name = "CHARS";
        }
    }
}
