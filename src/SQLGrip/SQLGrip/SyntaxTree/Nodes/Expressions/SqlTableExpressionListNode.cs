using SQLGrip.Parsers;
using Superpower;
using System;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlTableExpressionListNode : SqlNode
    {
        public override Type NodeType => typeof(SqlTableExpressionListNode);


        public override TokenListParser<SqlToken, SqlNode> Parser => throw new NotImplementedException();
    }
}
