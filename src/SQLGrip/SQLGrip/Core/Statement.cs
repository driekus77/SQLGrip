using SQLGrip.Tree.Nodes.Statements;
using SQLGrip.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Core
{
    public class Statement : IStatement
    {
        private readonly SqlParser parser = new SqlParser();

        public ISqlStatementNode ParsedNode {get;internal set;}

        public Language Language { get; }

        public string Text { get; set; }



        public Statement(string text = null, Language language = Language.ANSI)
        {
            Text = text;
            Language = language;
        }


        public IStatement Parse()
        {
            ParsedNode = parser.Parse(this.Text);

            return this;
        }
    }
}
