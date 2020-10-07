using SQLGrip.ParserTree;
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
        protected static long Tig { get; set; }


        public long Id { get; protected set; } = 0;

        public string Name { get; protected set; }

        public virtual Type NodeType { get; } = typeof(SqlNode);


        public Token<SqlToken> CapturedToken { get; protected set; }

        public List<SqlNode> Children { get; protected set; } = new List<SqlNode>();



        public SqlNode()
        {
            Id = Tig++;
            CapturedToken = Token<SqlToken>.Empty;
            Name = NodeType.Name;
        }

        protected SqlNode(Token<SqlToken> capturedToken)
            : this()
        {
            CapturedToken = capturedToken;
        }


        public virtual TokenListParser<SqlToken, SqlNode> Parser => throw new NotImplementedException();


        public SqlNode Named(string name)
        {
            Name = name;

            return this;
        }


        public TextSpan NodeText
        {
            get
            {
                SqlNode firstTextNode = this;
                while (firstTextNode.Children.Any() && !firstTextNode.CapturedToken.HasValue)
                {
                    firstTextNode = firstTextNode.Children.FirstOrDefault();
                }

                SqlNode lastTextNode = this;
                while (lastTextNode.Children.Any() && !lastTextNode.CapturedToken.HasValue)
                {
                    lastTextNode = lastTextNode.Children.LastOrDefault();
                }

                return new TextSpan(
                        firstTextNode.CapturedToken.Span.Source,
                        firstTextNode.CapturedToken.Span.Position,
                        lastTextNode.CapturedToken.Span.Position.Absolute - firstTextNode.CapturedToken.Span.Position.Absolute + lastTextNode.CapturedToken.Span.Length);
            }
        }


        public virtual bool IsNodeType(Type other)
        {
            return NodeType.Equals(other);
        }

        public virtual bool IsNodeType<MT>()
        {
            return NodeType.Equals(typeof(MT));
        }


        public virtual void Accept(IVisitor visitor)
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
