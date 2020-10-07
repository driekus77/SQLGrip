using System;
using SQLGrip.ParserTree;
using Superpower;
using Superpower.Model;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlWhitespaceNode : SqlNode
    {
        public override Type NodeType => typeof(SqlWhitespaceNode);

        public static readonly SqlWhitespaceNode Empty = new SqlWhitespaceNode(Token<SqlToken>.Empty);
        public static readonly SqlWhitespaceNode Space = new SqlWhitespaceNode(new Token<SqlToken>(SqlToken.WhiteSpace, new TextSpan(" ")));


        public SqlWhitespaceNode(Token<SqlToken> capturedToken)
            : base(capturedToken)
        {
        }
    }
}
