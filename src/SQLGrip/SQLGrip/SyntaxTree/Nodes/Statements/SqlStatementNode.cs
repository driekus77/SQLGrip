using System.Text;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlStatementNode : SqlNode
    {

        public SqlSelectStatementNode SelectStatement {get;set;}



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();


            if ( SelectStatement != null )
            {
                sb.Append(SelectStatement.ToString());
            }

            return sb.ToString();
        }
    }
}
