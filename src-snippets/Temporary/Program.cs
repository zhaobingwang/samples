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
                int[] array = new[] { 1, 2, 3 };
                //ExceptionOperation.TestThrow();
                ExceptionOperation.GetInt(array, 3);
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
        }
    }
}
