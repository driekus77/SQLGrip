using Superpower;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;


namespace SQLGrip.Parsers.ANSI.Version92
{

    [Language(name: "SQL", dialect: "ANSI", version: "92", subject: "Tokenizer")]
    public class SqlTokenizer : Tokenizer<SqlToken>
    {
        static readonly SqlToken[] SimpleOps = new SqlToken[128];

        static readonly HashSet<SqlToken> PreRegexTokens = new HashSet<SqlToken>
        {
            SqlToken.AND,
            SqlToken.OR,
            SqlToken.NOT,
            SqlToken.LEFTPAREN,
            SqlToken.LEFTBRACKET,
            SqlToken.COMMA,
            SqlToken.EQUAL,
            SqlToken.NOT_EQUAL,
            SqlToken.LIKE,
            SqlToken.GREATER_THAN,
            SqlToken.GREATER_THAN_OR_EQUAL,
            SqlToken.LESS_THAN,
            SqlToken.LESS_THAN_OR_EQUAL,
            SqlToken.IN,
            SqlToken.IS
        };


        static SqlTokenizer()
        {
            SimpleOps['+'] = SqlToken.PLUS;
            SimpleOps['-'] = SqlToken.MINUS;
            SimpleOps['*'] = SqlToken.ASTERISK;
            SimpleOps['/'] = SqlToken.FORWARD_SLASH;
            SimpleOps['%'] = SqlToken.PERCENT;
            SimpleOps['^'] = SqlToken.CARET;
            SimpleOps['<'] = SqlToken.LESS_THAN;
            SimpleOps['>'] = SqlToken.GREATER_THAN;
            SimpleOps['='] = SqlToken.EQUAL;
            SimpleOps[','] = SqlToken.COMMA;
            SimpleOps['.'] = SqlToken.PERIOD;
            SimpleOps['('] = SqlToken.LEFTPAREN;
            SimpleOps[')'] = SqlToken.RIGHTPAREN;
            SimpleOps['['] = SqlToken.LEFTBRACKET;
            SimpleOps[']'] = SqlToken.RIGHTBRACKET;
            SimpleOps['?'] = SqlToken.QUESTIONMARK;
        }




