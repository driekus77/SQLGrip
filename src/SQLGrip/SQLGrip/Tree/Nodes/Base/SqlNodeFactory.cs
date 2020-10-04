using SQLGrip.Database;
using SQLGrip.Keyword;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGrip.Tree.Nodes;
using SQLGrip.Tree.Nodes.Statements;

namespace SQLGrip.Tree.Nodes
{
    public class SqlNodeFactory : ISqlNodeFactory
    {
        protected IList<ISqlNode> NodeList { get; set; } = new List<ISqlNode>();

        public ISqlNode CaptureToken<FT>(Token<SqlToken> capturedToken, params ISqlNode[] children) where FT : ISqlNode
        {
            FT result = (FT)Activator.CreateInstance(typeof(FT), capturedToken);

            foreach (var node in children)
            {
                if (node != null)
                {
                    node.Parent = result;
                    result.Children.Add(node);
                }
            }

            NodeList.Add(result);

            return result;
        }


        public ISqlNode Capture<FT>(params ISqlNode[] children) where FT : ISqlNode
        {
            FT result = (FT)Activator.CreateInstance(typeof(FT));

            foreach ( var node in children )
            {
                if ( node != null )
                {
                    node.Parent = result;
                    result.Children.Add(node);
                }
            }

            NodeList.Add(result);

            return result;
        }



        public ISqlClauseNode CaptureClause<FT>(params ISqlNode[] children) where FT : ISqlClauseNode
        {
            FT result = (FT)Activator.CreateInstance(typeof(FT));

            foreach (var child in children)
            {
                if (child != null)
                {
                    child.Parent = result;

                    result.Children.Add(child);
                }
            }

            NodeList.Add(result);

            return result;
        }


        public ISqlStatementNode CaptureStatement<FT>(params ISqlClauseNode[] clauses) where FT: ISqlStatementNode
        {
            FT result = (FT)Activator.CreateInstance(typeof(FT));

            foreach ( var clause in clauses )
            {
                if ( clause != null )
                {
                    clause.Parent = (ISqlNode)result;

                    result.Children.Add(clause);
                }
            }

            result.FlatNodeTree = NodeList;

            NodeList = new List<ISqlNode>();

            return result;
        }


        public ISqlNode CaptureUnary<FT>(ISqlNode sqlOperator, ISqlNode sqlOperand) where FT : ISqlNode
        {
            sqlOperand.Parent = sqlOperator;
            sqlOperator.Children.Add(sqlOperand);
            return sqlOperator;
        }

        public ISqlNode CaptureBinary<FT>(ISqlNode sqlOperator, ISqlNode sqlLeftOperand, ISqlNode sqlRightOperand) where FT : ISqlNode
        {
            sqlLeftOperand.Parent = sqlOperator;
            sqlRightOperand.Parent = sqlOperator;
            sqlOperator.Children.Add(sqlLeftOperand);
            sqlOperator.Children.Add(sqlRightOperand);
            return sqlOperator;
        }

    }
}
