using SQLGrip.Database;
using SQLGrip.Tree.Visitors;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLGrip.Tree.Nodes
{
    public abstract class BaseSqlNode : ISqlNode
    {
        protected static long Tig { get; set; }


        public long Id { get; protected set; } = 0;

        public string Name { get; protected set; }

        public abstract Type NodeType { get; }


        public Token<SqlToken> CapturedToken { get; protected set; }


        public ISqlNode Parent { get; set; }

        public IList<ISqlNode> Children { get; protected set; } = new List<ISqlNode>();



        protected BaseSqlNode()
        {
            Id = Tig++;
            CapturedToken = Token<SqlToken>.Empty;
            Name = NodeType.Name.Substring(4, NodeType.Name.Length - 8);
        }

        protected BaseSqlNode(Token<SqlToken> capturedToken)
            : this()
        {
            CapturedToken = capturedToken;
        }




        public ISqlNode Named(string name)
        {
            Name = name;

            return this;
        }


        public TextSpan NodeText
        {
            get {
                ISqlNode firstTextNode = this;
                while (firstTextNode.Children.Any() && !firstTextNode.CapturedToken.HasValue)
                {
                    firstTextNode = firstTextNode.Children.FirstOrDefault();
                }

                ISqlNode lastTextNode = this;
                while (lastTextNode.Children.Any() && !lastTextNode.CapturedToken.HasValue)
                {
                    lastTextNode = lastTextNode.Children.LastOrDefault();
                }

                return new TextSpan(
                        firstTextNode.CapturedToken.Span.Source, 
                        firstTextNode.CapturedToken.Span.Position, 
                        lastTextNode.CapturedToken.Span.Position.Absolute - firstTextNode.CapturedToken.Span.Position.Absolute + lastTextNode.CapturedToken.Span.Length);
            }

            set
            {
                //TODO
            }
        }
        

        public virtual ISqlNode AddChildren(params ISqlNode[] children)
        {
            foreach (var child in children)
            {
                if (child != null)
                {
                    child.Parent = this;
                    Children.Add(child);
                }
            }

            return this;
        }


        public virtual bool IsNodeType(Type other)
        {
            return NodeType.Equals(other);
        }

        public virtual bool IsNodeType<MT>()
        {
            return NodeType.Equals(typeof(MT));
        }


        public virtual void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }


        public override string ToString()
        {
            if (CapturedToken.HasValue)
            {
                return $"@{Name}:{CapturedToken.ToStringValue()}";
            }

            return $"@{Name}";
        }

    }
}
