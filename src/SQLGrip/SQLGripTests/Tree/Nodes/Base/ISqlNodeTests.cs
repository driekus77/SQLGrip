using SQLGrip.Core;
using SQLGrip.Database;
using SQLGrip.Tree.Nodes;
using SQLGrip.Tree.Nodes.Statements;
using SQLGrip.Tree.Extensions;
using System;
using Xunit;

namespace SQLGripTests.Tree.Nodes.Base
{
    public class SqlStatementNodeTests
    {
        SqlParser Parser { get; } = new SqlParser();

        [Fact]
        public void NodeTextTests()
        {
            ISqlStatementNode stmnt = Parser.Parse("select hello AS h, by As b, seeya as s from greetings g, people p");
            Assert.NotNull(stmnt);

            ISqlNode nodes = stmnt.FirstOrDefault(x => x.IsNodeType<ISqlColumnExpressionListNode>(), true);
            //Assert.Equal("hello AS h, by As b, seeya as s ", nodes.NodeText.ToStringValue());

            ISqlNode node = nodes.FirstOrDefault(x => x.IsNodeType<ISqlColumnExpressionNode>(), true);
            //Assert.Equal("hello AS h", node.NodeText.ToStringValue());
        }


    }
}
