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
                var json = Json.Serialize();
                Console.WriteLine(json);
                var summary = Json.GetSummary();
                Console.WriteLine(summary);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
