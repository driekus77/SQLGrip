using System.Collections.Generic;


namespace SQLGrip.SyntaxTree.Nodes
{

    public class SqlColumnExpressionListNode : SqlListNode<SqlColumnExpressionNode>
    {

        public bool Asterisk {get;set;}


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
