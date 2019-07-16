using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{
    /// <summary>
    /// 区别对待==和Equals
    /// CLR将“相等性”分为两类：“值相等性”和“引用相等性”
    /// 无论==还是Equals都倾向于表达这样一个原则：
    /// 1. 对于值类型，如果类型的值相等，就应该返回true。
    /// 2. 对于引用类型，如果类型指向同一个对象，则返回true。
    /// </summary>
    public class _011EqualsAndOPEquals
    {
        public static void ValueTypeOPEquals()
        {
            int i = 1;
            int j = 1;
            Console.WriteLine(i == j);  // true
            j = i;
            Console.WriteLine(i == j);    // true
        }
        public static void ReferenceTypeOPEquals()
        {
            object a = 1;
            object b = 1;
            Console.WriteLine(a == b);  // false
            b = a;
            Console.WriteLine(a == b);  // true
        }
        public static void ValueTypeEquals()
        {
            int i = 1;
            int j = 1;
            Console.WriteLine(i.Equals(j)); // true
            j = i;
            Console.WriteLine(i.Equals(j)); // true
        }
        public static void RefrenceTypeEquals()
        {
            object a = 1;
            object b = 1;
            Console.WriteLine(a.Equals(b)); // true
            b = a;
            Console.WriteLine(a.Equals(b)); // true

            object p1 = new Person("001");
            object p2 = new Person("001");
            Console.WriteLine(p1 == p2);    // false
            Console.WriteLine(p1.Equals(p2));   // false 重写Equals后返回true
            p2 = p1;
            Console.WriteLine(p1.Equals(p2));   // true
        }
    }

    /// <summary>
    /// 对于引用类型，如果我们要定义“值相等性”，应该仅仅去重载Equals方法，同时让“==”表示引用相等性
    /// </summary>
    public class Person
    {
        public string IDCode { get; private set; }
        public Person(string idCode)
        {
            this.IDCode = idCode;
        }
        public override bool Equals(object obj)
        {
            return IDCode == (obj as Person).IDCode;
        }
    }
}
