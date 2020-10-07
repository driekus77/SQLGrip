using SQLGrip.ParserTree;
using SQLGrip.Keyword;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGrip.SyntaxTree.Nodes;

namespace SQLGrip.ParserTree
{
    public static class SqlNodeFactory
    {
        public static SqlNode CaptureToken<FT>(Token<SqlToken> capturedToken, params SqlNode[] children) where FT : SqlNode
        {
            FT result = (FT)Activator.CreateInstance(typeof(FT), capturedToken);

            foreach (var node in children)
            {
                if (node != null)
                {
                    result.Children.Add(node);
                }
            }

            return result;
        }


        public static FT Capture<FT>(params SqlNode[] children) 
            where FT : SqlNode
        {
            FT result = (FT)Activator.CreateInstance(typeof(FT));

            result.Children.AddRange(children);

            return result;
        }

        public static FT CaptureList<FT>(List<SqlNode> sqlNodes) 
            where FT : SqlNode
        {
            FT result = (FT)Activator.CreateInstance(typeof(FT));

            result.Children.AddRange(sqlNodes);

            return result;
        }


        // public static SqlNode CaptureUnary<FT>(SqlNode sqlOperator, SqlNode sqlOperand) where FT : SqlNode
        // {
        //     sqlOperand.Parent = sqlOperator;
        //     sqlOperator.Children.Add(sqlOperand);
        //     return sqlOperator;
        // }

        // public static SqlNode CaptureBinary<FT>(SqlNode sqlOperator, SqlNode sqlLeftOperand, SqlNode sqlRightOperand) where FT : SqlNode
        // {
        //     sqlLeftOperand.Parent = sqlOperator;
        //     sqlRightOperand.Parent = sqlOperator;
        //     sqlOperator.Children.Add(sqlLeftOperand);
        //     sqlOperator.Children.Add(sqlRightOperand);
        //     return sqlOperator;
        // }

    }
}
