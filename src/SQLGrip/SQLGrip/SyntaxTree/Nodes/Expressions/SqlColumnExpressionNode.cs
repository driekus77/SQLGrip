using Superpower.Model;
using System.Text;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlColumnExpressionNode : SqlNode
    {
        public SqlSpecialCharactersNode Comma { get; set; }

        public TextSpan Whitespace1 { get; set; }

        public SqlIdentifierNode SchemaName { get; set; }

        public SqlIdentifierNode TableOrAliasName { get; set; }

        public SqlIdentifierNode ColumnName { get; set; }


        public TextSpan Whitespace2 { get; set; }

        public SqlIdentifierNode ColumnAlias { get; set; }

        public TextSpan Whitespace3 { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Comma != null )
            {
                sb.Append(Comma.ToString());
            }

            if ( Whitespace1.Length > 0 )
            {
                sb.Append(Whitespace1.ToStringValue());
            }

            if (SchemaName != null)
            {
                sb.AppendFormat("{0}.", SchemaName.ToString());
            }

            if (TableOrAliasName != null)
            {
                sb.AppendFormat("{0}.", TableOrAliasName.ToString());
            }

            if (ColumnName != null)
            {
                sb.Append(ColumnName.ToString());
            }

            if ( Whitespace2.Length > 0 )
            {
                sb.Append(Whitespace2.ToStringValue());
            }

            if (ColumnAlias != null)
            {
                sb.Append(ColumnAlias.ToString());
            }

            if ( Whitespace3.Length > 0)
            {
                sb.Append(Whitespace3.ToStringValue());
            }

            return sb.ToString();
        }
    }
}
