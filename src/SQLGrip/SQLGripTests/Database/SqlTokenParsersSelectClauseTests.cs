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
    public class SqlTokenParsersSelectClauseTests
    {
        SqlTokenizer SqlTokenizer { get; } = new SqlTokenizer();

        SqlTokenParsers SqlTokenParsers { get; } = new SqlTokenParsers();


  
        [Fact]
        public void AsteriksTest()
        {
            var tokens = SqlTokenizer.Tokenize("SELECT *");
            var result = SqlTokenParsers.SelectClause.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectClauseNode>(result.Value);
            var resultClause = (SqlSelectClauseNode)result.Value;
            Assert.Equal(3, resultClause.Children.Count);
            Assert.True(resultClause.Children.All(x => x.Parent.Equals(resultClause)));
            Assert.Equal("SELECT", resultClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", resultClause.Children[1].CapturedToken.ToStringValue());
            Assert.Equal("*", resultClause.Children[2].CapturedToken.ToStringValue());
        }

        [Fact]
        public void SingleColumnTest()
        {
            var tokens = SqlTokenizer.Tokenize("SELECT FirstName");
            var result = SqlTokenParsers.SelectClause.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectClauseNode>(result.Value);
            var resultClause = (SqlSelectClauseNode)result.Value;
            Assert.Equal(3, resultClause.Children.Count);
            Assert.True(resultClause.Children.All(x => x.Parent.Equals(resultClause)));
            Assert.Equal("SELECT", resultClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", resultClause.Children[1].CapturedToken.ToStringValue());

            Assert.IsType<SqlColumnExpressionListNode>(resultClause.Children[2]);
            var listNode = (SqlColumnExpressionListNode)resultClause.Children[2];
            Assert.Equal(1, listNode.Children.Count);

            var columnName = Assert.IsType<SqlIdentifierNode>(listNode.Children[0].Children[0]);
            Assert.Equal("FirstName", columnName.CapturedToken.ToStringValue());
            Assert.Equal("SELECT-COLUMN-NAME", columnName.Name);
        }


        [Fact]
        public void SingleColumnAliasTest()
        {
            var tokens = SqlTokenizer.Tokenize("SELECT FirstName fn");
            var result = SqlTokenParsers.SelectClause.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectClauseNode>(result.Value);
            var resultClause = (SqlSelectClauseNode)result.Value;
            Assert.Equal(3, resultClause.Children.Count);
            Assert.True(resultClause.Children.All(x => x.Parent.Equals(resultClause)));
            Assert.Equal("SELECT", resultClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", resultClause.Children[1].CapturedToken.ToStringValue());

            Assert.IsType<SqlColumnExpressionListNode>(resultClause.Children[2]);
            var listNode = (SqlColumnExpressionListNode)resultClause.Children[2];
            Assert.Equal(1, listNode.Children.Count);

            var column = Assert.IsType<SqlColumnExpressionNode>(listNode.Children[0]);

            var columnName = Assert.IsType<SqlIdentifierNode>(column.Children[0]);
            Assert.Equal("FirstName", columnName.CapturedToken.ToStringValue());
            Assert.Equal("SELECT-COLUMN-NAME", columnName.Name);

            var columnAlias = Assert.IsType<SqlIdentifierNode>(column.Children[2]);
            Assert.Equal("fn", columnAlias.CapturedToken.ToStringValue());
            Assert.Equal("SELECT-COLUMN-ALIAS", columnAlias.Name);
        }



        [Fact]
        public void SingleColumnWithTableAliasTest()
        {
            var tokens = SqlTokenizer.Tokenize("SELECT tblA.FirstName");
            var result = SqlTokenParsers.SelectClause.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectClauseNode>(result.Value);
            var resultClause = (SqlSelectClauseNode)result.Value;
            Assert.Equal(3, resultClause.Children.Count);
            Assert.True(resultClause.Children.All(x => x.Parent.Equals(resultClause)));
            Assert.Equal("SELECT", resultClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", resultClause.Children[1].CapturedToken.ToStringValue());

            Assert.IsType<SqlColumnExpressionListNode>(resultClause.Children[2]);
            var listNode = (SqlColumnExpressionListNode)resultClause.Children[2];
            Assert.Equal(1, listNode.Children.Count);

            var tableAlias = Assert.IsType<SqlIdentifierNode>(listNode.Children[0].Children[0]);
            Assert.Equal("tblA", tableAlias.CapturedToken.ToStringValue());
            Assert.Equal("SELECT-TABLE-REF", tableAlias.Name);

            var columnName = Assert.IsType<SqlIdentifierNode>(listNode.Children[0].Children[2]);
            Assert.Equal("FirstName", columnName.CapturedToken.ToStringValue());
            Assert.Equal("SELECT-COLUMN-NAME", columnName.Name);
        }


        [Fact]
        public void SingleColumnWithSchemaTest()
        {
            var tokens = SqlTokenizer.Tokenize("SELECT MyAccount.Users.FirstName");
            var result = SqlTokenParsers.SelectClause.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectClauseNode>(result.Value);
            var resultClause = (SqlSelectClauseNode)result.Value;
            Assert.Equal(3, resultClause.Children.Count);
            Assert.True(resultClause.Children.All(x => x.Parent.Equals(resultClause)));
            Assert.Equal("SELECT", resultClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", resultClause.Children[1].CapturedToken.ToStringValue());

            Assert.IsType<SqlColumnExpressionListNode>(resultClause.Children[2]);
            var listNode = (SqlColumnExpressionListNode)resultClause.Children[2];
            Assert.Equal(1, listNode.Children.Count);

            var schemaName = Assert.IsType<SqlIdentifierNode>(listNode.Children[0].Children[0]);
            Assert.Equal("MyAccount", schemaName.CapturedToken.ToStringValue());
            Assert.Equal("SELECT-SCHEMA-NAME", schemaName.Name);

            var tableAlias = Assert.IsType<SqlIdentifierNode>(listNode.Children[0].Children[2]);
            Assert.Equal("Users", tableAlias.CapturedToken.ToStringValue());
            Assert.Equal("SELECT-TABLE-REF", tableAlias.Name);

            var columnName = Assert.IsType<SqlIdentifierNode>(listNode.Children[0].Children[4]);
            Assert.Equal("FirstName", columnName.CapturedToken.ToStringValue());
            Assert.Equal("SELECT-COLUMN-NAME", columnName.Name);
        }


        [Fact]
        public void ColumnListTest()
        {
            var tokens = SqlTokenizer.Tokenize("SELECT FirstName, LastName, Age");
            var result = SqlTokenParsers.SelectClause.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectClauseNode>(result.Value);
            var resultClause = (SqlSelectClauseNode)result.Value;
            Assert.Equal(3, resultClause.Children.Count);
            Assert.True(resultClause.Children.All(x => x.Parent.Equals(resultClause)));
            Assert.Equal("SELECT", resultClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", resultClause.Children[1].CapturedToken.ToStringValue());

            Assert.IsType<SqlColumnExpressionListNode>(resultClause.Children[2]);
            var listNode = (SqlColumnExpressionListNode)resultClause.Children[2];
            Assert.Equal(7, listNode.Children.Count);
            Assert.Equal("FirstName", listNode.Children[0].Children[0].CapturedToken.ToStringValue());
            Assert.Equal(",", listNode.Children[1].CapturedToken.ToStringValue());
            Assert.Equal(" ", listNode.Children[2].CapturedToken.ToStringValue());
            Assert.Equal("LastName", listNode.Children[3].Children[0].CapturedToken.ToStringValue());
            Assert.Equal(",", listNode.Children[4].CapturedToken.ToStringValue());
            Assert.Equal(" ", listNode.Children[5].CapturedToken.ToStringValue());
            Assert.Equal("Age", listNode.Children[6].Children[0].CapturedToken.ToStringValue());
        }


        [Fact]
        public void ColumnAliasListTest()
        {
            var tokens = SqlTokenizer.Tokenize("SELECT FirstName fn, LastName ln, Age a");
            var result = SqlTokenParsers.SelectClause.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectClauseNode>(result.Value);
            var resultClause = (SqlSelectClauseNode)result.Value;
            Assert.Equal(3, resultClause.Children.Count);
            Assert.True(resultClause.Children.All(x => x.Parent.Equals(resultClause)));
            Assert.Equal("SELECT", resultClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", resultClause.Children[1].CapturedToken.ToStringValue());

            Assert.IsType<SqlColumnExpressionListNode>(resultClause.Children[2]);
            var listNode = (SqlColumnExpressionListNode)resultClause.Children[2];
            Assert.Equal(7, listNode.Children.Count);

            var firstColExpr = Assert.IsType<SqlColumnExpressionNode>(listNode.Children[0]);
            Assert.Equal("FirstName", firstColExpr.Children[0].CapturedToken.ToStringValue());
            Assert.Equal("fn", firstColExpr.Children[2].CapturedToken.ToStringValue());
            Assert.Equal("SELECT-COLUMN-ALIAS", firstColExpr.Children[2].Name);

            var secondColExpr = Assert.IsType<SqlColumnExpressionNode>(listNode.Children[3]);
            Assert.Equal("LastName", secondColExpr.Children[0].CapturedToken.ToStringValue());
            Assert.Equal("ln", secondColExpr.Children[2].CapturedToken.ToStringValue());
            Assert.Equal("SELECT-COLUMN-ALIAS", secondColExpr.Children[2].Name);

            var thirdColExpr = Assert.IsType<SqlColumnExpressionNode>(listNode.Children[6]);
            Assert.Equal("Age", thirdColExpr.Children[0].CapturedToken.ToStringValue());
            Assert.Equal("a", thirdColExpr.Children[2].CapturedToken.ToStringValue());
            Assert.Equal("SELECT-COLUMN-ALIAS", thirdColExpr.Children[2].Name);



            tokens = SqlTokenizer.Tokenize("SELECT FirstName as fn, LastName as ln, Age as a");
            result = SqlTokenParsers.SelectClause.TryParse(tokens);

            Assert.True(result.HasValue);
            Assert.True(result.ErrorPosition.Equals(Position.Empty));
            Assert.IsType<SqlSelectClauseNode>(result.Value);
            resultClause = (SqlSelectClauseNode)result.Value;
            Assert.Equal(3, resultClause.Children.Count);
            Assert.True(resultClause.Children.All(x => x.Parent.Equals(resultClause)));
            Assert.Equal("SELECT", resultClause.Children[0].CapturedToken.ToStringValue());
            Assert.Equal(" ", resultClause.Children[1].CapturedToken.ToStringValue());

            Assert.IsType<SqlColumnExpressionListNode>(resultClause.Children[2]);
            listNode = (SqlColumnExpressionListNode)resultClause.Children[2];
            Assert.Equal(7, listNode.Children.Count);

            firstColExpr = Assert.IsType<SqlColumnExpressionNode>(listNode.Children[0]);
            Assert.Equal("FirstName", firstColExpr.Children[0].CapturedToken.ToStringValue());
            Assert.Equal("as", firstColExpr.Children[2].CapturedToken.ToStringValue());
            Assert.Equal("fn", firstColExpr.Children[4].CapturedToken.ToStringValue());
            Assert.Equal("SELECT-COLUMN-ALIAS", firstColExpr.Children[4].Name);

            secondColExpr = Assert.IsType<SqlColumnExpressionNode>(listNode.Children[3]);
            Assert.Equal("LastName", secondColExpr.Children[0].CapturedToken.ToStringValue());
            Assert.Equal("as", secondColExpr.Children[2].CapturedToken.ToStringValue());
            Assert.Equal("ln", secondColExpr.Children[4].CapturedToken.ToStringValue());
            Assert.Equal("SELECT-COLUMN-ALIAS", secondColExpr.Children[4].Name);

            thirdColExpr = Assert.IsType<SqlColumnExpressionNode>(listNode.Children[6]);
            Assert.Equal("Age", thirdColExpr.Children[0].CapturedToken.ToStringValue());
            Assert.Equal("as", thirdColExpr.Children[2].CapturedToken.ToStringValue());
            Assert.Equal("a", thirdColExpr.Children[4].CapturedToken.ToStringValue());
            Assert.Equal("SELECT-COLUMN-ALIAS", thirdColExpr.Children[4].Name);
        }


    }
}
