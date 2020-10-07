using SQLGrip.SyntaxTree.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.SyntaxTree.Visitors
{
    public interface IVisitor
    {
        void Visit<FTNode>(FTNode node)
            where FTNode : SqlNode;
    }
}
