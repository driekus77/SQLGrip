using SQLGrip.Parsers;
using Superpower;
using System;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlFromClauseNode : SqlClauseNode
    {
        public override Type NodeType { get => typeof(SqlFromClauseNode); }

    }
}
