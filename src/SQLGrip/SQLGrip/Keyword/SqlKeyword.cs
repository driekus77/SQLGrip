using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Keyword
{
    public class SqlKeyword
    {
        public string Name { get; }

        public string Group { get;  }

        public string Text { get;  }


        public SqlKeyword(string name, string group, string text)
        {
            Name = name;
            Group = group;
            Text = text;
        }

        public override string ToString()
        {
            return $"{Name}:{Text}";
        }
    }
}
