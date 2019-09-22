using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Keyword
{
    public interface ISqlKeywordTable
    {
        ISqlKeywordTable Add(string name, string group, string text);

        SqlKeyword GetByName(string name);
        SqlKeyword this[string name] { get; }

        SqlKeyword GetByText(string text);


    }
}
