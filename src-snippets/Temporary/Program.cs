using CodeSnippets;
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
                Unclassified.RangesAndIndices();
            }
            catch (Exception ex)
            {
                // 
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
