using SQLGrip.Database;
using Superpower;
using System;

namespace SQLGrip.Tree.Nodes
{
    public class SqlFromClauseNode : BaseSqlClauseNode, ISqlFromClauseNode
    {
        public override Type NodeType => typeof(ISqlFromClauseNode);


    }
}
