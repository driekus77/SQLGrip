using SQLGrip.Tree.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Tree.Extensions
{
    public static class IListExtensions
    {
        public static void AddRange(this IList<ISqlNode> publicList, params ISqlNode[] nodes)
        {
            if (publicList is List<ISqlNode> list)
            {
                list.AddRange(nodes);
            }
            else
            {
                foreach ( ISqlNode n in nodes )
                {
                    publicList.Add(n);
                }
            }
        }
    }
}
