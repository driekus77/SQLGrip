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
            Assert.Equal("SELECT", result.Span.ToStringValue());
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

            Assert.Equal("firstCol", result.ColumnName.Span.ToStringValue());
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
            var tokens = SqlTokenizer.Tokenize("myschema1.mytable1.firstCol1 \t fc1");
            var result = SqlSelectClauseParselet.COLUMN_EXPRESSION.Parse(tokens);

            Assert.IsType<SqlColumnExpressionNode>(result);

            Assert.Equal("myschema1", result.SchemaName.ToString());
            Assert.Equal("mytable1", result.TableOrAliasName.ToString());
            Assert.Equal("firstCol1", result.ColumnName.ToString());

            Assert.Equal(" \t ", result.Whitespace2.ToStringValue());
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
            Assert.Equal("FirstName", result[0].ColumnName.Span.ToStringValue());

            Assert.Null(result[1].SchemaName);
            Assert.Null(result[1].TableOrAliasName);
            Assert.Equal("LastName", result[1].ColumnName.Span.ToStringValue());

            Assert.Null(result[2].SchemaName);
            Assert.Null(result[2].TableOrAliasName);
            Assert.Equal("BirthDate", result[2].ColumnName.Span.ToStringValue());

            Assert.Null(result[3].SchemaName);
            Assert.Null(result[3].TableOrAliasName);
            Assert.Equal("PhoneNumber", result[3].ColumnName.Span.ToStringValue());

            var resultText = result.ToString();
            Assert.Equal(input_text, resultText );
        }


        [Fact]
        public void ColumnExpressionList__MIXED_PREFIXES__COLUMN_NAMES_Tests()
        {
            var input_text = @"t1.FirstName   , 
                               t1.LastName    , 
                               BirthDate   , 
                               mySchema.Person.PhoneNumber ";
            var tokens = SqlTokenizer.Tokenize(input_text);
            var result = SqlSelectClauseParselet.COLUMN_EXPRESSION_LIST.Parse(tokens);

            Assert.IsType<SqlColumnExpressionListNode>(result);

            Assert.Null(result[0].SchemaName);
            Assert.Equal("t1", result[0].TableOrAliasName.Span.ToStringValue());
            Assert.Equal("FirstName", result[0].ColumnName.Span.ToStringValue());

            Assert.Null(result[1].SchemaName);
            Assert.Equal("t1", result[1].TableOrAliasName.Span.ToStringValue());
            Assert.Equal("LastName", result[1].ColumnName.Span.ToStringValue());

            Assert.Null(result[2].SchemaName);
            Assert.Null(result[2].TableOrAliasName);
            Assert.Equal("BirthDate", result[2].ColumnName.Span.ToStringValue());

            Assert.Equal("mySchema", result[3].SchemaName.Span.ToStringValue());
            Assert.Equal("Person", result[3].TableOrAliasName.Span.ToStringValue());
            Assert.Equal("PhoneNumber", result[3].ColumnName.Span.ToStringValue());

            var resultText = result.ToString();
            Assert.Equal(input_text, resultText );
        }


        [Fact]
        public void SelectClause__SELECT_CLAUSE__Tests() 
        {
            var input_text = @"Select  t1.LastName
                ,       t1.FirstName 
                ,       t2.PhoneNumber  
                ,       t3.EmailHome 
            ";

            var tokens = SqlTokenizer.Tokenize(input_text);
            var result = SqlSelectClauseParselet.SELECT_CLAUSE.Parse(tokens);

            Assert.IsType<SqlSelectClauseNode>(result);

            Assert.Equal(4, result.SelectList.Count);
        }
    }
}
