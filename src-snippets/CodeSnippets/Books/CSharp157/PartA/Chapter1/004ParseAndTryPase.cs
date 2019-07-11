using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{
    public class _004ParseAndTryPase
    {
        public static int ParseSample(string str)
        {
            return int.Parse(str);
        }

        public static int TryParseSample(string str)
        {
            int.TryParse(str, out int result);
            return result;
        }
    }
}
