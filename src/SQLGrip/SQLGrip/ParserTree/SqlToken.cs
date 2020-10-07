using Superpower.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SQLGrip.ParserTree
{

    public class SqlToken
    {
        public static readonly SqlToken None  = new SqlToken { Name = "None", Text = "", Category = "", Description = "When none of the Tokens match." };

        public static readonly SqlToken WhiteSpace = new SqlToken { Name = "[ws]", Text = " ", Category = "characters", Description = "Matched whitespaces." };

        public static readonly SqlToken String = new SqlToken { Name = "String", Text = "[\\s]", Category = "characters", Description = "Matched text." };



        public static readonly SqlToken Identifier  = new SqlToken { Name = "Identifier", Text = "[\\s]", Category = "characters", Description = "Matched Identifier." };
        public static readonly SqlToken BuiltInIdentifier  = new SqlToken { Name = "BuiltInIdentifier", Text = "[\\s]", Category = "characters", Description = "Matched built-in identifier." };
        public static readonly SqlToken RegularExpression  = new SqlToken { Name = "RegularExpression", Text = "[\\s]", Category = "characters", Description = "Matched RegularExpression." };




        public static readonly SqlToken Number = new SqlToken { Name = "Number", Text = "[0-9]", Category = "numeric", Description = "Matched decimal number." };

        public static readonly SqlToken HexNumber = new SqlToken { Name = "HexNumber", Text = "[0-9A-Fa-f]", Category = "numeric", Description = "Matched hexadecimal number." };


        public static readonly SqlToken Quote = new SqlToken { Name = "Quote", Text = "'", Category = "characters", Description = "Matched single quote." };

        public static readonly SqlToken DoubleQuote = new SqlToken { Name = "DoubleQuote", Text = "\"", Category = "characters", Description = "Matched double quote." };

        public static readonly SqlToken Comma = new SqlToken { Name = "Comma", Text = ",", Category = "characters", Description = "Matches comma." };

        public static readonly SqlToken Period = new SqlToken { Name = "Period", Text = ".", Category = "last_resort", Description = "Matches Period." };

        public static readonly SqlToken LeftBracket = new SqlToken { Name = "LeftBracket", Text = "[", Category = "last_resort", Description = "Matches LeftBracket." };

        public static readonly SqlToken RightBracket = new SqlToken { Name = "RightBracket", Text = "]", Category = "last_resort", Description = "Matches RightBracket." };

        public static readonly SqlToken LeftParen = new SqlToken { Name = "LeftParen", Text = "(", Category = "last_resort", Description = "Matches LeftParen." };

        public static readonly SqlToken RightParen = new SqlToken { Name = "RightParen", Text = ")", Category = "last_resort", Description = "Matches RightParen." };

        public static readonly SqlToken QuestionMark = new SqlToken { Name = "QuestionMark", Text = "?", Category = "last_resort", Description = "Matches QuestionMark." };

        public static readonly SqlToken VerticalBar = new SqlToken { Name = "VerticalBar", Text = "|", Category = "last_resort", Description = "Matches VerticalBar." };

        public static readonly SqlToken Underscore = new SqlToken { Name = "Underscore", Text = "_", Category = "last_resort", Description = "Matches Underscore." };

        public static readonly SqlToken Colon = new SqlToken { Name = "Colon", Text = ":", Category = "last_resort", Description = "Matches Colon." };

        public static readonly SqlToken Semicolon = new SqlToken { Name = "Semicolon", Text = ";", Category = "last_resort", Description = "Matches Semicolon." };


        public static readonly SqlToken Plus = new SqlToken { Name = "Plus", Text = "+", Category = "operator", Description = "Matches Plus." };

        public static readonly SqlToken Minus = new SqlToken { Name = "Minus", Text = "-", Category = "operator", Description = "Matches Minus." };

        public static readonly SqlToken Asterisk = new SqlToken { Name = "Asterisk", Text = "*", Category = "operator", Description = "Matches Asterisk." };

        public static readonly SqlToken ForwardSlash = new SqlToken { Name = "ForwardSlash", Text = "/", Category = "operator", Description = "Matches ForwardSlash." };

        public static readonly SqlToken Percent = new SqlToken { Name = "Percent", Text = "%", Category = "operator", Description = "Matches Percent." };

        public static readonly SqlToken Caret = new SqlToken { Name = "Caret", Text = "^", Category = "operator", Description = "Matches Caret." };

        public static readonly SqlToken LessThan = new SqlToken { Name = "LessThan", Text = "<", Category = "operator", Description = "Matches LessThan." };

        public static readonly SqlToken LessThanOrEqual = new SqlToken { Name = "LessThanOrEqual", Text = "<=", Category = "operator", Description = "Matches LessThanOrEqual." };

        public static readonly SqlToken GreaterThan = new SqlToken { Name = "GreaterThan", Text = ">", Category = "operator", Description = "Matches GreaterThan." };

        public static readonly SqlToken GreaterThanOrEqual = new SqlToken { Name = "GreaterThanOrEqual", Text = ">=", Category = "operator", Description = "Matches GreaterThanOrEqual." };

        public static readonly SqlToken Equal = new SqlToken { Name = "Equal", Text = "=", Category = "operator", Description = "Matches Equal." };

        public static readonly SqlToken NotEqual = new SqlToken { Name = "NotEqual", Text = "<>", Category = "operator", Description = "Matches NotEqual." };



        public static SqlToken Select = new SqlToken { Name = "Select", Text = "SELECT", Category = "keyword", Description = "Matches Select." };

        public static readonly SqlToken From = new SqlToken { Name = "From", Text = "FROM", Category = "keyword", Description = "Matches From." };

        public static readonly SqlToken Where = new SqlToken { Name = "Where", Text = "WHERE", Category = "keyword", Description = "Matches Where." };

        public static readonly SqlToken And = new SqlToken { Name = "And", Text = "AND", Category = "keyword", Description = "Matches And." };

        public static readonly SqlToken Or = new SqlToken { Name = "Or", Text = "OR", Category = "keyword", Description = "Matches Or." };

        public static readonly SqlToken Not = new SqlToken { Name = "NOT", Text = "NOT", Category = "keyword", Description = "Matches NOT." };

        public static readonly SqlToken Like = new SqlToken { Name = "LIKE", Text = "LIKE", Category = "keyword", Description = "Matches LIKE." };

        public static readonly SqlToken In = new SqlToken { Name = "In", Text = "IN", Category = "keyword", Description = "Matches In." };

        public static readonly SqlToken Is = new SqlToken { Name = "Is", Text = "IS", Category = "keyword", Description = "Matches Is." };

        public static readonly SqlToken As = new SqlToken { Name = "As", Text = "AS", Category = "keyword", Description = "Matches As." };

        public static readonly SqlToken True = new SqlToken { Name = "True", Text = "TRUE", Category = "boolean", Description = "Matches True." };

        public static readonly SqlToken False = new SqlToken { Name = "False", Text = "FALSE", Category = "boolean", Description = "Matches False." };

        public static readonly SqlToken Null = new SqlToken { Name = "Null", Text = "NULL", Category = "keyword", Description = "Matches NULL keyword." };



        public static IDictionary<string, SqlToken> Keywords { get; private set; }


        static SqlToken()
        {
            Type sqlTokenType = typeof(SqlToken);

            Keywords = new Dictionary<string, SqlToken>(StringComparer.InvariantCultureIgnoreCase);

            foreach ( var pi in sqlTokenType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(x => x.FieldType.Equals(sqlTokenType))
                .ToList())
            {
                SqlToken token = (SqlToken)pi.GetValue(null);

                if (token.Category.Contains("keyword"))
                {
                    Keywords[token.Text] = token;
                }
            }
        }


        public string Name { get; set; }

        public string Text { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }



        public override string ToString()
        {
            return $"@{Name}";
        }

    }
}
