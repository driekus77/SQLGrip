using SQLGrip.SyntaxTree.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.SyntaxTree.Extensions
{
    public static class SqlNodeExtensions
    {

        public static SqlNode AddChildren(this SqlNode source, params SqlNode[] children)
        {
            foreach (var child in children)
            {
                if (child != null)
                {
                    source.Children.Add(child);
                }
            }

            return source;
        }



        public static SqlNode FirstOrDefault(this SqlNode source, Func<SqlNode, bool> predicate, bool deep = false)
        {
            foreach (SqlNode child in source.Children)
            {
                if (predicate(child) && child is SqlNode c)
                {
                    return c;
                }

                if (deep && child.FirstOrDefault(predicate, deep) is SqlNode recursiveResult)
                {
                    return recursiveResult;
                }
            }

            return default;
        }


        public static IEnumerable<SqlNode> Where(this SqlNode source, Func<SqlNode, bool> predicate, bool deep = false)
        {
            var resultList = new List<SqlNode>();

            foreach (SqlNode child in source.Children)
            {
                if (child is SqlNode c &&
                    predicate(c))
                {
                    resultList.Add(c);
                }

                if (deep && child.Where(predicate, deep) is IEnumerable<SqlNode> recursiveResult)
                { 
                    resultList.AddRange(recursiveResult);
                }
            }

            return resultList;
        }



    }
}
