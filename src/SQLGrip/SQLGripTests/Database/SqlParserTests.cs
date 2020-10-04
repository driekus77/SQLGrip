using SQLGrip.Database;
using SQLGrip.Tree.Nodes;
using SQLGrip.Tree.Nodes.Statements;
using SQLGrip.Tree.Extensions;
using System;
using System.Linq;
using Xunit;

namespace SQLGripTests.Database
{
    public class SqlParserTests
    {
        SqlParser Parser { get; } = new SqlParser();


        [Fact]
        public void SimpleTest()
        {
            var stmnt = Parser.Parse("select hello AS h, by As b, seeya as s from greetings g, people p");
            Assert.NotNull(stmnt);

            var nodes = stmnt.FirstOrDefault(x => x.IsNodeType<ISqlColumnExpressionListNode>(), true);
            Assert.NotNull(nodes);
            Assert.NotEmpty(nodes.Children);
            Assert.Equal(7, nodes.Children.Count);

            var expressions = nodes.Where(n => n.IsNodeType<ISqlColumnExpressionNode>()).ToList();
            Assert.NotNull(expressions);
            Assert.NotEmpty(expressions);
            Assert.Equal(3, expressions.Count);

            foreach ( var expr in expressions)
            {
                _ = Assert.IsAssignableFrom<ISqlExpressionNode>(expr);
            }

        }


    }
}
