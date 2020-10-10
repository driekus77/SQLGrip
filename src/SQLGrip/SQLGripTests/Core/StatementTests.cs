using SQLGrip;
using System;
using Xunit;

namespace SQLGripTests.Core
{
    public class StatementTests
    {
        /*
        [Fact]
        public void SetTextTest()
        {
            var stmnt = new Statement("Select LastName from Person");

            Assert.Equal("Select LastName from Person", stmnt.Text);
        }

        [Fact]
        public void SimpleWhereClauseTest()
        {
            var stmnt = new Statement(@"
                Select * 
                from Person 
                where LastName = 'Roeland'
            ");
            
            var parsedStmnt = stmnt.Parse();

            // Assert.Equal(@"
            //     Select * 
            //     from Person 
            //     where LastName = 'Roeland'
            // ", parsedStmnt.ParsedNode.NodeText.ToString());
        }
        */
    }
}
