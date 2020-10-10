using SQLGrip.SyntaxTree.Nodes;
using SQLGrip.SyntaxTree.Extensions;
using Superpower;
using Superpower.Model;
using Superpower.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGrip.Parsers.ANSI.Version92
{
    public class SqlTokenParsers
    {

        // Preserve Whitespace
        public static readonly TokenListParser<SqlToken, SqlWhitespaceNode> WHITESPACE_PARSELET = 
            Token.EqualTo(SqlToken.WHITESPACE).Select(x => new SqlWhitespaceNode(x));
        
        public static readonly TokenListParser<SqlToken, SqlSpecialCharactersNode> COMMA_PARSELET =
            Token.EqualTo(SqlToken.COMMA).Select(x => new SqlSpecialCharactersNode(x));

        public static readonly TokenListParser<SqlToken, SqlSpecialCharactersNode> PERIOD_PARSELET =
            Token.EqualTo(SqlToken.PERIOD).Select(x => new SqlSpecialCharactersNode(x));


        // Capture operators
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> PLUS_PARSELET =
            Token.EqualTo(SqlToken.PLUS).Select(x => new SqlOperatorNode(x));
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> MINUS_PARSELET =
            Token.EqualTo(SqlToken.MINUS).Select(x => new SqlOperatorNode(x));
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> ASTERISK_PARSELET =
            Token.EqualTo(SqlToken.ASTERISK).Select(x => new SqlOperatorNode(x));
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> FORWARD_SLASH_PARSELET =
            Token.EqualTo(SqlToken.FORWARD_SLASH).Select(x => new SqlOperatorNode(x));
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> PERCENT_PARSELET  = 
            Token.EqualTo(SqlToken.PERCENT).Select(x => new SqlOperatorNode(x));
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> CARET_PARSELET =
            Token.EqualTo(SqlToken.CARET).Select(x => new SqlOperatorNode(x));
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> LESS_THAN_OR_EQUAL_PARSELET =
            Token.EqualTo(SqlToken.LESS_THAN_OR_EQUAL).Select(x => new SqlOperatorNode(x));
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> LESS_THAN_PARSELET =
            Token.EqualTo(SqlToken.LESS_THAN).Select(x => new SqlOperatorNode(x));
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> GREATER_THAN_PARSELET =
            Token.EqualTo(SqlToken.GREATER_THAN).Select(x => new SqlOperatorNode(x));
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> GREATER_THAN_OR_EQUAL_PARSELET =
            Token.EqualTo(SqlToken.GREATER_THAN_OR_EQUAL).Select(x => new SqlOperatorNode(x));
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> EQUAL_PARSELET =
            Token.EqualTo(SqlToken.EQUAL).Select(x => new SqlOperatorNode(x));
        public static readonly TokenListParser<SqlToken, SqlOperatorNode> NOT_EQUAL_PARSELET =
            Token.EqualTo(SqlToken.NOT_EQUAL).Select(x => new SqlOperatorNode(x));

/*
        // Capture keywords
        public static readonly TokenListParser<SqlToken, SqlNode> And { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> Or { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> Not { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> Like { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> In { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> Is { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> As { get; protected set; }

        public static readonly TokenListParser<SqlToken, SqlNode> Select { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> From { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> Where { get; protected set; }


        // SelectClause Parsers
        public static readonly TokenListParser<SqlToken, SqlNode> SelectClauseSchemaName { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> SelectClauseTableOrAliasName { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> SelectClauseColumnName { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> SelectClauseColumnExpressionAlias { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> SelectClauseColumnExpression { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> SelectClauseColumnExpressionWithOptionalAlias { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> SelectClauseColumnExpressionList { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> SelectClauseSelectList { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlSelectClauseNode> SelectClause { get; protected set; }

        // FromClause Parsers
        public static readonly TokenListParser<SqlToken, SqlNode> FromClauseTableOrViewName { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> FromClauseTableExpressionAlias { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> FromClauseTableExpression { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> FromClauseTableExpressionList { get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlFromClauseNode> FromClause { get; protected set; }


        // WhereClause Parsers
        public static readonly TokenListParser<SqlToken, SqlNode> WhereClauseTextLiteral {get;protected set;}
        public static readonly TokenListParser<SqlToken, SqlNode> WhereClauseLeftPart {get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> WhereClauseOperator  {get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> WhereClauseRightPart  {get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> WhereClauseExpression  {get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> WhereClauseExpressionOperands  {get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlNode> WhereClauseExpressionList  {get; protected set; }
        public static readonly TokenListParser<SqlToken, SqlWhereClauseNode> WhereClause { get; protected set; }


        public static readonly TokenListParser<SqlToken, SqlSelectStatementNode> SelectStatement { get; protected set; }

        public static readonly TokenListParser<SqlToken, SqlStatementNode> Statement { get; protected set; }



        public SqlTokenParsers()
        {
            InitOperators();

            InitKeywords();

            InitMisc();

            InitSelectStatement();

            InitStatement();
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

        */

        
    }
}
