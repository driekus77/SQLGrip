using System;
using SQLGrip.Database;
using Superpower.Model;

namespace SQLGrip.Tree.Nodes
{
    public class SqlSpecialCharactersNode : BaseSqlNode, ISqlSpecialCharactersNode
    {
        public override Type NodeType => typeof(ISqlSpecialCharactersNode);

        public SqlSpecialCharactersNode(Token<SqlToken> capturedToken)
            : base(capturedToken)
        {
        }
    }
}
