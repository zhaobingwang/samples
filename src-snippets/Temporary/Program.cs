using CodeSnippets;
using CodeSnippets.Books.CSharp157;
using CodeSnippets.Issues;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Temporary
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                _010Comparer.CompareTemperatures();
            }
            catch (CustomException ex)
            {
                Console.WriteLine(ex);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
