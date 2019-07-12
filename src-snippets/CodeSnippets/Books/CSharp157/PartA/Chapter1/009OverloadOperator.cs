using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{
    public class _009OverloadOperator
    {
    }
    public class Salary
    {
        public int RMB { get; set; }
        public static Salary operator +(Salary s1, Salary s2)
        {
            Salary salary = new Salary();
            salary.RMB = s1.RMB + s2.RMB;
            return salary;
        }
    }
}
