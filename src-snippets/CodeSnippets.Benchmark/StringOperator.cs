using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Benchmark
{
    public class StringOperator
    {
        public const string val = "*";
        private readonly int _loopCount;
        public StringOperator(int loopCount = 100000)
        {
            _loopCount = loopCount;
        }
        public string FoamatLongString()
        {
            string result = string.Empty;
            for (int i = 0; i < _loopCount; i++)
            {
                result = string.Format("{0}{1}", result, val);
            }
            return result;
        }

        public string FoamatShortString()
        {
            string result = string.Empty;
            for (int i = 0; i < _loopCount; i++)
            {
                result = string.Format("val:{0}", val);
            }
            return result;
        }

        public string InterpolationLongString()
        {
            string result = string.Empty;
            for (int i = 0; i < _loopCount; i++)
            {
                result = $"{result}{val}";
            }
            return result;
        }

        public string InterpolationShortString()
        {
            string result = string.Empty;
            for (int i = 0; i < _loopCount; i++)
            {
                result = $"val:{val}"; ;
            }
            return result;
        }

        public string StringBuilder()
        {
            string result = string.Empty;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _loopCount; i++)
            {
                sb.Append(val);
            }
            return sb.ToString();
        }
    }
}
