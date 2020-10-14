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


        public SqlNode Named(string name)
        {
            Name = name;

            return this;
        }


        public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }


    }
}
