using SQLGrip.Database;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Tree.Nodes
{
    public interface ISqlNodeFactory
    {

        ISqlNode CaptureToken<FT>(Token<SqlToken> capturedToken, params ISqlNode[] children) where FT : ISqlNode;


        ISqlNode Capture<FT>(params ISqlNode[] children) where FT : ISqlNode;


        ISqlClauseNode CaptureClause<FT>(params ISqlNode[] children) where FT : ISqlClauseNode;


        ISqlNode CaptureUnary<FT>(ISqlNode sqlOperator, ISqlNode sqlOperand) where FT : ISqlNode;

        ISqlNode CaptureBinary<FT>(ISqlNode sqlOperator, ISqlNode sqlLeftOperand, ISqlNode sqlRightOperand) where FT : ISqlNode;


        ISqlStatementNode CaptureStatement<FT>(params ISqlClauseNode[] clauses) where FT : ISqlStatementNode;

    }
}
