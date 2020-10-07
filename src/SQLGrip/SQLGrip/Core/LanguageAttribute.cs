using System;

namespace SQLGrip
{

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Class, Inherited = false)]
    public class LanguageAttribute : Attribute
    {
        public string Name { get; set; }

        public string Dialect { get; set; }

        public string Version { get; set; }

        public string Subject { get; set; }


        public  LanguageAttribute(string name, string dialect, string version, string subject = "general" )
        {
            this.Name = name;
            this.Dialect = dialect;
            this.Version = version;
            this.Subject = subject;
        }
    }

}
