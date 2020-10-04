using SQLGrip.Tree.Nodes;
using SQLGrip.Tree.Nodes.Statements;
using SQLGrip.Tree.Extensions;
using Superpower;
using Superpower.Model;
using Superpower.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGrip.Database
{
    public class SqlTokenParsers
    {

        // Preserve Whitespace
        public TokenListParser<SqlToken, ISqlNode> WS { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Comma { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Period { get; protected set; }

        // Capture operators
        public TokenListParser<SqlToken, ISqlNode> Plus { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Minus { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Asterisk { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> ForwardSlash { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Percent { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Caret { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Lte { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Lt { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Gt { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Gte { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Eq { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Neq { get; protected set; }

        // Capture keywords
        public TokenListParser<SqlToken, ISqlNode> And { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Or { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Not { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Like { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> In { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Is { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> As { get; protected set; }

        public TokenListParser<SqlToken, ISqlNode> Select { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> From { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> Where { get; protected set; }


        // SelectClause Parsers
        public TokenListParser<SqlToken, ISqlNode> SelectClauseSchemaName { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> SelectClauseTableOrAliasName { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> SelectClauseColumnName { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> SelectClauseColumnExpressionAlias { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> SelectClauseColumnExpression { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> SelectClauseColumnExpressionWithOptionalAlias { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> SelectClauseColumnExpressionList { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> SelectClauseSelectList { get; protected set; }
        public TokenListParser<SqlToken, ISqlSelectClauseNode> SelectClause { get; protected set; }

        // FromClause Parsers
        public TokenListParser<SqlToken, ISqlNode> FromClauseTableOrViewName { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> FromClauseTableExpressionAlias { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> FromClauseTableExpression { get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> FromClauseTableExpressionList { get; protected set; }
        public TokenListParser<SqlToken, ISqlFromClauseNode> FromClause { get; protected set; }


        // WhereClause Parsers
        public TokenListParser<SqlToken, ISqlNode> WhereClauseTextLiteral {get;protected set;}
        public TokenListParser<SqlToken, ISqlNode> WhereClauseLeftPart {get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> WhereClauseOperator  {get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> WhereClauseRightPart  {get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> WhereClauseExpression  {get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> WhereClauseExpressionOperands  {get; protected set; }
        public TokenListParser<SqlToken, ISqlNode> WhereClauseExpressionList  {get; protected set; }
        public TokenListParser<SqlToken, ISqlWhereClauseNode> WhereClause { get; protected set; }


        public TokenListParser<SqlToken, ISqlSelectStatementNode> SelectStatement { get; protected set; }

        public TokenListParser<SqlToken, ISqlSelectStatementNode> Statement { get; protected set; }


        protected ISqlNodeFactory SqlNodeFactory { get; }


        public SqlTokenParsers(ISqlNodeFactory sqlNodeFactory = null)
        {
            SqlNodeFactory = sqlNodeFactory ?? new SqlNodeFactory();

            InitOperators();

            InitKeywords();

            InitMisc();

            InitSelectStatement();

            InitStatement();
        }

        protected void InitMisc()
        {
            WS = Token.EqualTo(SqlToken.WhiteSpace).Select(x => SqlNodeFactory.CaptureToken<SqlWhitespaceNode>(x));

            Comma = Token.EqualTo(SqlToken.Comma).Select(x => SqlNodeFactory.CaptureToken<SqlSpecialCharactersNode>(x));

            Period = Token.EqualTo(SqlToken.Period).Select(x => SqlNodeFactory.CaptureToken<SqlSpecialCharactersNode>(x));
        }


        protected void InitOperators()
        {
            Plus = Token.EqualTo(SqlToken.Plus).Select(x => SqlNodeFactory.CaptureToken<SqlOperatorNode>(x));
            Minus = Token.EqualTo(SqlToken.Minus).Select(x => SqlNodeFactory.CaptureToken<SqlOperatorNode>(x));
            Asterisk = Token.EqualTo(SqlToken.Asterisk).Select(x => SqlNodeFactory.CaptureToken<SqlOperatorNode>(x));
            ForwardSlash = Token.EqualTo(SqlToken.ForwardSlash).Select(x => SqlNodeFactory.CaptureToken<SqlOperatorNode>(x));
            Percent = Token.EqualTo(SqlToken.Percent).Select(x => SqlNodeFactory.CaptureToken<SqlOperatorNode>(x));
            Caret = Token.EqualTo(SqlToken.Caret).Select(x => SqlNodeFactory.CaptureToken<SqlOperatorNode>(x));
            Lte = Token.EqualTo(SqlToken.LessThanOrEqual).Select(x => SqlNodeFactory.CaptureToken<SqlOperatorNode>(x));
            Lt = Token.EqualTo(SqlToken.LessThan).Select(x => SqlNodeFactory.CaptureToken<SqlOperatorNode>(x));
            Gt = Token.EqualTo(SqlToken.GreaterThan).Select(x => SqlNodeFactory.CaptureToken<SqlOperatorNode>(x));
            Gte = Token.EqualTo(SqlToken.GreaterThanOrEqual).Select(x => SqlNodeFactory.CaptureToken<SqlOperatorNode>(x));
            Eq = Token.EqualTo(SqlToken.Equal).Select(x => SqlNodeFactory.CaptureToken<SqlOperatorNode>(x));
            Neq = Token.EqualTo(SqlToken.NotEqual).Select(x => SqlNodeFactory.CaptureToken<SqlOperatorNode>(x));
        }

        protected void InitKeywords()
        {
            And = Token.EqualTo(SqlToken.And).Select(x => SqlNodeFactory.CaptureToken<SqlKeywordNode>(x));
            Or = Token.EqualTo(SqlToken.Or).Select(x => SqlNodeFactory.CaptureToken<SqlKeywordNode>(x));
            Not = Token.EqualTo(SqlToken.Not).Select(x => SqlNodeFactory.CaptureToken<SqlKeywordNode>(x));
            Like = Token.EqualTo(SqlToken.Like).Select(x => SqlNodeFactory.CaptureToken<SqlKeywordNode>(x));
            In = Token.EqualTo(SqlToken.In).Select(x => SqlNodeFactory.CaptureToken<SqlKeywordNode>(x));
            Is = Token.EqualTo(SqlToken.Is).Select(x => SqlNodeFactory.CaptureToken<SqlKeywordNode>(x));
            As = Token.EqualTo(SqlToken.As).Select(x => SqlNodeFactory.CaptureToken<SqlKeywordNode>(x));

            // Special keywords
            Select = Token.EqualTo(SqlToken.Select).Select(x => SqlNodeFactory.CaptureToken<SqlKeywordNode>(x));
            From = Token.EqualTo(SqlToken.From).Select(x => SqlNodeFactory.CaptureToken<SqlKeywordNode>(x));
            Where = Token.EqualTo(SqlToken.Where).Select(x => SqlNodeFactory.CaptureToken<SqlKeywordNode>(x));

        }

        protected void InitSelectStatement()
        {
            // SelectClause
            SelectClauseSchemaName = Token.EqualTo(SqlToken.Identifier)
                .Select(x => SqlNodeFactory.CaptureToken<SqlIdentifierNode>(x).Named("SELECT-SCHEMA-NAME"))
                .Named("select-schema-name");

            SelectClauseTableOrAliasName = Token.EqualTo(SqlToken.Identifier)
                .Select(x => SqlNodeFactory.CaptureToken<SqlIdentifierNode>(x).Named("SELECT-TABLE-REF"))
                .Named("select-table-ref");

            SelectClauseColumnName = Token.EqualTo(SqlToken.Identifier)
                .Select(x => SqlNodeFactory.CaptureToken<SqlIdentifierNode>(x).Named("SELECT-COLUMN-NAME"))
                .Named("select-column-name");

            SelectClauseColumnExpressionAlias =
             Token.EqualTo(SqlToken.Identifier)
                .Select(x => SqlNodeFactory.CaptureToken<SqlIdentifierNode>(x).Named("SELECT-COLUMN-ALIAS"))
                .Named("select-column-alias");

            SelectClauseColumnExpression =
                from colExpr in (
                (
                    from schema in SelectClauseSchemaName
                    from period1 in Period
                    from table in SelectClauseTableOrAliasName
                    from period2 in Period
                    from column in SelectClauseColumnName
                    select SqlNodeFactory.Capture<SqlColumnExpressionNode>(schema, period1, table, period2, column)
                ).Try()
                .Or(
                    from table in SelectClauseTableOrAliasName
                    from period1 in Period
                    from column in SelectClauseColumnName
                    select SqlNodeFactory.Capture<SqlColumnExpressionNode>(table, period1, column)
                ).Try()
                .Or(
                    SelectClauseColumnName.Select(column => SqlNodeFactory.Capture<SqlColumnExpressionNode>(column))
                ))
                from ws in WS.OptionalOrDefault()
                from optAlias in (
                    from optAs in (
                        from kw in As
                        from ws2 in WS
                        select Tuple.Create(kw, ws2)
                    ).OptionalOrDefault()
                    from columnAlias in SelectClauseColumnExpressionAlias
                    from ws3 in WS.OptionalOrDefault()
                    select SqlNodeFactory.Capture<SqlColumnExpressionNode>(ws, optAs?.Item1, optAs?.Item2, columnAlias, ws3)
                        ).OptionalOrDefault()
                select colExpr
                .Named("select-column-expression");

            SelectClauseColumnExpressionList =
                from colexpr in SelectClauseColumnExpression
                from ws1 in WS.OptionalOrDefault()
                from remainder in (   
                    from comma in Comma
                    from ws2 in WS.OptionalOrDefault()
                    from colexprextra in SelectClauseColumnExpression
                    from ws3 in WS.OptionalOrDefault()
                    select new List<ISqlNode> { ws1, comma, ws2, colexprextra }).Many()
                select SqlNodeFactory.Capture<SqlColumnExpressionListNode>(CombineToList(colexpr, remainder).ToArray());

            SelectClauseSelectList = (
                from colpart in Asterisk.Or(SelectClauseColumnExpressionList)
                select colpart)
                .Named("selectlist");

            SelectClause =
                (   from kw in Select
                    from ws1 in WS
                    from sl in SelectClauseSelectList
                    from ws2 in WS.OptionalOrDefault()
                    select (ISqlSelectClauseNode)SqlNodeFactory.CaptureClause<SqlSelectClauseNode>(kw, ws1, sl, ws2))
                .Named("selectclause");


            // FromClause
            FromClauseTableExpressionAlias =
                 Token.EqualTo(SqlToken.Identifier)
                    .Select(x => SqlNodeFactory.CaptureToken<SqlIdentifierNode>(x).Named("FROM-TABLE-ALIAS"))
                    .Named("from-table-alias");

            FromClauseTableOrViewName = Token.EqualTo(SqlToken.Identifier)
                .Select(x => SqlNodeFactory.CaptureToken<SqlIdentifierNode>(x).Named("FROM-TABLE-NAME"))
                .Named("from-table-name");


            FromClauseTableExpression = (
                from tableName in FromClauseTableOrViewName
                from ws1 in WS.OptionalOrDefault()
                from optAs in (
                    from kw in As
                    from ws2 in WS
                    select Tuple.Create(kw, ws2)
                    ).OptionalOrDefault()
                from alias in FromClauseTableExpressionAlias.OptionalOrDefault()
                select SqlNodeFactory.Capture<SqlTableExpressionNode>(tableName, ws1, optAs?.Item1, optAs?.Item2, alias))
                .Named("from-table-expression");

            FromClauseTableExpressionList =
                from tableExpr in FromClauseTableExpression
                from ws1 in WS.OptionalOrDefault()
                from remainder in (
                    from comma in Comma
                    from ws2 in WS.OptionalOrDefault()
                    from tableExpr2 in FromClauseTableExpression
                    from ws3 in WS.OptionalOrDefault()
                    select new List<ISqlNode> { comma, ws2, tableExpr2, ws3}
                    ).Many()
                select SqlNodeFactory.Capture<SqlTableExpressionListNode>(CombineToList(new List<ISqlNode>{ tableExpr, ws1 }, remainder).ToArray());

            FromClause =
                (from kw in From
                 from ws1 in WS
                 from list in FromClauseTableExpressionList
                 from ws2 in WS.OptionalOrDefault()
                 select (ISqlFromClauseNode)SqlNodeFactory.CaptureClause<SqlFromClauseNode>(kw, ws1, list, ws2))
                .Named("fromclause");



            // WhereClause
            WhereClauseTextLiteral = (
                from quoteStart in Token.EqualTo(SqlToken.Quote)
                from txt in Token.EqualTo(SqlToken.Identifier)
                from quoteEnd in Token.EqualTo(SqlToken.Quote)
                select SqlNodeFactory.CaptureToken<SqlIdentifierNode>(txt)
            ).Named("whereclause-textliteral");

            WhereClauseLeftPart = (
                from txt in WhereClauseTextLiteral
                select txt )
                .Try()
                .Or(
                    from txt in Token.EqualTo(SqlToken.Identifier)
                    select SqlNodeFactory.CaptureToken<SqlIdentifierNode>(txt) )
                .Select(x => x)
                .Named("where-leftpart-name");

            WhereClauseOperator = 
                Token.EqualTo(SqlToken.Equal).Try()
                .Or(Token.EqualTo(SqlToken.GreaterThan)).Try()
                .Or(Token.EqualTo(SqlToken.GreaterThanOrEqual)).Try()
                .Or(Token.EqualTo(SqlToken.LessThan)).Try()
                .Or(Token.EqualTo(SqlToken.LessThanOrEqual)).Try()
                .Or(Token.EqualTo(SqlToken.Like)).Try()
                .Or(Token.EqualTo(SqlToken.NotEqual))
                .Select(x => SqlNodeFactory.CaptureToken<SqlKeywordNode>(x))
                .Named("where-operator-name");
                
            WhereClauseRightPart = (
                    from txt in Token.EqualTo(SqlToken.String)
                    select SqlNodeFactory.CaptureToken<SqlIdentifierNode>(txt) )
                .Try()
                .Or(
                    from txt in Token.EqualTo(SqlToken.Identifier)
                    select SqlNodeFactory.CaptureToken<SqlIdentifierNode>(txt) )
                .Select(x => x)
                .Named("where-rightpart-name");

            
            WhereClauseExpression = (
                from wclp in WhereClauseLeftPart
                from ws1 in WS
                from wcop in WhereClauseOperator
                from ws2 in WS
                from wcrp in WhereClauseRightPart
                select SqlNodeFactory.CaptureBinary<SqlColumnExpressionNode>(wcop, wclp, wcrp))
                .Named("where-expression");

            WhereClauseExpressionOperands = 
                Token.EqualTo(SqlToken.And).Try()
                .Or(Token.EqualTo(SqlToken.Or)).Try()
                .Or(Token.EqualTo(SqlToken.Not))
                .Select(x => SqlNodeFactory.CaptureToken<SqlColumnExpressionNode>(x))
                .Named("where-operands");

            WhereClauseExpressionList = (
                from expr1 in WhereClauseExpression
                from ws1 in WS
                from operands in WhereClauseExpressionOperands.OptionalOrDefault()
                from ws2 in WS.OptionalOrDefault()
                from expr2 in WhereClauseExpression.OptionalOrDefault()
                select SqlNodeFactory.Capture<SqlColumnExpressionNode>(expr1, ws1, operands, ws2, expr2))
                .Named("where-expression-list");

            WhereClause = (
                from kw in Where
                from ws1 in WS
                from exprList in WhereClauseExpressionList.Many()
                select (ISqlWhereClauseNode)SqlNodeFactory.CaptureClause<SqlWhereClauseNode>(exprList))
                .Named("whereclause");



            // GroupByClause


            // OderByClause


            // SelectStatement
            SelectStatement =
                from selectClause in SelectClause
                from ws1 in WS.OptionalOrDefault()
                from fromClause in FromClause
                from ws2 in WS.OptionalOrDefault()
                from whereClause in WhereClause
                select (ISqlSelectStatementNode)SqlNodeFactory.CaptureStatement<SqlSelectStatementNode>(selectClause, fromClause, whereClause);
        }


        protected void InitStatement()
        {
            Statement = 
                from ws1 in WS.OptionalOrDefault()
                from stmnt in SelectStatement
                from ws2 in WS.OptionalOrDefault()
                select stmnt;
        }


        protected ISqlNode MakeBinary(ISqlNode sqlOperator, ISqlNode leftOperand, ISqlNode rightOperand)
        {
            return SqlNodeFactory.CaptureBinary<SqlOperatorNode>(sqlOperator, leftOperand, rightOperand);
        }

        protected ISqlNode MakeUnary(ISqlNode sqlOperator, ISqlNode sqlOperand)
        {
            return SqlNodeFactory.CaptureUnary<SqlOperatorNode>(sqlOperator, sqlOperand);
        }


        protected IList<ISqlNode> CombineToList(ISqlNode n, IList<ISqlNode>[] listArrays)
        {
            List<ISqlNode> list = new List<ISqlNode> { n };

            foreach (var l in listArrays)
            {
                list.AddRange(l);
            }

            return list;
        }

        protected IList<ISqlNode> CombineToList(IList<ISqlNode> nodes, IList<ISqlNode>[] listArrays)
        {
            List<ISqlNode> list = new List<ISqlNode>(nodes);

            foreach (var l in listArrays)
            {
                list.AddRange(l);
            }

            return list;
        }


        public TokenListParserResult<SqlToken, ISqlSelectStatementNode> TryParse(TokenList<SqlToken> input)
        {
            return Statement.AtEnd().TryParse(input);
        }

        public ISqlStatementNode DoParse(
            TokenList<SqlToken> input)
        {
            return Statement.AtEnd().Parse(input);
        }

    }
}
