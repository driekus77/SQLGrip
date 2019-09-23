using SQLGrip.Database;
using SQLGrip.Tree.Visitors;
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
        TextSpan NodeText { get; set; }

        ISqlNode Parent { get; set; }

        IList<ISqlNode> Children { get; }


        ISqlNode Named(string name);


        bool IsNodeType(Type other);
        bool IsNodeType<MT>();

        

        ISqlNode AddChildren(params ISqlNode[] children);


        void Visit(IVisitor visitor);
    }
}
