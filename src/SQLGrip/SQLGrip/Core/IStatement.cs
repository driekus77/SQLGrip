using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Core
{
    public interface IStatement
    {
        Language Language { get; }

        string Text { get;  }


        IStatement Parse();




    }
}
