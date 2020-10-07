using SQLGrip.SyntaxTree.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.SyntaxTree.Visitors
{
    public abstract class BaseVisitor : IVisitor
    {
        public void Visit<FTNode>(FTNode node)
            where FTNode : SqlNode
        {
            node.Accept(this);
        }

    }
}
