using System;
using SQLGrip.Parsers;
using SQLGrip.SyntaxTree.Nodes;
using Superpower;
using Superpower.Model;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlSpecialCharactersNode : SqlNode
    {
        public override Type NodeType => typeof(SqlSpecialCharactersNode);

        
        public SqlSpecialCharactersNode(Token<SqlToken> capturedToken)
            : base(capturedToken)
        {
        }

    }
}
