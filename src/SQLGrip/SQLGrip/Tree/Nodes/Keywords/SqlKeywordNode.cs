using System;
using SQLGrip.Database;
using Superpower;
using Superpower.Model;

namespace SQLGrip.Tree.Nodes
{
    public class SqlKeywordNode : BaseSqlNode, ISqlKeywordNode
    {
        public override Type NodeType => typeof(ISqlKeywordNode);


        public SqlKeywordNode(Token<SqlToken> capturedToken)
            : base(capturedToken)
        {
        }



    }
}
