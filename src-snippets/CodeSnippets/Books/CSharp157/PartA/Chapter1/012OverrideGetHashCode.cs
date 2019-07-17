using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{
    public class _012OverrideGetHashCode
    {
        static Dictionary<Person, PersonMoreInfo> PersonValues = new Dictionary<Person, PersonMoreInfo>();
        public static void Run()
        {
            AddPerson();
            Person jack = new Person("001");
            Console.WriteLine(jack.GetHashCode());
            Console.WriteLine(PersonValues.ContainsKey(jack));  // false 重写Person中的GetHashCode()后，返回true
        }
        private static void AddPerson()
        {
            Person jack = new Person("001");
            PersonMoreInfo jackInfo = new PersonMoreInfo() { SomeInfo = "Info about jack." };
            PersonValues.Add(jack, jackInfo);
            Console.WriteLine(jack.GetHashCode());
            Console.WriteLine(PersonValues.ContainsKey(jack));  // true
        }
    }

    public class PersonMoreInfo
    {
        public string SomeInfo { get; set; }
    }
}
