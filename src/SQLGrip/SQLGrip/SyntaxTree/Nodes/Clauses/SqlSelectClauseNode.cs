using SQLGrip.Parsers;
using Superpower;
using Superpower.Model;
using System;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlSelectClauseNode : SqlNode
    {
        public TextSpan Keyword {get;set;}

        public TextSpan Whitespace1 {get;set;}

        public SqlColumnExpressionListNode SelectList {get;set;}

    }
}
