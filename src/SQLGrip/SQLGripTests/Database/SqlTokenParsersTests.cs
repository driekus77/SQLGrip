using SQLGrip.Core;
using SQLGrip.Database;
using SQLGrip.Tree.Nodes;
using SQLGrip.Tree.Nodes.Statements;
using SQLGrip.Tree.Extensions;
using Superpower;
using Superpower.Model;
using System;
using System.Linq;
using Xunit;

namespace SQLGripTests.Database
{
    public class SqlTokenParsersTests
    {
        SqlTokenizer SqlTokenizer { get; } = new SqlTokenizer();

        SqlTokenParsers SqlTokenParsers { get; } = new SqlTokenParsers();


        [Fact]
        public void WSTest()
        {
            var tokens = SqlTokenizer.Tokenize(" \t\n\r");

            var result = SqlTokenParsers.WS.Parse(tokens);

            Assert.IsType<SqlWhitespaceNode>(result);
            Assert.Equal(" \t\n\r", result.CapturedToken.ToStringValue());
        }

        [Fact]
        public void OperatorsTest()
        {
            var tokens = SqlTokenizer.Tokenize("+");
            var result = SqlTokenParsers.Plus.Parse(tokens);

            Assert.IsType<SqlOperatorNode>(result);
            Assert.Equal("+", result.CapturedToken.ToStringValue());


            tokens = SqlTokenizer.Tokenize("<>");
            result = SqlTokenParsers.Neq.Parse(tokens);

            Assert.IsType<SqlOperatorNode>(result);
            Assert.Equal("<>", result.CapturedToken.ToStringValue());


            tokens = SqlTokenizer.Tokenize("<");
            result = SqlTokenParsers.Lt.Parse(tokens);

            Assert.IsType<SqlOperatorNode>(result);
            Assert.Equal("<", result.CapturedToken.ToStringValue());
        }

        [Fact]
        public void KeywordsTest()
        {
            var tokens = SqlTokenizer.Tokenize("And");
            var result = SqlTokenParsers.And.Parse(tokens);
            Assert.IsType<SqlKeywordNode>(result);
            Assert.Equal("And", result.CapturedToken.ToStringValue());

            tokens = SqlTokenizer.Tokenize("or");
            result = SqlTokenParsers.Or.Parse(tokens);
            Assert.IsType<SqlKeywordNode>(result);
            Assert.Equal("or", result.CapturedToken.ToStringValue());

            tokens = SqlTokenizer.Tokenize("select");
            result = SqlTokenParsers.Select.Parse(tokens);
            Assert.IsType<SqlKeywordNode>(result);
            Assert.Equal("select", result.CapturedToken.ToStringValue());

            tokens = SqlTokenizer.Tokenize("From");
            result = SqlTokenParsers.From.Parse(tokens);
            Assert.IsType<SqlKeywordNode>(result);
            Assert.Equal("From", result.CapturedToken.ToStringValue());

            tokens = SqlTokenizer.Tokenize("WHERE");
            result = SqlTokenParsers.Where.Parse(tokens);
            Assert.IsType<SqlKeywordNode>(result);
            Assert.Equal("WHERE", result.CapturedToken.ToStringValue());
        }


        [Fact]
        public void SimpleSelectTest()
        {
            var tokens = SqlTokenizer.Tokenize("SELECT * FROM PERSON");

            var result = SqlTokenParsers.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectStatementNode>(result.Value);

            var selectStatement = Assert.IsAssignableFrom<ISqlSelectStatementNode>(result.Value);
            Assert.Equal("SELECT", selectStatement.SelectClause.Children[0].CapturedToken.ToStringValue());


        }

        [Fact]
        public void FirstOrDefaultByTypeTests()
        {
            var tokens = SqlTokenizer.Tokenize("Select \t * From Person");

            var result = SqlTokenParsers.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectStatementNode>(result.Value);

            var selectStatement = Assert.IsAssignableFrom<ISqlSelectStatementNode>(result.Value);

            var firstClause = selectStatement.FirstOrDefault(n => n.IsNodeType<ISqlSelectClauseNode>());
            Assert.NotNull(firstClause);
            Assert.Equal("SelectClause", firstClause.Name);
            Assert.Equal("Select", firstClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" \t ", firstClause.Children[1].CapturedToken.ToStringValue());
            Assert.Equal("*", firstClause.Children[2].CapturedToken.ToStringValue());
        }


