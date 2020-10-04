using SQLGrip.Database;
using Superpower;
using System;

namespace SQLGrip.Tree.Nodes
{
    public class SqlWhereClauseNode : BaseSqlClauseNode, ISqlWhereClauseNode
    {
        public override Type NodeType => typeof(ISqlWhereClauseNode);


    }
}
