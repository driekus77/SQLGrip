using Superpower;
using Superpower.Model;
using Superpower.Parsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Database
{
    public static class SqlTextParsers
    {
        static readonly TextParser<SqlToken> LessOrEqual = Span.EqualTo("<=").Value(SqlToken.LessThanOrEqual);
        static readonly TextParser<SqlToken> GreaterOrEqual = Span.EqualTo(">=").Value(SqlToken.GreaterThanOrEqual);
        static readonly TextParser<SqlToken> NotEqual = Span.EqualTo("<>").Value(SqlToken.NotEqual);

        public readonly static TextParser<SqlToken> CompoundOperator = GreaterOrEqual.Or(LessOrEqual.Try().Or(NotEqual));

        public readonly static TextParser<TextSpan> WhiteSpaceString =
            Span.WhiteSpace
                    .Select(chrs => chrs);

        public readonly static TextParser<string> HexInteger =
            Span.EqualTo("0x")
                .IgnoreThen(Character.Digit.Or(Character.Matching(ch => ch >= 'a' && ch <= 'f' || ch >= 'A' && ch <= 'F', "a-f"))
                    .Named("hex digit")
                    .AtLeastOnce())
                .Select(chrs => new string(chrs));

        public readonly static TextParser<char> SqlStringContentChar =
            Span.EqualTo("''").Value('\'').Try().Or(Character.ExceptIn('\'', '\r', '\n'));

        public readonly static TextParser<string> SqlString =
            Character.EqualTo('\'')
                .IgnoreThen(SqlStringContentChar.Many())
                .Then(s => Character.EqualTo('\'').Value(new string(s)));

        public static TextParser<char> RegularExpressionContentChar { get; } =
            Span.EqualTo(@"\/").Value('/').Try().Or(Character.Except('/'));

        public readonly static TextParser<Unit> RegularExpression =
            Character.EqualTo('/')
                .IgnoreThen(RegularExpressionContentChar.Many())
                .IgnoreThen(Character.EqualTo('/'))
                .Value(Unit.Value);

        public readonly static TextParser<TextSpan> Real =
            Numerics.Integer
                .Then(n => Character.EqualTo('.').IgnoreThen(Numerics.Integer).OptionalOrDefault()
                    .Select(f => f == TextSpan.None ? n : new TextSpan(n.Source, n.Position, n.Length + f.Length + 1)));
    }
}
