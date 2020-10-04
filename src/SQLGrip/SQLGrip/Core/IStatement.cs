using System;
using System.Collections.Generic;
using System.Text;
using SQLGrip.Tree.Nodes.Statements;

namespace SQLGrip.Core
{
    public interface IStatement
    {
        ISqlStatementNode ParsedNode {get;}

        Language Language { get; }

        string Text { get;  }


        IStatement Parse();




    }
}
