using SQLGrip.Core;
using System;
using Xunit;

namespace SQLGripTests.Core
{
    public class StatementTests
    {
        [Fact]
        public void SetTextTest()
        {
            IStatement stmnt = new Statement(Language.PLSQL, "Select LastName from Person");

            Assert.Equal("Select LastName from Person", stmnt.Text);
        }


    }
}
