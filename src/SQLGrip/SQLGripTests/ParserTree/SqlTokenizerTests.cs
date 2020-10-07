using SQLGrip;
using SQLGrip.ParserTree;
using System;
using System.Linq;
using Xunit;

namespace SQLGripTests.ParserTree
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
            Assert.Equal(SqlToken.Select, result.ElementAt(0).Kind);

            Assert.True(result.ElementAt(1).HasValue);
            Assert.Equal(SqlToken.WhiteSpace, result.ElementAt(1).Kind);

            Assert.True(result.ElementAt(2).HasValue);
            Assert.Equal(SqlToken.Asterisk, result.ElementAt(2).Kind);

            Assert.True(result.ElementAt(3).HasValue);
            Assert.Equal(SqlToken.WhiteSpace, result.ElementAt(3).Kind);

            Assert.True(result.ElementAt(4).HasValue);
            Assert.Equal(SqlToken.From, result.ElementAt(4).Kind);

            Assert.True(result.ElementAt(5).HasValue);
            Assert.Equal(SqlToken.WhiteSpace, result.ElementAt(5).Kind);

            Assert.True(result.ElementAt(6).HasValue);
            Assert.Equal(SqlToken.Identifier, result.ElementAt(6).Kind);

            Assert.True(result.ElementAt(7).HasValue);
            Assert.Equal(SqlToken.WhiteSpace, result.ElementAt(7).Kind);
        }


    }
}
