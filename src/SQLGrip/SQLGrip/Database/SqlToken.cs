using SQLGrip.Core;
using Superpower.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SQLGrip.Database
{

    public class SqlToken : BaseSqlToken
    {

        public static SqlToken None { get; } = new SqlToken { Id = Tig++, Name = "None", Text = "", Category = "", Description = "When none of the Tokens match." };

        public static SqlToken WhiteSpace{ get; } = new SqlToken { Id = Tig++, Name = "[ws]", Text = " ", Category = "characters", Description = "Matched whitespaces." };

        public static SqlToken String{ get; } = new SqlToken { Id = Tig++, Name = "String", Text = "[\\s]", Category = "characters", Description = "Matched text." };



        public static SqlToken Identifier { get; } = new SqlToken { Id = Tig++, Name = "Identifier", Text = "[\\s]", Category = "characters", Description = "Matched Identifier." };
        public static SqlToken BuiltInIdentifier { get; } = new SqlToken { Id = Tig++, Name = "BuiltInIdentifier", Text = "[\\s]", Category = "characters", Description = "Matched built-in identifier." };
        public static SqlToken RegularExpression { get; } = new SqlToken { Id = Tig++, Name = "RegularExpression", Text = "[\\s]", Category = "characters", Description = "Matched RegularExpression." };




        public static SqlToken Number{ get; } = new SqlToken { Id = Tig++, Name = "Number", Text = "[0-9]", Category = "numeric", Description = "Matched decimal number." };

        public static SqlToken HexNumber{ get; } = new SqlToken { Id = Tig++, Name = "HexNumber", Text = "[0-9A-Fa-f]", Category = "numeric", Description = "Matched hexadecimal number." };


        public static SqlToken Quote{ get; } = new SqlToken { Id = Tig++, Name = "Quote", Text = "'", Category = "characters", Description = "Matched single quote." };

        public static SqlToken DoubleQuote{ get; } = new SqlToken { Id = Tig++, Name = "DoubleQuote", Text = "\"", Category = "characters", Description = "Matched double quote." };

        public static SqlToken Comma{ get; } = new SqlToken { Id = Tig++, Name = "Comma", Text = ",", Category = "characters", Description = "Matches comma." };

        public static SqlToken Period{ get; } = new SqlToken { Id = Tig++, Name = "Period", Text = ".", Category = "last_resort", Description = "Matches Period." };

        public static SqlToken LeftBracket{ get; } = new SqlToken { Id = Tig++, Name = "LeftBracket", Text = "[", Category = "last_resort", Description = "Matches LeftBracket." };

        public static SqlToken RightBracket{ get; } = new SqlToken { Id = Tig++, Name = "RightBracket", Text = "]", Category = "last_resort", Description = "Matches RightBracket." };

        public static SqlToken LeftParen{ get; } = new SqlToken { Id = Tig++, Name = "LeftParen", Text = "(", Category = "last_resort", Description = "Matches LeftParen." };

        public static SqlToken RightParen{ get; } = new SqlToken { Id = Tig++, Name = "RightParen", Text = ")", Category = "last_resort", Description = "Matches RightParen." };

        public static SqlToken QuestionMark{ get; } = new SqlToken { Id = Tig++, Name = "QuestionMark", Text = "?", Category = "last_resort", Description = "Matches QuestionMark." };

        public static SqlToken VerticalBar{ get; } = new SqlToken { Id = Tig++, Name = "VerticalBar", Text = "|", Category = "last_resort", Description = "Matches VerticalBar." };

        public static SqlToken Underscore{ get; } = new SqlToken { Id = Tig++, Name = "Underscore", Text = "_", Category = "last_resort", Description = "Matches Underscore." };

        public static SqlToken Colon{ get; } = new SqlToken { Id = Tig++, Name = "Colon", Text = ":", Category = "last_resort", Description = "Matches Colon." };

        public static SqlToken Semicolon{ get; } = new SqlToken { Id = Tig++, Name = "Semicolon", Text = ";", Category = "last_resort", Description = "Matches Semicolon." };


        public static SqlToken Plus{ get; } = new SqlToken { Id = Tig++, Name = "Plus", Text = "+", Category = "operator", Description = "Matches Plus." };

        public static SqlToken Minus{ get; } = new SqlToken { Id = Tig++, Name = "Minus", Text = "-", Category = "operator", Description = "Matches Minus." };

        public static SqlToken Asterisk{ get; } = new SqlToken { Id = Tig++, Name = "Asterisk", Text = "*", Category = "operator", Description = "Matches Asterisk." };

        public static SqlToken ForwardSlash{ get; } = new SqlToken { Id = Tig++, Name = "ForwardSlash", Text = "/", Category = "operator", Description = "Matches ForwardSlash." };

        public static SqlToken Percent{ get; } = new SqlToken { Id = Tig++, Name = "Percent", Text = "%", Category = "operator", Description = "Matches Percent." };

        public static SqlToken Caret{ get; } = new SqlToken { Id = Tig++, Name = "Caret", Text = "^", Category = "operator", Description = "Matches Caret." };

        public static SqlToken LessThan{ get; } = new SqlToken { Id = Tig++, Name = "LessThan", Text = "<", Category = "operator", Description = "Matches LessThan." };

        public static SqlToken LessThanOrEqual{ get; } = new SqlToken { Id = Tig++, Name = "LessThanOrEqual", Text = "<=", Category = "operator", Description = "Matches LessThanOrEqual." };

        public static SqlToken GreaterThan{ get; } = new SqlToken { Id = Tig++, Name = "GreaterThan", Text = ">", Category = "operator", Description = "Matches GreaterThan." };

        public static SqlToken GreaterThanOrEqual{ get; } = new SqlToken { Id = Tig++, Name = "GreaterThanOrEqual", Text = ">=", Category = "operator", Description = "Matches GreaterThanOrEqual." };

        public static SqlToken Equal{ get; } = new SqlToken { Id = Tig++, Name = "Equal", Text = "=", Category = "operator", Description = "Matches Equal." };

        public static SqlToken NotEqual{ get; } = new SqlToken { Id = Tig++, Name = "NotEqual", Text = "<>", Category = "operator", Description = "Matches NotEqual." };



        public static SqlToken Select{ get; } = new SqlToken { Id = Tig++, Name = "Select", Text = "SELECT", Category = "keyword", Description = "Matches Select." };

        public static SqlToken From{ get; } = new SqlToken { Id = Tig++, Name = "From", Text = "FROM", Category = "keyword", Description = "Matches From." };

        public static SqlToken Where{ get; } = new SqlToken { Id = Tig++, Name = "Where", Text = "WHERE", Category = "keyword", Description = "Matches Where." };

        public static SqlToken And{ get; } = new SqlToken { Id = Tig++, Name = "And", Text = "AND", Category = "keyword", Description = "Matches And." };

        public static SqlToken Or{ get; } = new SqlToken { Id = Tig++, Name = "Or", Text = "OR", Category = "keyword", Description = "Matches Or." };

        public static SqlToken Not{ get; } = new SqlToken { Id = Tig++, Name = "NOT", Text = "NOT", Category = "keyword", Description = "Matches NOT." };

        public static SqlToken Like{ get; } = new SqlToken { Id = Tig++, Name = "LIKE", Text = "LIKE", Category = "keyword", Description = "Matches LIKE." };

        public static SqlToken In{ get; } = new SqlToken { Id = Tig++, Name = "In", Text = "IN", Category = "keyword", Description = "Matches In." };

        public static SqlToken Is{ get; } = new SqlToken { Id = Tig++, Name = "Is", Text = "IS", Category = "keyword", Description = "Matches Is." };

        public static SqlToken As{ get; } = new SqlToken { Id = Tig++, Name = "As", Text = "AS", Category = "keyword", Description = "Matches As." };

        public static SqlToken True{ get; } = new SqlToken { Id = Tig++, Name = "True", Text = "TRUE", Category = "boolean", Description = "Matches True." };

        public static SqlToken False{ get; } = new SqlToken { Id = Tig++, Name = "False", Text = "FALSE", Category = "boolean", Description = "Matches False." };

        public static SqlToken Null{ get; } = new SqlToken { Id = Tig++, Name = "Null", Text = "NULL", Category = "keyword", Description = "Matches NULL keyword." };



        public static IDictionary<string, SqlToken> Keywords { get; private set; }


        static SqlToken()
        {
            Type sqlTokenType = typeof(SqlToken);

            Keywords = new Dictionary<string, SqlToken>(StringComparer.InvariantCultureIgnoreCase);

            foreach ( var pi in sqlTokenType.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(x => x.PropertyType.Equals(sqlTokenType))
                .ToList())
            {
                SqlToken token = (SqlToken)pi.GetValue(null);

                if (token.Category.Contains("keyword"))
                {
                    Keywords[token.Text] = token;
                }
            }
        }
    }
}
