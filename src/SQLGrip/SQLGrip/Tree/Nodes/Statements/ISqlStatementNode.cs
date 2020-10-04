using SQLGrip.Database;
using SQLGrip.Tree.Visitors;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Tree.Nodes.Statements
{
    public interface ISqlStatementNode : ISqlNode
    {
        IList<ISqlNode> FlatNodeTree { get; set; }
    }
}
