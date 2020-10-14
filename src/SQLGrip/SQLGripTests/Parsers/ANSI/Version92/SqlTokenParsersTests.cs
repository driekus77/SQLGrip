using SQLGrip;
using SQLGrip.Parsers.ANSI.Version92;
using SQLGrip.Parsers.ANSI.Version92.Parselets;
using SQLGrip.SyntaxTree.Nodes;
using SQLGrip.SyntaxTree.Extensions;
using Superpower;
using Superpower.Model;
using System;
using System.Linq;
using Xunit;

namespace SQLGripTests.Parsers.ANSI.Version92
{
    public class SqlTokenParsersTests
    {
        SqlTokenizer SqlTokenizer { get; } = new SqlTokenizer();


        [Fact]
        public void WSTest()
        {
            var tokens = SqlTokenizer.Tokenize(" \t\n\r");
            var result = SqlGeneralParselet.WHITESPACE.Parse(tokens);

            Assert.IsType<SqlWhitespaceNode>(result);
            Assert.Equal(" \t\n\r", result.Span.ToStringValue());
        }


        [Fact]
        public void OperatorPlusTest()
        {
            var tokens = SqlTokenizer.Tokenize("+");
            var result = SqlOperatorParselet.PLUS.Parse(tokens);
            Assert.IsType<SqlOperatorNode>(result);
            Assert.Equal("+", result.Operator.ToStringValue());
        }

        [Fact]
        public void OperatorNotEqualTest()
        {
            var tokens = SqlTokenizer.Tokenize("<>");
            var result = SqlOperatorParselet.NOT_EQUAL.Parse(tokens);
            Assert.IsType<SqlOperatorNode>(result);
            Assert.Equal("<>", result.Operator.ToStringValue());
        }


        [Fact]
        public void OperatorLessThanTest()
        {
            var tokens = SqlTokenizer.Tokenize("<");
            var result = SqlOperatorParselet.LESS_THAN.Parse(tokens);
            Assert.IsType<SqlOperatorNode>(result);
            Assert.Equal("<", result.Operator.ToStringValue());
        }




        [Fact]
        public void Keyword_AND_Test()
        {
            var tokens = SqlTokenizer.Tokenize("And");
            var result = SqlKeywordParselet.AND.Parse(tokens);
            Assert.IsType<SqlKeywordNode>(result);
            Assert.Equal("And", result.Keyword.ToStringValue());
        }

        [Fact]
        public void Keyword_OR_Test()
        {
            var tokens = SqlTokenizer.Tokenize("or");
            var result = SqlKeywordParselet.OR.Parse(tokens);
            Assert.IsType<SqlKeywordNode>(result);
            Assert.Equal("or", result.Keyword.ToStringValue());
        }

        [Fact]
        public void Keyword_SELECT_Test()
        {
            var tokens = SqlTokenizer.Tokenize("select");
            var result = SqlSelectClauseParselet.SELECT.Parse(tokens);
            Assert.IsType<SqlKeywordNode>(result);
            Assert.Equal("select", result.Keyword.ToStringValue());
        }

        /*
            tokens = SqlTokenizer.Tokenize("From");
            result = SqlFromClauseParselet.FROM.Parse(tokens);
            Assert.IsType<SqlKeywordNode>(result);
            Assert.Equal("From", result.CapturedToken.ToStringValue());

            tokens = SqlTokenizer.Tokenize("WHERE");
            result = SqlWhereClauseParselet.WHERE.Parse(tokens);
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

            var selectStatement = Assert.IsAssignableFrom<SqlSelectStatementNode>(result.Value);
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

            var selectStatement = Assert.IsAssignableFrom<SqlSelectStatementNode>(result.Value);

            var firstClause = selectStatement.FirstOrDefault(n => n.IsNodeType<SqlSelectClauseNode>());
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

            var selectStatement = Assert.IsAssignableFrom<SqlSelectStatementNode>(result.Value);

            var node = selectStatement.FirstOrDefault(x => x.IsNodeType<SqlOperatorNode>(), true);
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

            var selectStatement = Assert.IsAssignableFrom<SqlSelectStatementNode>(result.Value);

            var firstCol = selectStatement.SelectClause.FirstOrDefault(x => !x.IsNodeType<SqlSpecialCharactersNode>());
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

            var selectStatement = Assert.IsAssignableFrom<SqlSelectStatementNode>(result.Value);

            var first = selectStatement.FromClause.FirstOrDefault(x => !x.IsNodeType<SqlKeywordNode>(), true);
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

            var selectStatement = Assert.IsAssignableFrom<SqlSelectStatementNode>(result.Value);

            var nodes = selectStatement.SelectClause.Where(x => x.IsNodeType<SqlWhitespaceNode>()).ToList();
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

            var selectStatement = Assert.IsAssignableFrom<SqlSelectStatementNode>(result.Value);

            var nodes = selectStatement.Where(x => x.IsNodeType<SqlWhitespaceNode>(), true);
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

            var selectStatement = Assert.IsAssignableFrom<SqlSelectStatementNode>(result.Value);

            var nodes = selectStatement.SelectClause.Where(x => !x.IsNodeType<SqlWhitespaceNode>());
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

            var selectStatement = Assert.IsAssignableFrom<SqlSelectStatementNode>(result.Value);

            var nodes = selectStatement.SelectClause.Where(x => !x.IsNodeType<SqlWhitespaceNode>(), true).ToList();
            Assert.NotNull(nodes);
            Assert.Equal(10, nodes.Count);

        }

        */
    }
}
