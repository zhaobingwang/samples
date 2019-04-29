using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.TPL.ConsoleApp
{
    public class TAP
    {
        public void HelloWorld()
        {
            Parallel.Invoke(() => DoSomeWork(), () => DoOtherWork());
        }


        #region private method
        private void DoSomeWork()
        {
            Console.WriteLine($"{nameof(DoOtherWork)}.");
            Thread.Sleep(500);
        }
        private void DoOtherWork()
        {
            Console.WriteLine($"{nameof(DoSomeWork)}.");
            Thread.Sleep(1000);
        }
        #endregion
    }
}
