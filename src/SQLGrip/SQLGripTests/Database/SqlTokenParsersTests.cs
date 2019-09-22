using SQLGrip.Core;
using SQLGrip.Database;
using SQLGrip.Tree.Nodes;
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
        public void FindFirstByTypeTests()
        {
            var tokens = SqlTokenizer.Tokenize("Select \t * From Person");

            var result = SqlTokenParsers.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectStatementNode>(result.Value);

            var selectStatement = Assert.IsAssignableFrom<ISqlSelectStatementNode>(result.Value);

            var firstClause = selectStatement.FindFirstByType<ISqlClauseNode>();
            Assert.NotNull(firstClause);
            Assert.Equal("SELECT-CLAUSE", firstClause.Name);
            Assert.Equal("Select", firstClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" \t ", firstClause.Children[1].CapturedToken.ToStringValue());
            Assert.Equal("*", firstClause.Children[2].CapturedToken.ToStringValue());
        }


        [Fact]
        public void FindFirstByTypeDeepTests()
        {
            var tokens = SqlTokenizer.Tokenize("Select \t * From Person");

            var result = SqlTokenParsers.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectStatementNode>(result.Value);

            var selectStatement = Assert.IsAssignableFrom<ISqlSelectStatementNode>(result.Value);

            var node = selectStatement.FindFirstByType<ISqlOperatorNode>(true);
            Assert.NotNull(node);
            Assert.Equal("*", node.CapturedToken.ToStringValue());
        }



        [Fact]
        public void FindFirstNotByTypeTests()
        {
            var tokens = SqlTokenizer.Tokenize("Select \t FirstName, LastName, Age From Person");

            var result = SqlTokenParsers.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectStatementNode>(result.Value);

            var selectStatement = Assert.IsAssignableFrom<ISqlSelectStatementNode>(result.Value);

            var firstCol = selectStatement.SelectClause.FindFirstNotByType<ISqlWhitespaceNode>();
            Assert.NotNull(firstCol);
        }


        [Fact]
        public void FindAllByTypeTests()
        {
            var tokens = SqlTokenizer.Tokenize("Select \t * From Person");

            var result = SqlTokenParsers.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectStatementNode>(result.Value);

            var selectStatement = Assert.IsAssignableFrom<ISqlSelectStatementNode>(result.Value);

            var clauses = selectStatement.FindAllByType<ISqlClauseNode>();
            Assert.NotNull(clauses);
            Assert.Equal(2, clauses.Count());
            Assert.Equal("SELECT-CLAUSE", clauses.ElementAt(0).Name);
            Assert.Equal("FROM-CLAUSE", clauses.ElementAt(1).Name);
        }

        [Fact]
        public void FindAllNotByTypeTests()
        {
            var tokens = SqlTokenizer.Tokenize("Select \t FirstName, LastName, Age From Person");

            var result = SqlTokenParsers.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectStatementNode>(result.Value);

            var selectStatement = Assert.IsAssignableFrom<ISqlSelectStatementNode>(result.Value);

            var nodes = selectStatement.SelectClause.FindFirstByType<ISqlExpressionListNode>().FindAllNotByType<ISqlWhitespaceNode>();
            Assert.NotNull(nodes);
            Assert.Equal(5, nodes.Count());

        }
    }
}
