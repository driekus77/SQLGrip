using System;
using SQLGrip.ParserTree;
using Superpower;
using Superpower.Model;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlKeywordNode : SqlNode
    {
        public override Type NodeType => typeof(SqlKeywordNode);

        public SqlKeywordNode(Token<SqlToken> capturedToken)
            : base(capturedToken)
        {
        }



    }
}
