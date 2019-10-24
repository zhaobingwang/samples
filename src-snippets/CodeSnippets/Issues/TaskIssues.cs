using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Issues
{
    public class TaskIssues
    {
        public async static void ExceptionHandling()
        {
            var task = new Task(() =>
            {
                throw new Exception("test exception");
            });
            try
            {
                task.Start();
                await task;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