        protected override IEnumerable<Result<SqlToken>> Tokenize(
            TextSpan span,
            TokenizationState<SqlToken> state)
        {
            var next = span.ConsumeChar();
            if (!next.HasValue)
                yield break;

            do
            {
                if (char.IsWhiteSpace(next.Value))
                {
                    var ws = SqlTextParsers.WhiteSpaceString(next.Location);
                    if (ws.HasValue)
                    {
                        next = ws.Remainder.ConsumeChar();
                    }
                    yield return Result.Value(SqlToken.WHITESPACE, ws.Location, ws.Remainder);
                }
                else if (char.IsDigit(next.Value))
                {
                    var hex = SqlTextParsers.HexInteger(next.Location);
                    if (hex.HasValue)
                    {
                        next = hex.Remainder.ConsumeChar();
                        yield return Result.Value(SqlToken.HEX_NUMBER_NUMERIC, hex.Location, hex.Remainder);
                    }
                    else
                    {
                        var real = SqlTextParsers.Real(next.Location);
                        if (!real.HasValue)
                            yield return Result.CastEmpty<TextSpan, SqlToken>(real);
                        else
                            yield return Result.Value(SqlToken.NUMBER_NUMERIC, real.Location, real.Remainder);

                        next = real.Remainder.ConsumeChar();
                    }

                    if (!IsDelimiter(next))
                    {
                        yield return Result.Empty<SqlToken>(next.Location, new[] { "digit" });
                    }
                }
                else if (next.Value == '\'')
                {
                    var str = SqlTextParsers.SqlString(next.Location);
                    if (!str.HasValue)
                        yield return Result.CastEmpty<string, SqlToken>(str);

                    next = str.Remainder.ConsumeChar();

                    yield return Result.Value(SqlToken.STRING, str.Location, str.Remainder);
                }
                else if (next.Value == '@')
                {
                    var beginIdentifier = next.Location;
                    var startOfName = next.Remainder;
                    do
                    {
                        next = next.Remainder.ConsumeChar();
                    }
                    while (next.HasValue && char.IsLetterOrDigit(next.Value));

                    if (next.Remainder == startOfName)
                    {
                        yield return Result.Empty<SqlToken>(startOfName, new[] { "built-in identifier name" });
                    }
                    else
                    {
                        yield return Result.Value(SqlToken.BUILTIN_IDENTIFIER, beginIdentifier, next.Location);
                    }
                }
                else if (char.IsLetter(next.Value) || next.Value == '_')
                {
                    var beginIdentifier = next.Location;
                    do
                    {
                        next = next.Remainder.ConsumeChar();
                    }
                    while (next.HasValue && (char.IsLetterOrDigit(next.Value) || next.Value == '_'));

                    if (TryGetKeyword(beginIdentifier.Until(next.Location), out SqlToken keyword))
                    {
                        yield return Result.Value(keyword, beginIdentifier, next.Location);
                    }
                    else
                    {
                        yield return Result.Value(SqlToken.IDENTIFIER, beginIdentifier, next.Location);
                    }
                }
                else if (next.Value == '/' &&
                         (!state.Previous.HasValue ||
                            PreRegexTokens.Contains(state.Previous.Value.Kind)))
                {
                    var regex = SqlTextParsers.RegularExpression(next.Location);
                    if (!regex.HasValue)
                        yield return Result.CastEmpty<Unit, SqlToken>(regex);

                    yield return Result.Value(SqlToken.REGULAR_EXPRESSION, next.Location, regex.Remainder);
                    next = regex.Remainder.ConsumeChar();
                }
                else
                {
                    var compoundOp = SqlTextParsers.CompoundOperator(next.Location);
                    if (compoundOp.HasValue)
                    {
                        yield return Result.Value(compoundOp.Value, compoundOp.Location, compoundOp.Remainder);
                        next = compoundOp.Remainder.ConsumeChar();
                    }
                    else if (next.Value < SimpleOps.Length && SimpleOps[next.Value] != SqlToken.NONE)
                    {
                        yield return Result.Value(SimpleOps[next.Value], next.Location, next.Remainder);
                        next = next.Remainder.ConsumeChar();
                    }
                    else
                    {
                        yield return Result.Empty<SqlToken>(next.Location);
                        next = next.Remainder.ConsumeChar();
                    }
                }

            } while (next.HasValue);
        }

        static bool IsDelimiter(Result<char> next)
        {
            return !next.HasValue ||
                   char.IsWhiteSpace(next.Value) ||
                   next.Value < SimpleOps.Length && SimpleOps[next.Value] != SqlToken.NONE;
        }


        static readonly Dictionary<string, TokenAttribute> TokenTable = new Dictionary<string, TokenAttribute>(StringComparer.InvariantCultureIgnoreCase);
        static readonly Dictionary<string, SqlToken> Keywords = new Dictionary<string, SqlToken>(StringComparer.InvariantCultureIgnoreCase);


        static void FillTables()
        {
            if ( TokenTable.Count == 0 )
            {
                foreach ( SqlToken enumValue in typeof(SqlToken).GetEnumValues() )
                {
                    var enumName = enumValue.ToString();
                    var memberInfo = typeof(SqlToken).GetMember(enumName).FirstOrDefault();
                    var tokenAttribute = (TokenAttribute)memberInfo.GetCustomAttribute(typeof(TokenAttribute), false);
                    TokenTable[enumName] = tokenAttribute;

                    if ( tokenAttribute.Category.Equals("keyword", StringComparison.InvariantCultureIgnoreCase) )
                    {
                        Keywords[tokenAttribute.Text] = enumValue;
                    }
                }
            }
        }


        static bool TryGetKeyword(TextSpan span, out SqlToken keyword)
        {
            // First time fill Keywords if empty
            FillTables();

            if ( Keywords.ContainsKey(span.ToStringValue()) )
            {
                keyword = Keywords[span.ToStringValue()];
                return true;
            }

            keyword = SqlToken.NONE;
            return false;
        }

    }


}
