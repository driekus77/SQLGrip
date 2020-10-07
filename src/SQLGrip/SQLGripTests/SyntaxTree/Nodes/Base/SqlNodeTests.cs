using SQLGrip;
using SQLGrip.ParserTree;
using SQLGrip.SyntaxTree.Nodes;
using SQLGrip.SyntaxTree.Extensions;
using System;
using Xunit;

namespace SQLGripTests.SyntaxTree.Nodes.Base
{
    public class SqlStatementNodeTests
    {
        SqlParser Parser { get; } = new SqlParser();

        [Fact]
        public void NodeTextTests()
        {
            SqlStatementNode stmnt = Parser.Parse("select hello AS h, by As b, seeya as s from greetings g, people p");
            Assert.NotNull(stmnt);

            SqlNode nodes = stmnt.FirstOrDefault(x => x.IsNodeType<SqlColumnExpressionListNode>(), true);
            //Assert.Equal("hello AS h, by As b, seeya as s ", nodes.NodeText.ToStringValue());

            SqlNode node = nodes.FirstOrDefault(x => x.IsNodeType<SqlColumnExpressionNode>(), true);
            //Assert.Equal("hello AS h", node.NodeText.ToStringValue());
        }


    }
}
