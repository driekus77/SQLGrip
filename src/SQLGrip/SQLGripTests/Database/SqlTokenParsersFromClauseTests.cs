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
    public class SqlTokenParsersFromClauseTests
    {
        SqlTokenizer SqlTokenizer { get; } = new SqlTokenizer();

        SqlTokenParsers SqlTokenParsers { get; } = new SqlTokenParsers();


  
        [Fact]
        public void SimpleTableTest()
        {
            var tokens = SqlTokenizer.Tokenize("FROM PERSON");
            var result = SqlTokenParsers.FromClause.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            var resultClause = Assert.IsType<SqlFromClauseNode>(result.Value);
            Assert.Equal(3, resultClause.Children.Count);
            Assert.True(resultClause.Children.All(x => x.Parent.Equals(resultClause)));
            Assert.Equal("FROM", resultClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", resultClause.Children[1].CapturedToken.ToStringValue());

            var tableExprList = Assert.IsType<SqlTableExpressionListNode>(resultClause.Children[2]);
            var tableExpr = Assert.IsType<SqlTableExpressionNode>(tableExprList.Children[0]);
            Assert.Equal("PERSON", tableExpr.Children[0].CapturedToken.ToStringValue());
        }

        [Fact]
        public void SimpleTableAliasTest()
        {
            var tokens = SqlTokenizer.Tokenize("FROM PERSON p");
            var result = SqlTokenParsers.FromClause.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            var resultClause = Assert.IsType<SqlFromClauseNode>(result.Value);
            Assert.Equal(3, resultClause.Children.Count);
            Assert.True(resultClause.Children.All(x => x.Parent.Equals(resultClause)));
            Assert.Equal("FROM", resultClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", resultClause.Children[1].CapturedToken.ToStringValue());

            var tableExprList = Assert.IsType<SqlTableExpressionListNode>(resultClause.Children[2]);
            var tableExpr = Assert.IsType<SqlTableExpressionNode>(tableExprList.Children[0]);
            Assert.Equal("PERSON", tableExpr.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", tableExpr.Children[1].CapturedToken.ToStringValue());
            Assert.Equal("p", tableExpr.Children[2].CapturedToken.ToStringValue());


            tokens = SqlTokenizer.Tokenize("FROM PERSON AS p");
            result = SqlTokenParsers.FromClause.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            resultClause = Assert.IsType<SqlFromClauseNode>(result.Value);
            Assert.Equal(3, resultClause.Children.Count);
            Assert.True(resultClause.Children.All(x => x.Parent.Equals(resultClause)));
            Assert.Equal("FROM", resultClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", resultClause.Children[1].CapturedToken.ToStringValue());

            tableExprList = Assert.IsType<SqlTableExpressionListNode>(resultClause.Children[2]);
            tableExpr = Assert.IsType<SqlTableExpressionNode>(tableExprList.Children[0]);
            Assert.Equal("PERSON", tableExpr.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", tableExpr.Children[1].CapturedToken.ToStringValue());
            Assert.Equal("AS", tableExpr.Children[2].CapturedToken.ToStringValue());
            Assert.Equal(" ", tableExpr.Children[3].CapturedToken.ToStringValue());
            Assert.Equal("p", tableExpr.Children[4].CapturedToken.ToStringValue());
        }


        [Fact]
        public void TwoTableTest()
        {
            var tokens = SqlTokenizer.Tokenize("FROM PERSON, EMPLOYEE");
            var result = SqlTokenParsers.FromClause.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            var resultClause = Assert.IsType<SqlFromClauseNode>(result.Value);
            Assert.Equal(3, resultClause.Children.Count);
            Assert.True(resultClause.Children.All(x => x.Parent.Equals(resultClause)));
            Assert.Equal("FROM", resultClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", resultClause.Children[1].CapturedToken.ToStringValue());

            var tableExprList = Assert.IsType<SqlTableExpressionListNode>(resultClause.Children[2]);
            Assert.Equal(4, tableExprList.Children.Count);

            var tableExpr1 = Assert.IsType<SqlTableExpressionNode>(tableExprList.Children[0]);
            Assert.Equal("PERSON", tableExpr1.Children[0].CapturedToken.ToStringValue());

            var tableExpr2 = Assert.IsType<SqlTableExpressionNode>(tableExprList.Children[3]);
            Assert.Equal("EMPLOYEE", tableExpr2.Children[0].CapturedToken.ToStringValue());
        }


        [Fact]
        public void TwoTableAliasTest()
        {
            var tokens = SqlTokenizer.Tokenize("FROM PERSON p, EMPLOYEE e");
            var result = SqlTokenParsers.FromClause.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            var resultClause = Assert.IsType<SqlFromClauseNode>(result.Value);
            Assert.Equal(3, resultClause.Children.Count);
            Assert.True(resultClause.Children.All(x => x.Parent.Equals(resultClause)));
            Assert.Equal("FROM", resultClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", resultClause.Children[1].CapturedToken.ToStringValue());

            var tableExprList = Assert.IsType<SqlTableExpressionListNode>(resultClause.Children[2]);
            Assert.Equal(4, tableExprList.Children.Count);

            var tableExpr1 = Assert.IsType<SqlTableExpressionNode>(tableExprList.Children[0]);
            Assert.Equal("PERSON", tableExpr1.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", tableExpr1.Children[1].CapturedToken.ToStringValue());
            Assert.Equal("p", tableExpr1.Children[2].CapturedToken.ToStringValue());

            var tableExpr2 = Assert.IsType<SqlTableExpressionNode>(tableExprList.Children[3]);
            Assert.Equal("EMPLOYEE", tableExpr2.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", tableExpr2.Children[1].CapturedToken.ToStringValue());
            Assert.Equal("e", tableExpr2.Children[2].CapturedToken.ToStringValue());
        }



    }
}
