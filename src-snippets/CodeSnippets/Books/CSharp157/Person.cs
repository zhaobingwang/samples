using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{

    public class Person : IEquatable<Person>, IFormattable
    {
        public string IDCode { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person(string idCode)
        {
            this.IDCode = idCode;
        }
        public override bool Equals(object obj)
        {
            return IDCode == (obj as Person).IDCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IDCode);
        }

        public bool Equals(Person other)
        {
            return IDCode == other.IDCode;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format?.ToUpper())
            {
                case "ZH-CN":
                    return this.ToString();
                case "EN-US":
                    return $"{FirstName}{LastName}";
                default:
                    ICustomFormatter customFormatter = formatProvider as ICustomFormatter;
                    if (customFormatter == null)
                        return this.ToString();
                    return customFormatter.Format(format, this, null);
            }
        }

        public override string ToString()
        {
            return $"{LastName}{FirstName}";
        }
    }
}
