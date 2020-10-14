using SQLGrip.Parsers;
using SQLGrip.SyntaxTree.Visitors;
using Superpower;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlNode
    {

        public string Name { get; protected set; }

        public TextSpan Span { get; set; }

        public SqlNode LeftNode { get; set; }

        public SqlNode RightNode { get; set; }


        public SqlNode Named(string name)
        {
            Name = name;

            return this;
        }


        public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }


        public override string ToString()
        {
            return Span.ToStringValue();
        }
    }
}
