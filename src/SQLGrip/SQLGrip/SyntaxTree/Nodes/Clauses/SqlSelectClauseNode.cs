using SQLGrip.ParserTree;
using Superpower;
using System;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlSelectClauseNode : SqlClauseNode
    {
        public override Type NodeType {get => typeof(SqlSelectClauseNode); }

    }
}
