using SQLGrip.ParserTree;
using SQLGrip.SyntaxTree.Nodes;
using SQLGrip.SyntaxTree.Extensions;
using System;
using System.Linq;
using Xunit;

namespace SQLGripTests.ParserTree
{
    public class SqlParserTests
    {
        SqlParser Parser { get; } = new SqlParser();


        [Fact]
        public void SimpleTest()
        {
            var stmnt = Parser.Parse("select hello AS h, by As b, seeya as s from greetings g, people p");
            Assert.NotNull(stmnt);

            var nodes = stmnt.FirstOrDefault(x => x.IsNodeType<SqlColumnExpressionListNode>(), true);
            Assert.NotNull(nodes);
            Assert.NotEmpty(nodes.Children);
            Assert.Equal(7, nodes.Children.Count);

            var expressions = nodes.Where(n => n.IsNodeType<SqlColumnExpressionNode>()).ToList();
            Assert.NotNull(expressions);
            Assert.NotEmpty(expressions);
            Assert.Equal(3, expressions.Count);

            foreach ( var expr in expressions)
            {
                _ = Assert.IsAssignableFrom<SqlNode>(expr);
            }

        }


    }
}
