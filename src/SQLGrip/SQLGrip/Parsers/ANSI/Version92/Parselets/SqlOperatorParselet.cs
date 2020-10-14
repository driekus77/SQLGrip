using SQLGrip.Parsers;
using SQLGrip.SyntaxTree.Nodes;
using SQLGrip.SyntaxTree.Extensions;
using Superpower;
using Superpower.Model;
using Superpower.Parsers;

namespace SQLGrip.Parsers.ANSI.Version92.Parselets 
{

    public class SqlOperatorParselet
    {
        // Capture operators
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> PLUS =
            Token.EqualTo(SqlToken.PLUS).Select(x => new SqlOperatorNode{ Operator = x.Span });
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> MINUS =
            Token.EqualTo(SqlToken.MINUS).Select(x => new SqlOperatorNode{ Operator = x.Span });
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> ASTERISK =
            Token.EqualTo(SqlToken.ASTERISK).Select(x => new SqlOperatorNode{ Operator = x.Span });
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> FORWARD_SLASH =
            Token.EqualTo(SqlToken.FORWARD_SLASH).Select(x => new SqlOperatorNode{ Operator = x.Span });
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> PERCENT =
            Token.EqualTo(SqlToken.PERCENT).Select(x => new SqlOperatorNode{ Operator = x.Span });
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> CARET =
            Token.EqualTo(SqlToken.CARET).Select(x => new SqlOperatorNode{ Operator = x.Span });
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> LESS_THAN_OR_EQUAL =
            Token.EqualTo(SqlToken.LESS_THAN_OR_EQUAL).Select(x => new SqlOperatorNode{ Operator = x.Span });
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> LESS_THAN =
            Token.EqualTo(SqlToken.LESS_THAN).Select(x => new SqlOperatorNode{ Operator = x.Span });
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> GREATER_THAN =
            Token.EqualTo(SqlToken.GREATER_THAN).Select(x => new SqlOperatorNode{ Operator = x.Span });
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> GREATER_THAN_OR_EQUAL =
            Token.EqualTo(SqlToken.GREATER_THAN_OR_EQUAL).Select(x => new SqlOperatorNode{ Operator = x.Span });
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> EQUAL =
            Token.EqualTo(SqlToken.EQUAL).Select(x => new SqlOperatorNode{ Operator = x.Span });
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> NOT_EQUAL =
            Token.EqualTo(SqlToken.NOT_EQUAL).Select(x => new SqlOperatorNode{ Operator = x.Span });

    }
}
