using SQLGrip.SyntaxTree.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.SyntaxTree.Extensions
{
    public static class ListExtensions
    {
        public static void AddRange(this List<SqlNode> publicList, params SqlNode[] nodes)
        {
            if (publicList is List<SqlNode> list)
            {
                list.AddRange(nodes);
            }
            else
            {
                foreach ( SqlNode n in nodes )
                {
                    publicList.Add(n);
                }
            }
        }
    }
}
