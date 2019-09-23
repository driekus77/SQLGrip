using SQLGrip.Tree.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Tree.Extensions
{
    public static class ISqlNodeExtensions
    {

        public static ISqlNode FirstOrDefault(this ISqlNode source, Func<ISqlNode, bool> predicate, bool deep = false)
        {
            foreach (ISqlNode child in source.Children)
            {
                if (predicate(child) && child is ISqlNode c)
                {
                    return c;
                }

                if (deep && child.FirstOrDefault(predicate, deep) is ISqlNode recursiveResult)
                {
                    return recursiveResult;
                }
            }

            return default;
        }


        public static IEnumerable<ISqlNode> Where(this ISqlNode source, Func<ISqlNode, bool> predicate, bool deep = false)
        {
            var resultList = new List<ISqlNode>();

            foreach (ISqlNode child in source.Children)
            {
                if (child is ISqlNode c &&
                    predicate(c))
                {
                    resultList.Add(c);
                }

                if (deep && child.Where(predicate, deep) is IEnumerable<ISqlNode> recursiveResult)
                { 
                    resultList.AddRange(recursiveResult);
                }
            }

            return resultList;
        }



    }
}
