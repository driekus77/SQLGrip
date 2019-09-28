using SQLGrip.Database;
using Superpower;
using System;

namespace SQLGrip.Tree.Nodes
{
    public class SqlSelectClauseNode : BaseSqlClauseNode, ISqlSelectClauseNode
    {
        public override Type NodeType => typeof(ISqlSelectClauseNode);

    }
}
