using SQLGrip.Parsers;
using SQLGrip.SyntaxTree.Nodes;
using SQLGrip.SyntaxTree.Extensions;
using Superpower;
using Superpower.Model;
using Superpower.Parsers;

namespace SQLGrip.Parsers.ANSI.Version92.Parselets 
{

    public class SqlKeywordParselet
    {
        // Capture keywords
        public static readonly TokenListParser<SqlToken, SqlKeywordNode> AND =
            Token.EqualTo(SqlToken.AND).Select(x => new SqlKeywordNode{ Span = x.Span });
        public static readonly TokenListParser<SqlToken, SqlKeywordNode> OR =
            Token.EqualTo(SqlToken.OR).Select(x => new SqlKeywordNode{ Span = x.Span });
        public static readonly TokenListParser<SqlToken, SqlKeywordNode> NOT =
            Token.EqualTo(SqlToken.NOT).Select(x => new SqlKeywordNode{ Span = x.Span });
        public static readonly TokenListParser<SqlToken, SqlKeywordNode> LIKE =
            Token.EqualTo(SqlToken.LIKE).Select(x => new SqlKeywordNode{ Span = x.Span });
        public static readonly TokenListParser<SqlToken, SqlKeywordNode> IN =
            Token.EqualTo(SqlToken.IN).Select(x => new SqlKeywordNode{ Span = x.Span });
        public static readonly TokenListParser<SqlToken, SqlKeywordNode> IS =
            Token.EqualTo(SqlToken.IS).Select(x => new SqlKeywordNode{ Span = x.Span });
        public static readonly TokenListParser<SqlToken, SqlKeywordNode> AS =
            Token.EqualTo(SqlToken.AS).Select(x => new SqlKeywordNode{ Span = x.Span });
    }
}
