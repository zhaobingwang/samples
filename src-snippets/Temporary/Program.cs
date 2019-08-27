using CodeSnippets;
using CodeSnippets.Books.CSharp157;
using CodeSnippets.Issues;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using System.Collections.Generic;
using CodeSnippets.CSharp;
using CodeSnippets.Infrastructure;
using CodeSnippets.ThirdParty;

namespace Temporary
{
    class User
    {
        public int Id { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //DapperSample dapperSample = new DapperSample();
                //dapperSample.Insert();
                //dapperSample.GetBlogs();
                Console.WriteLine(DateTimeOffset.Now);
                var aa = 1;
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
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("end");
            }
        }
    }
}
