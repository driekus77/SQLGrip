using SQLGrip;
using SQLGrip.Parsers.ANSI.Version92;
using SQLGrip.Parsers.ANSI.Version92.Parselets;
using SQLGrip.SyntaxTree.Nodes;
using Superpower;
using Superpower.Model;
using System;
using System.Linq;
using Xunit;

namespace SQLGripTests.Parsers.ANSI.Version92
{
    public class SqlTokenParsersSelectClauseTests
    {
        SqlTokenizer SqlTokenizer { get; } = new SqlTokenizer();


  
        [Fact]
        public void Keyword_SELECT_Test()
        {
            var tokens = SqlTokenizer.Tokenize("SELECT");
            var result = SqlSelectClauseParselet.SELECT.Parse(tokens);

            Assert.IsType<SqlKeywordNode>(result);
            Assert.Equal("SELECT", result.Keyword.ToStringValue());
        }


        [Fact]
        public void Identifier_SCHEMA_NAME_Test()
        {
            var tokens = SqlTokenizer.Tokenize("myschema");
            var result = SqlSelectClauseParselet.SCHEMA_NAME.Parse(tokens);

            Assert.IsType<SqlIdentifierNode>(result);

            Assert.Equal("myschema", result.ToString());
        }

        [Fact]
        public void ColumnExpression_COLUMN_NAME_Tests()
        {
            var tokens = SqlTokenizer.Tokenize("firstCol");
            var result = SqlSelectClauseParselet.COLUMN_EXPRESSION.Parse(tokens);

            Assert.IsType<SqlColumnExpressionNode>(result);

            Assert.Equal("firstCol", result.ColumnName.Identifier.ToStringValue());
        }

        [Fact]
        public void ColumnExpression__TABLE_OR_ALIAS_NAME__COLUMN_NAME_Tests()
        {
            var tokens = SqlTokenizer.Tokenize("mytable1.firstCol1");
            var result = SqlSelectClauseParselet.COLUMN_EXPRESSION.Parse(tokens);

            Assert.IsType<SqlColumnExpressionNode>(result);

            Assert.Equal("mytable1", result.TableOrAliasName.ToString());
            Assert.Equal("firstCol1", result.ColumnName.ToString());
        }

        [Fact]
        public void ColumnExpression__SCHEMA_NAME__TABLE_OR_ALIAS_NAME__COLUMN_NAME_Tests()
        {
            var tokens = SqlTokenizer.Tokenize("myschema1.mytable1.firstCol1");
            var result = SqlSelectClauseParselet.COLUMN_EXPRESSION.Parse(tokens);

            Assert.IsType<SqlColumnExpressionNode>(result);

            Assert.Equal("myschema1", result.SchemaName.ToString());
            Assert.Equal("mytable1", result.TableOrAliasName.ToString());
            Assert.Equal("firstCol1", result.ColumnName.ToString());
        }

        [Fact]
        public void ColumnExpression__SCHEMA_NAME__TABLE_OR_ALIAS_NAME__COLUMN_NAME__WITH_ALIAS_Tests()
        {
            var tokens = SqlTokenizer.Tokenize("myschema1.mytable1.firstCol1\tfc1");
            var result = SqlSelectClauseParselet.COLUMN_EXPRESSION.Parse(tokens);

            Assert.IsType<SqlColumnExpressionNode>(result);

            Assert.Equal("myschema1", result.SchemaName.ToString());
            Assert.Equal("mytable1", result.TableOrAliasName.ToString());
            Assert.Equal("firstCol1", result.ColumnName.ToString());

            Assert.Equal("\t", result.Whitespace1.ToStringValue());
            Assert.Equal("fc1", result.ColumnAlias.ToString());
        }



        [Fact]
        public void ColumnExpressionList__COLUMN_NAMES_Tests()
        {
            var input_text = @"FirstName   , 
                               LastName    , 
                               BirthDate   , 
                               PhoneNumber ";
            var tokens = SqlTokenizer.Tokenize(input_text);
            var result = SqlSelectClauseParselet.COLUMN_EXPRESSION_LIST.Parse(tokens);

            Assert.IsType<SqlColumnExpressionListNode>(result);

            Assert.Null(result[0].SchemaName);
            Assert.Null(result[0].TableOrAliasName);
            Assert.Equal("FirstName", result[0].ColumnName.Identifier.ToStringValue());

            Assert.Null(result[1].SchemaName);
            Assert.Null(result[1].TableOrAliasName);
            Assert.Equal("LastName", result[1].ColumnName.Identifier.ToStringValue());

            Assert.Null(result[2].SchemaName);
            Assert.Null(result[2].TableOrAliasName);
            Assert.Equal("BirthDate", result[2].ColumnName.Identifier.ToStringValue());

            Assert.Null(result[3].SchemaName);
            Assert.Null(result[3].TableOrAliasName);
            Assert.Equal("PhoneNumber", result[3].ColumnName.Identifier.ToStringValue());

            var resultText = result.ToString();
            Assert.Equal(input_text, resultText );
        }

    }
}
