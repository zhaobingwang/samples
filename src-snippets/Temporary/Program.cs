using CodeSnippets;
using CodeSnippets.BCL;
using System;
using CSTree;
using CSTree.BCLExtensions;
using CodeSnippets.Security;
using CodeSnippets.BCL.System_Net_Http;
using System.Threading.Tasks;
using CodeSnippets.Issues;
using CodeSnippets.CSharp.LINQ;
using CodeSnippets.CSharp;

namespace Temporary
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                OperatorsSnippets.BooleanLogicalOperators();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
