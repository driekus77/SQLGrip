using SQLGrip.Parsers;
using SQLGrip.Parsers.ANSI.Version92;
using System;
using System.Linq;
using Xunit;

namespace SQLGripTests.Parsers.ANSI.Version92
{
    public class SqlTokenizerTests
    {
        [Fact]
        public void SimpleSelectTest()
        {
            SqlTokenizer tokenizer = new SqlTokenizer();

            var result = tokenizer.Tokenize("SELECT  *  FROM PERSON ");

            Assert.Equal(8, result.Count());
            Assert.True(result.ElementAt(0).HasValue);
            Assert.Equal(SqlToken.SELECT, result.ElementAt(0).Kind);

            Assert.True(result.ElementAt(1).HasValue);
            Assert.Equal(SqlToken.WHITESPACE, result.ElementAt(1).Kind);

            Assert.True(result.ElementAt(2).HasValue);
            Assert.Equal(SqlToken.ASTERISK, result.ElementAt(2).Kind);

            Assert.True(result.ElementAt(3).HasValue);
            Assert.Equal(SqlToken.WHITESPACE, result.ElementAt(3).Kind);

            Assert.True(result.ElementAt(4).HasValue);
            Assert.Equal(SqlToken.FROM, result.ElementAt(4).Kind);

            Assert.True(result.ElementAt(5).HasValue);
            Assert.Equal(SqlToken.WHITESPACE, result.ElementAt(5).Kind);

            Assert.True(result.ElementAt(6).HasValue);
            Assert.Equal(SqlToken.IDENTIFIER, result.ElementAt(6).Kind);

            Assert.True(result.ElementAt(7).HasValue);
            Assert.Equal(SqlToken.WHITESPACE, result.ElementAt(7).Kind);
        }


    }
}
