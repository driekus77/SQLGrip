using SQLGrip.Tree.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Core
{
    public class Statement : IStatement
    {
        private IDictionary<long, ISqlNode> NodeDictionary { get; } = new Dictionary<long, ISqlNode>();


        public Language Language { get; }

        public string Text { get; set; }



        public Statement(Language language, string text = null)
        {
            Text = text;
            Language = language;
        }


        public IStatement Parse()
        {
            return this;
        }
    }
}
