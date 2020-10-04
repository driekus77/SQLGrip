using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Core
{
    public class BaseSqlToken
    {
        protected static long Tig { get; set; } = 0;


        public long Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }



        public override string ToString()
        {
            return $"@{Name}";
        }
    }
}
