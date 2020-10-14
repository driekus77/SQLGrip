using SQLGrip.Parsers;
using SQLGrip.SyntaxTree.Nodes;
using SQLGrip.SyntaxTree.Extensions;
using Superpower;
using Superpower.Model;
using Superpower.Parsers;
using System;

namespace SQLGrip.Parsers.ANSI.Version92.Parselets 
{
    using _ = SQLGrip.Parsers.ANSI.Version92.Parselets.SqlGeneralParselet;
    using _op = SQLGrip.Parsers.ANSI.Version92.Parselets.SqlOperatorParselet;
    using _kw = SQLGrip.Parsers.ANSI.Version92.Parselets.SqlKeywordParselet;
    
    public class SqlSelectClauseParselet
    {
        // SelectClause Parsers
        public static readonly TokenListParser<SqlToken, SqlKeywordNode> SELECT =
                Token.EqualTo(SqlToken.SELECT).Select(x => new SqlKeywordNode{ Span = x.Span })
                .Named("select");

            
        public static readonly TokenListParser<SqlToken, SqlIdentifierNode> SCHEMA_NAME =
                Token.EqualTo(SqlToken.IDENTIFIER)
                    .Select(x => new SqlIdentifierNode{ Span = x.Span })
                    .Named("schema-name");


        public static readonly TokenListParser<SqlToken, SqlIdentifierNode> TABLE_OR_ALIAS_NAME =
                 Token.EqualTo(SqlToken.IDENTIFIER)
                    .Select(x => new SqlIdentifierNode{ Span = x.Span })
                    .Named("table-or-alias-name");


       public static readonly TokenListParser<SqlToken, SqlIdentifierNode> COLUMN_NAME = 
                Token.EqualTo(SqlToken.IDENTIFIER)
                    .Select(x => new SqlIdentifierNode{ Span = x.Span })
                    .Named("column-name");

        public static readonly TokenListParser<SqlToken, SqlIdentifierNode> COLUMN_EXPRESSION_ALIAS =
                Token.EqualTo(SqlToken.IDENTIFIER)
                    .Select(x => new SqlIdentifierNode{ Span = x.Span })
                    .Named("column-expression-alias");

        public static readonly TokenListParser<SqlToken, SqlColumnExpressionNode> COLUMN_EXPRESSION = 
                (
                    SCHEMA_NAME.Select(s => new SqlColumnExpressionNode{SchemaName = s})
                    .Then(n => _.PERIOD.Select(p => n)
                    .Then(n => TABLE_OR_ALIAS_NAME.Select(t => {n.TableOrAliasName = t; return n;})
                    .Then(n => _.PERIOD.Select(p => n)
                    .Then(n => COLUMN_NAME.Select(c => {n.ColumnName = c; return n; })))))
                    .Try().Or(
                    TABLE_OR_ALIAS_NAME.Select(t => new SqlColumnExpressionNode{TableOrAliasName = t})
                    .Then(n => _.PERIOD.Select(p => n)
                    .Then(n => COLUMN_NAME.Select(c => {n.ColumnName = c; return n; }))))
                    .Try().Or(
                    COLUMN_NAME.Select(c => new SqlColumnExpressionNode{ColumnName = c }))
                ).Try()
                .Then(n => _.WHITESPACE.Select(w => { n.Whitespace2 = w.Span; return n; }).OptionalOrDefault(n)
                .Then(n => COLUMN_EXPRESSION_ALIAS.Select(ca => { n.ColumnAlias = ca; return n; }).OptionalOrDefault(n)))
                .Then(n => _.WHITESPACE.Select(w => { n.Whitespace3 = w.Span; return n; }).OptionalOrDefault(n))
                .Named("column-expression");


        public static readonly TokenListParser<SqlToken, SqlColumnExpressionListNode> COLUMN_EXPRESSION_LIST =
            COLUMN_EXPRESSION.Select(ce => new SqlColumnExpressionListNode{ce})
            .Then(n => _.WHITESPACE.Select(ws => {n[0].Whitespace1 = ws.Span; return n;}).OptionalOrDefault(n))

            .Then(result => _.COMMA.Select(c => { var n = new  SqlColumnExpressionNode{ Comma = c }; return n;})
                .Then(n => _.WHITESPACE.Select(ws => {n.Whitespace1 = ws.Span; return n;}).OptionalOrDefault(n)
                .Then(n => COLUMN_EXPRESSION.Select(ce => { 
                    ce.Comma = n.Comma;
                    ce.Whitespace1 = n.Whitespace1;
                    return ce;
                }))).Many()
                    .Select(remainingCols => { result.AddRange(remainingCols); return result; }))
            .Named("column-expression-list");



        public static readonly TokenListParser<SqlToken, SqlSelectClauseNode> SELECT_CLAUSE =
                SELECT.Select(kw => new SqlSelectClauseNode { Span = kw.Span})
                .Then(result => _.WHITESPACE.Select(ws1 => { result.Whitespace1 = ws1.Span; return result; }))
                .Then(result => _op.ASTERISK.Select(so => { result.SelectList = new SqlColumnExpressionListNode{Asterisk = so.Operator.EqualsValue("*")}; return result; })
                    .Or(COLUMN_EXPRESSION_LIST.Select(ce => { result.SelectList = ce; ce.Asterisk = false; return result; })))
                .Named("select-clause");

    }

}
