using CodeSnippets.BCL;
using System;

namespace Temporary
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(default(DateTime).ToString("yyyyMMdd"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
