using SQLGrip.SyntaxTree.Nodes;
using SQLGrip.SyntaxTree.Visitors;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlCharactersNode : SqlNode
    {
        public override Type NodeType => typeof(SqlCharactersNode);
    }
}
