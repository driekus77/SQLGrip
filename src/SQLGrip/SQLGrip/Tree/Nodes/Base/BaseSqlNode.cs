using SQLGrip.Database;
using SQLGrip.Tree.Visitors;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Tree.Nodes
{
    public abstract class BaseSqlNode : ISqlNode
    {
        protected static long Tig { get; set; }


        public long Id { get; protected set; } = 0;

        public string Name { get; protected set; }


        public Token<SqlToken> CapturedToken { get; protected set; }


        public ISqlNode Parent { get; set; }

        public IList<ISqlNode> Children { get; protected set; } = new List<ISqlNode>();



        protected BaseSqlNode()
        {
            Id = Tig++;
            CapturedToken = Token<SqlToken>.Empty;
        }

        protected BaseSqlNode(Token<SqlToken> capturedToken)
        {
            Id = Tig++;
            CapturedToken = capturedToken;
        }




        public ISqlNode Named(string name)
        {
            Name = name;

            return this;
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



        public ISqlNode FindFirstByType<FT>(bool deep = false) where FT : ISqlNode
        {
            Type ftType = typeof(FT);

            foreach (var child in Children)
            {
                if (ftType.IsInstanceOfType(child))
                {
                    return child;
                }

                if (deep)
                {
                    var recursiveResult = child.FindFirstByType<FT>(deep);

                    if ( recursiveResult != null )
                    {
                        return recursiveResult;
                    }
                }
            }

            return null;
        }

        public ISqlNode FindFirstNotByType<FT>(bool deep = false) where FT : ISqlNode
        {
            Type ftType = typeof(FT);

            foreach (var child in Children)
            {
                if (!ftType.IsInstanceOfType(child))
                {
                    return child;
                }

                if (deep)
                {
                    var recursiveResult = child.FindFirstNotByType<FT>(deep);

                    if (recursiveResult != null)
                    {
                        return recursiveResult;
                    }
                }
            }

            return null;
        }



        public IEnumerable<ISqlNode> FindAllByType<FT>(bool deep = false) where FT : ISqlNode
        {
            Type ftType = typeof(FT);
            var result = new List<ISqlNode>();

            foreach (var child in Children)
            {
                if (ftType.IsInstanceOfType(child))
                {
                    result.Add(child);
                }

                if (deep)
                {
                    var recursiveResult = child.FindAllByType<FT>(deep);

                    if (recursiveResult != null)
                    {
                        result.AddRange(recursiveResult);
                    }
                }
            }

            return result;
        }

        public IEnumerable<ISqlNode> FindAllNotByType<FT>(bool deep = false) where FT : ISqlNode
        {
            Type ftType = typeof(FT);
            var result = new List<ISqlNode>();

            foreach (var child in Children)
            {
                if (!ftType.IsInstanceOfType(child))
                {
                    result.Add(child);
                }

                if (deep)
                {
                    var recursiveResult = child.FindAllNotByType<FT>(deep);

                    if (recursiveResult != null)
                    {
                        result.AddRange(recursiveResult);
                    }
                }
            }

            return result;
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
