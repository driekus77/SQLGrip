using SQLGrip.Core;
using SQLGrip.Database;
using System;
using Xunit;

namespace SQLGripTests.Database
{
    public class SqlTokenTests
    {
        [Fact]
        public void KeywordsTest()
        {
            SqlToken token = SqlToken.Keywords["SELECT"];
            Assert.NotNull(token);
            Assert.Equal("SELECT", token.Text);


            token = SqlToken.Keywords["AND"];
            Assert.NotNull(token);
            Assert.Equal(SqlToken.And, token);


            token = SqlToken.Keywords["FROM"];
            Assert.NotNull(token);
            Assert.Equal(SqlToken.From, token);

        }


    }
}
