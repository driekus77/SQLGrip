using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Keyword
{
    public abstract class BaseSqlKeywordTable : SqlKeywordTable
    {
        protected IDictionary<string, SqlKeyword> NameToKeywordTable { get; } = new Dictionary<string, SqlKeyword>(StringComparer.InvariantCultureIgnoreCase);
        protected IDictionary<string, SqlKeyword> TextToKeywordTable { get; } = new Dictionary<string, SqlKeyword>(StringComparer.InvariantCultureIgnoreCase);

        public SqlKeyword this[string name] => NameToKeywordTable[name];


        public SqlKeywordTable Add(string name, string group, string text)
        {
            SqlKeyword keyword = new SqlKeyword(name, group, text);

            NameToKeywordTable[keyword.Name] = keyword;
            TextToKeywordTable[keyword.Text] = keyword;

            return this;
        }

        public SqlKeyword GetByName(string name)
        {
            return NameToKeywordTable[name];
        }

        public SqlKeyword GetByText(string text)
        {
            return TextToKeywordTable[text];
        }
    }
}
