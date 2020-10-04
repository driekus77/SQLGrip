using SQLGrip.Tree.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Tree.Visitors
{
    public abstract class BaseVisitor : IVisitor
    {
        public void Visit<FTNode>(FTNode node)
            where FTNode : ISqlNode
        {
            node.Accept(this);
        }

    }
}
