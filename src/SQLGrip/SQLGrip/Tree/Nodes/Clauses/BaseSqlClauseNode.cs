using SQLGrip.Database;
using SQLGrip.Tree.Visitors;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Tree.Nodes
{
    public abstract class BaseSqlClauseNode : BaseSqlNode, ISqlClauseNode
    {
        protected BaseSqlClauseNode()
        {
            Id = Tig++;
            CapturedToken = Token<SqlToken>.Empty;
        }

  

        public override void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }


    }
}
