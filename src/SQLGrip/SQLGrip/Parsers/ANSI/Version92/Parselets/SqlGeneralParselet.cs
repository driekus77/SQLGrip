using SQLGrip.SyntaxTree.Nodes;
using SQLGrip.SyntaxTree.Extensions;
using Superpower;
using Superpower.Model;
using Superpower.Parsers;


namespace SQLGrip.Parsers.ANSI.Version92.Parselets {

    public class SqlGeneralParselet 
    {
        // Preserve Whitespace
        public static readonly TokenListParser<SqlToken, SqlWhitespaceNode> WHITESPACE = 
            Token.EqualTo(SqlToken.WHITESPACE).Select(x => new SqlWhitespaceNode{ Span = x.Span });
        
        public static readonly TokenListParser<SqlToken, SqlSpecialCharactersNode> COMMA =
            Token.EqualTo(SqlToken.COMMA).Select(x => new SqlSpecialCharactersNode{ Span = x.Span });

        public static readonly TokenListParser<SqlToken, SqlSpecialCharactersNode> PERIOD =
            Token.EqualTo(SqlToken.PERIOD).Select(x => new SqlSpecialCharactersNode{ Span = x.Span });
    }

}