        [Fact]
        public void FirstOrDefaultByTypeDeepTests()
        {
            var tokens = SqlTokenizer.Tokenize("Select \t * From Person");

            var result = SqlTokenParsers.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectStatementNode>(result.Value);

            var selectStatement = Assert.IsAssignableFrom<ISqlSelectStatementNode>(result.Value);

            var node = selectStatement.FirstOrDefault(x => x.IsNodeType<ISqlOperatorNode>(), true);
            Assert.NotNull(node);
            Assert.Equal("*", node.CapturedToken.ToStringValue());
        }



        [Fact]
        public void FirstOrDefaultNotByTypeTests()
        {
            var tokens = SqlTokenizer.Tokenize("Select \t FirstName, LastName, Age From Person");

            var result = SqlTokenParsers.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectStatementNode>(result.Value);

            var selectStatement = Assert.IsAssignableFrom<ISqlSelectStatementNode>(result.Value);

            var firstCol = selectStatement.SelectClause.FirstOrDefault(x => !x.IsNodeType<ISqlSpecialCharactersNode>());
            Assert.NotNull(firstCol);
        }

        [Fact]
        public void FirstOrDefaultNotByTypeDeepTests()
        {
            var tokens = SqlTokenizer.Tokenize("Select \t FirstName, LastName, Age From Person");

            var result = SqlTokenParsers.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectStatementNode>(result.Value);

            var selectStatement = Assert.IsAssignableFrom<ISqlSelectStatementNode>(result.Value);

            var first = selectStatement.FromClause.FirstOrDefault(x => !x.IsNodeType<ISqlKeywordNode>(), true);
            Assert.NotNull(first);
            Assert.IsType<SqlWhitespaceNode>(first);
        }


        [Fact]
        public void WhereByTypeTests()
        {
            var tokens = SqlTokenizer.Tokenize("Select \t * From Person");

            var result = SqlTokenParsers.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectStatementNode>(result.Value);

            var selectStatement = Assert.IsAssignableFrom<ISqlSelectStatementNode>(result.Value);

            var nodes = selectStatement.SelectClause.Where(x => x.IsNodeType<ISqlWhitespaceNode>()).ToList();
            Assert.NotNull(nodes);
            Assert.Equal(2, nodes.Count);
        }

        [Fact]
        public void WhereByTypeDeepTests()
        {
            var tokens = SqlTokenizer.Tokenize("Select \t * From Person");

            var result = SqlTokenParsers.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectStatementNode>(result.Value);

            var selectStatement = Assert.IsAssignableFrom<ISqlSelectStatementNode>(result.Value);

            var nodes = selectStatement.Where(x => x.IsNodeType<ISqlWhitespaceNode>(), true);
            Assert.NotNull(nodes);
            Assert.Equal(3, nodes.Count());
        }




        [Fact]
        public void WhereNotByTypeTests()
        {
            var tokens = SqlTokenizer.Tokenize("Select \t FirstName, LastName, Age From Person");

            var result = SqlTokenParsers.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectStatementNode>(result.Value);

            var selectStatement = Assert.IsAssignableFrom<ISqlSelectStatementNode>(result.Value);

            var nodes = selectStatement.SelectClause.Where(x => !x.IsNodeType<ISqlWhitespaceNode>());
            Assert.NotNull(nodes);
            Assert.Equal(2, nodes.Count());

        }



        [Fact]
        public void WhereNotByTypeDeepTests()
        {
            var tokens = SqlTokenizer.Tokenize("Select \t FirstName, LastName, Age From Person");

            var result = SqlTokenParsers.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectStatementNode>(result.Value);

            var selectStatement = Assert.IsAssignableFrom<ISqlSelectStatementNode>(result.Value);

            var nodes = selectStatement.SelectClause.Where(x => !x.IsNodeType<ISqlWhitespaceNode>(), true).ToList();
            Assert.NotNull(nodes);
            Assert.Equal(10, nodes.Count);

        }


    }
}
