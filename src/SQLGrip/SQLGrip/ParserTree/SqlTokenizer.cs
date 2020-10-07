using SQLGrip.Keyword;
using Superpower;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.ParserTree
{
    public class SqlTokenizer : Tokenizer<SqlToken>
    {
        static readonly SqlToken[] SimpleOps = new SqlToken[128];

        static readonly HashSet<SqlToken> PreRegexTokens = new HashSet<SqlToken>
        {
            SqlToken.And,
            SqlToken.Or,
            SqlToken.Not,
            SqlToken.LeftParen,
            SqlToken.LeftBracket,
            SqlToken.Comma,
            SqlToken.Equal,
            SqlToken.NotEqual,
            SqlToken.Like,
            SqlToken.GreaterThan,
            SqlToken.GreaterThanOrEqual,
            SqlToken.LessThan,
            SqlToken.LessThanOrEqual,
            SqlToken.In,
            SqlToken.Is
        };


        static SqlTokenizer()
        {
            SimpleOps['+'] = SqlToken.Plus;
            SimpleOps['-'] = SqlToken.Minus;
            SimpleOps['*'] = SqlToken.Asterisk;
            SimpleOps['/'] = SqlToken.ForwardSlash;
            SimpleOps['%'] = SqlToken.Percent;
            SimpleOps['^'] = SqlToken.Caret;
            SimpleOps['<'] = SqlToken.LessThan;
            SimpleOps['>'] = SqlToken.GreaterThan;
            SimpleOps['='] = SqlToken.Equal;
            SimpleOps[','] = SqlToken.Comma;
            SimpleOps['.'] = SqlToken.Period;
            SimpleOps['('] = SqlToken.LeftParen;
            SimpleOps[')'] = SqlToken.RightParen;
            SimpleOps['['] = SqlToken.LeftBracket;
            SimpleOps[']'] = SqlToken.RightBracket;
            SimpleOps['?'] = SqlToken.QuestionMark;
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
                    yield return Result.Value(SqlToken.WhiteSpace, ws.Location, ws.Remainder);
                }
                else if (char.IsDigit(next.Value))
                {
                    var hex = SqlTextParsers.HexInteger(next.Location);
                    if (hex.HasValue)
                    {
                        next = hex.Remainder.ConsumeChar();
                        yield return Result.Value(SqlToken.HexNumber, hex.Location, hex.Remainder);
                    }
                    else
                    {
                        var real = SqlTextParsers.Real(next.Location);
                        if (!real.HasValue)
                            yield return Result.CastEmpty<TextSpan, SqlToken>(real);
                        else
                            yield return Result.Value(SqlToken.Number, real.Location, real.Remainder);

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

                    yield return Result.Value(SqlToken.String, str.Location, str.Remainder);
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
                        yield return Result.Value(SqlToken.BuiltInIdentifier, beginIdentifier, next.Location);
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
                        yield return Result.Value(SqlToken.Identifier, beginIdentifier, next.Location);
                    }
                }
                else if (next.Value == '/' &&
                         (!state.Previous.HasValue ||
                            PreRegexTokens.Contains(state.Previous.Value.Kind)))
                {
                    var regex = SqlTextParsers.RegularExpression(next.Location);
                    if (!regex.HasValue)
                        yield return Result.CastEmpty<Unit, SqlToken>(regex);

                    yield return Result.Value(SqlToken.RegularExpression, next.Location, regex.Remainder);
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
                    else if (next.Value < SimpleOps.Length && SimpleOps[next.Value] != SqlToken.None)
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
                   next.Value < SimpleOps.Length && SimpleOps[next.Value] != SqlToken.None;
        }

        static bool TryGetKeyword(TextSpan span, out SqlToken keyword)
        {
            if ( SqlToken.Keywords.ContainsKey(span.ToStringValue()) )
            {
                keyword = SqlToken.Keywords[span.ToStringValue()];
                return true;
            }

            keyword = SqlToken.None;
            return false;
        }

    }


}
