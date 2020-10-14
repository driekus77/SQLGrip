using Superpower.Model;

namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlWhitespaceNode : SqlNode
    {
        public TextSpan Span {get;set;}


        public override string ToString()
        {
            return Span.ToStringValue();
        }
    }
}
