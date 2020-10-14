using System;
using System.Text;
using System.Collections.Generic;
using SQLGrip.Parsers;
using Superpower;
using Superpower.Model;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlSelectStatementNode : SqlNode
    {
        public SqlSelectClauseNode SelectClause { get; set; }

        public TextSpan Whitespace1 { get; set; }

        public SqlFromClauseNode FromClause { get; set; }

        public TextSpan Whitespace2 { get; set; }

        public SqlWhereClauseNode WhereClause { get; set; }

        //public SqlGroupByClauseNode GroupByClause => throw new NotImplementedException();

        //public SqlOrderByClauseNode OrderByClause => throw new NotImplementedException();


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (SelectClause != null)
            {
                sb.Append(SelectClause.ToString());
            }

            if (!Whitespace1.Equals(TextSpan.Empty))
            {
                sb.Append(Whitespace1.ToStringValue());
            }
        
            if (FromClause != null )
            {
                sb.Append(FromClause.ToString());
            }

            if (!Whitespace2.Equals(TextSpan.Empty))
            {
                sb.Append(Whitespace2.ToStringValue());
            }

            if (WhereClause != null)
            {
                sb.Append(WhereClause.ToString());
            }

            return sb.ToString();
        }
    }
}
