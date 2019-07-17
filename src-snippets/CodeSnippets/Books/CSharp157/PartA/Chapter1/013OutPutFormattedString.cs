using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{
    public class _013OutPutFormattedString
    {
        public static void Run()
        {
            Person person = new Person("001") { FirstName = "孔明", LastName = "诸葛" };
            Console.WriteLine(person.ToString());
            PersonFormatter personFormatter = new PersonFormatter();
            Console.WriteLine("***************");
            Console.WriteLine(personFormatter.Format("ZH-CN", person, null));
            Console.WriteLine(personFormatter.Format("EN-US", person, null));
            Console.WriteLine(personFormatter.Format(null, person, null));
            Console.WriteLine("***************");
            Console.WriteLine(person.ToString("ZH-CN", null));
            Console.WriteLine(person.ToString("EN-US", null));
            Console.WriteLine(person.ToString(null, null));
        }
    }

    public class PersonFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            Person person = arg as Person;
            if (person == null)
                return string.Empty;
            switch (format?.ToUpper())
            {
                case "ZH-CN":
                    return $"{person.LastName}{person.FirstName}";
                case "EN-US":
                    return $"{person.FirstName}{person.LastName}";
                default:
                    return $"{person.LastName}{person.FirstName}";
            }
        }
    }
}
