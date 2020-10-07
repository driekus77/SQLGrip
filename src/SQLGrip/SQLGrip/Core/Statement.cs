using SQLGrip.SyntaxTree.Nodes;
using SQLGrip.ParserTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip
{
    public class Statement
    {
        private readonly SqlParser parser = new SqlParser();

        public SqlStatementNode ParsedNode {get;internal set;}

        public Language Language { get; }

        public string Text { get; set; }



        public Statement(string text = null, Language language = Language.ANSI)
        {
            Text = text;
            Language = language;
        }


        public Statement Parse()
        {
            ParsedNode = parser.Parse(this.Text);

            return this;
        }
    }
}
