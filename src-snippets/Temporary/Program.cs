using CodeSnippets;
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
                var now = DateTime.Now.ToUniversalTime();
                Console.WriteLine(now);
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
