using System;

namespace SQLGrip
{

    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    public class TokenAttribute : Superpower.Display.TokenAttribute
    {
        public string Text { get; set; }

    }

}
