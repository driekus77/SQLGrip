using SQLGrip.SyntaxTree.Nodes;
using SQLGrip.SyntaxTree.Extensions;
using Superpower;
using Superpower.Model;
using Superpower.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGrip.ParserTree
{
    public class SqlTokenParsers
    {

        // Preserve Whitespace
        public TokenListParser<SqlToken, SqlNode> WS { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Comma { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Period { get; protected set; }

        // Capture operators
        public TokenListParser<SqlToken, SqlNode> Plus { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Minus { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Asterisk { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> ForwardSlash { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Percent { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Caret { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Lte { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Lt { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Gt { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Gte { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Eq { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Neq { get; protected set; }

        // Capture keywords
        public TokenListParser<SqlToken, SqlNode> And { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Or { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Not { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Like { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> In { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Is { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> As { get; protected set; }

        public TokenListParser<SqlToken, SqlNode> Select { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> From { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> Where { get; protected set; }


        // SelectClause Parsers
        public TokenListParser<SqlToken, SqlNode> SelectClauseSchemaName { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> SelectClauseTableOrAliasName { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> SelectClauseColumnName { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> SelectClauseColumnExpressionAlias { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> SelectClauseColumnExpression { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> SelectClauseColumnExpressionWithOptionalAlias { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> SelectClauseColumnExpressionList { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> SelectClauseSelectList { get; protected set; }
        public TokenListParser<SqlToken, SqlSelectClauseNode> SelectClause { get; protected set; }

        // FromClause Parsers
        public TokenListParser<SqlToken, SqlNode> FromClauseTableOrViewName { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> FromClauseTableExpressionAlias { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> FromClauseTableExpression { get; protected set; }
        public TokenListParser<SqlToken, SqlNode> FromClauseTableExpressionList { get; protected set; }
        public TokenListParser<SqlToken, SqlFromClauseNode> FromClause { get; protected set; }


        // WhereClause Parsers
        public TokenListParser<SqlToken, SqlNode> WhereClauseTextLiteral {get;protected set;}
        public TokenListParser<SqlToken, SqlNode> WhereClauseLeftPart {get; protected set; }
        public TokenListParser<SqlToken, SqlNode> WhereClauseOperator  {get; protected set; }
        public TokenListParser<SqlToken, SqlNode> WhereClauseRightPart  {get; protected set; }
        public TokenListParser<SqlToken, SqlNode> WhereClauseExpression  {get; protected set; }
        public TokenListParser<SqlToken, SqlNode> WhereClauseExpressionOperands  {get; protected set; }
        public TokenListParser<SqlToken, SqlNode> WhereClauseExpressionList  {get; protected set; }
        public TokenListParser<SqlToken, SqlWhereClauseNode> WhereClause { get; protected set; }


        public TokenListParser<SqlToken, SqlSelectStatementNode> SelectStatement { get; protected set; }

        public TokenListParser<SqlToken, SqlStatementNode> Statement { get; protected set; }



        public SqlTokenParsers()
        {
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

            SelectClauseColumnExpressionList = (
                from colexpr in SelectClauseColumnExpression
                from ws1 in WS.OptionalOrDefault()
                from remainder in (   
                    from comma in Comma
                    from ws2 in WS.OptionalOrDefault()
                    from colexprextra in SelectClauseColumnExpression
                    from ws3 in WS.OptionalOrDefault()
                    select new List<SqlNode> { ws1, comma, ws2, colexprextra }).Many()
                select SqlNodeFactory.CaptureList<SqlNode>(CombineToList(colexpr, remainder.ToArray())))
                .Named("select-column-expressionlist");

            SelectClauseSelectList = (
                from colpart in Asterisk.Or(SelectClauseColumnExpressionList)
                select colpart)
                .Named("selectlist");

            SelectClause =
                (   from kw in Select
                    from ws1 in WS
                    from sl in SelectClauseSelectList
                    select (SqlSelectClauseNode)SqlNodeFactory.Capture<SqlSelectClauseNode>(kw, ws1, sl))
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
                select SqlNodeFactory.Capture<SqlNode>(tableName, ws1, optAs?.Item1, optAs?.Item2, alias))
                .Named("from-table-expression");

            FromClauseTableExpressionList =
                from tableExpr in FromClauseTableExpression
                from ws1 in WS.OptionalOrDefault()
                from remainder in (
                    from comma in Comma
                    from ws2 in WS.OptionalOrDefault()
                    from tableExpr2 in FromClauseTableExpression
                    from ws3 in WS.OptionalOrDefault()
                    select new List<SqlNode> { comma, ws2, tableExpr2, ws3}
                    ).Many()
                select SqlNodeFactory.Capture<SqlNode>(CombineToList(new List<SqlNode>{ tableExpr, ws1 }, remainder).ToArray());

            FromClause =
                (from kw in From
                 from ws1 in WS
                 from list in FromClauseTableExpressionList
                 from ws2 in WS.OptionalOrDefault()
                 select (SqlFromClauseNode)SqlNodeFactory.Capture<SqlFromClauseNode>(kw, ws1, list, ws2))
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
                select SqlNodeFactory.Capture<SqlNode>(wclp, ws1, wcop, ws2, wcrp))
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
                select SqlNodeFactory.Capture<SqlNode>(expr1, ws1, operands, ws2, expr2))
                .Named("where-expression-list");

            WhereClause = (
                from kw in Where
                from ws1 in WS
                from exprList in WhereClauseExpressionList
                select SqlNodeFactory.Capture<SqlWhereClauseNode>(kw, ws1, exprList))
                .Named("whereclause");



            // GroupByClause


            // OderByClause


            // SelectStatement
            SelectStatement =
                from selectClause in SelectClause
                from ws1 in WS.OptionalOrDefault()
                from fromClause in FromClause
                from ws2 in WS.OptionalOrDefault()
                from whereClause in WhereClause.OptionalOrDefault()
                select SqlNodeFactory.Capture<SqlSelectStatementNode>(selectClause, ws1, fromClause, ws2, whereClause);
        }


        protected void InitStatement()
        {
            Statement = 
                from ws1 in WS.OptionalOrDefault(SqlWhitespaceNode.Empty)
                from stmnt in SelectStatement
                from ws2 in WS.OptionalOrDefault(SqlWhitespaceNode.Empty)
                select SqlNodeFactory.Capture<SqlStatementNode>(ws1, stmnt, ws2);
        }


        protected SqlNode MakeBinary(SqlNode sqlOperator, SqlNode leftOperand, SqlNode rightOperand)
        {
            return SqlNodeFactory.Capture<SqlOperatorNode>(sqlOperator, leftOperand, rightOperand);
        }

        protected SqlNode MakeUnary(SqlNode sqlOperator, SqlNode sqlOperand)
        {
            return SqlNodeFactory.Capture<SqlOperatorNode>(sqlOperator, sqlOperand);
        }


        protected List<SqlNode> CombineToList(SqlNode n, List<SqlNode>[] listArrays)
        {
            List<SqlNode> list = new List<SqlNode> { n };

            foreach (var l in listArrays)
            {
                list.AddRange(l);
            }

            return list;
        }

        protected List<SqlNode> CombineToList(List<SqlNode> nodes, List<SqlNode>[] listArrays)
        {
            List<SqlNode> list = new List<SqlNode>(nodes);

            foreach (var l in listArrays)
            {
                list.AddRange(l);
            }

            return list;
        }


        public TokenListParserResult<SqlToken, SqlStatementNode> TryParse(TokenList<SqlToken> input)
        {
            return Statement.AtEnd().TryParse(input);
        }

        public SqlStatementNode DoParse(
            TokenList<SqlToken> input)
        {
            return Statement.AtEnd().Parse(input);
        }

    }
}
