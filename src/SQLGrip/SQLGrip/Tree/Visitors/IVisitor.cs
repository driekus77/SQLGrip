using SQLGrip.Tree.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Tree.Visitors
{
    public interface IVisitor
    {
        void Visit<FTNode>(FTNode node)
            where FTNode : ISqlNode;
    }
}
