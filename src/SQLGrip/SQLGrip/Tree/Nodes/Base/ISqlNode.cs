using SQLGrip.Database;
using SQLGrip.Tree.Visitors;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Tree.Nodes
{
    public interface ISqlNode
    {
        long Id { get;  }

        string Name { get;  }


        Token<SqlToken> CapturedToken { get; }


        ISqlNode Parent { get; set; }

        IList<ISqlNode> Children { get; }


        ISqlNode Named(string name);


        ISqlNode FindFirstByType<FT>(bool deep = false) where FT : ISqlNode;
        ISqlNode FindFirstNotByType<FT>(bool deep = false) where FT : ISqlNode;


        IEnumerable<ISqlNode> FindAllByType<FT>(bool deep = false) where FT : ISqlNode;
        IEnumerable<ISqlNode> FindAllNotByType<FT>(bool deep = false) where FT : ISqlNode;



        ISqlNode AddChildren(params ISqlNode[] children);


        void Visit(IVisitor visitor);
    }
}
