using SQLGrip.Database;
using SQLGrip.Tree.Visitors;
using Superpower;
using Superpower.Model;
using System;
using System.Collections.Generic;

namespace SQLGrip.Tree.Nodes
{
    public interface ISqlNode
    {
        long Id { get;  }

        string Name { get;  }

        Type NodeType { get; }


        Token<SqlToken> CapturedToken { get; }
        string NodeText { get; }

        ISqlNode Parent { get; set; }

        IList<ISqlNode> Children { get; }


        ISqlNode Named(string name);


        bool IsNodeType(Type other);
        bool IsNodeType<MT>();

        void Accept(IVisitor visitor);
    }
}
