using CodeSnippets;
using CodeSnippets.BCL;
using System;
using CSTree;
using CSTree.BCLExtensions;
using CodeSnippets.Security;
using CodeSnippets.BCL.System_Net_Http;
using System.Threading.Tasks;

namespace Temporary
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                HttpClientSnippets httpClientSnippets = new HttpClientSnippets();
                await httpClientSnippets.GetAsync();
            }
            catch (Exception ex)
            {
                // 
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
