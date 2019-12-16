using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeSnippets
{
    public class RegexSnippets
    {
        public static bool IsMatch(string source, string pattern)
        {
            return Regex.IsMatch(source, pattern);
        }

        public static string Match(string source, string pattern)
        {
            return Regex.Match(source, pattern).Value;
        }
    }
}
