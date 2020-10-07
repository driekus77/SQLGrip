using SQLGrip.ParserTree;
using SQLGrip.SyntaxTree.Visitors;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Text;
using SQLGrip.SyntaxTree.Nodes;

namespace SQLGrip.SyntaxTree.Nodes
{
    public abstract class SqlClauseNode : SqlNode
    {
        public override Type NodeType { get; }

    }
}
