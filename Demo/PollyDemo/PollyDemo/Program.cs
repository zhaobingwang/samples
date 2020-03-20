using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Polly;

namespace PollyDemo
{
    class Program
    {
        /*
         * Polly Official Site：http://www.thepollyproject.org/
         * Polly Github Repository: https://github.com/App-vNext/Polly 
         */

        // Step 1 : Specify the exceptions/faults you want the policy to handle
        // Policy.Handle<HttpRequestException>

        // Step 1b: (optionally) Specify return results you want to handle
        // Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.NotFound)

        // Step 2 : Specify how the policy should handle those faults

        static async Task Main(string[] args)
        {
            Console.WriteLine("开始执行");
            try
            {
                Fallback();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(Main)}发生异常：{ex.Message}");
            }
            finally
            {
                Console.WriteLine("执行结束");
            }
        }

        #region 重试策略
        private static async Task RetryOnce()
        {
            var policy = Policy.Handle<CustomException>()
                .Retry(3);
            await policy.Execute(() => FooFunction());
        }
        private static async Task RetryMany()
        {
            var policy = Policy.Handle<CustomException>()
                .Retry(3);
            await policy.Execute(() => FooFunction());
        }

        private static async Task RetryForeverUntilSuccess()
        {
            var policy = Policy.Handle<CustomException>()
                .RetryForever();
            await policy.Execute(() => FooFunction());
        }

        private static async Task RetryAfterWait()
        {
            var policy = Policy.Handle<CustomException>()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(4)
                });
            await policy.ExecuteAsync(() => FooFunction());
        }

        private static async Task RetryForeverUntilSuccessAfterWait()
        {
            var policy = Policy.Handle<CustomException>()
                .WaitAndRetryForeverAsync(retryAttempt =>
                TimeSpan.FromSeconds(1));
            await policy.ExecuteAsync(() => FooFunction());
        }

        private static async Task RetryManyWithCustomLogic()
        {
            var policy = Policy.Handle<CustomException>()
                .Retry(3, onRetry: (exception, retryCount) =>
                {
                    Console.WriteLine($"{nameof(RetryManyWithCustomLogic)},第{retryCount}重试：{exception.Message}");
                });
            await policy.Execute(() => FooFunction());
        }
        #endregion

        #region 熔断策略
        public static async Task CircuitBreaker()
        {
            // 熔断策略：如果连续3次出发了CustomException异常，将在2秒内终止所有请求
            var policy = Policy.Handle<CustomException>()
                .CircuitBreaker(3, TimeSpan.FromSeconds(2));
            for (int i = 0; i < 10; i++)    // 模拟10次调用
            {
                try
                {
                    await policy.Execute(() => FooFunction());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    await Task.Delay(1000);
                }
            }
        }
        #endregion

        #region 回退
        public static void Fallback()
        {
            var policy = Policy.Handle<CustomException>()
                .Fallback(async () => FunctionFallback());
            policy.Execute(() => Function());
        }
        #endregion

        static int ctr = 0;
        static Task FooFunction()
        {
            ctr++;
            if (ctr >= 11)  // 假设重试10次执行成功
            {
                return Task.CompletedTask;
            }
            Console.WriteLine($"{DateTime.Now:HH:mm:ss fff} {nameof(FooFunction)}:第{ctr}次执行");
            throw new CustomException($"{nameof(FooFunction)}发生异常");
        }


        static void Function()
        {
            try
            {
                throw new CustomException($"{nameof(Function)}发生异常");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"执行{nameof(Function)}发生异常：{ex.Message}");
                throw;
            }
        }

        static void FunctionFallback()
        {
            Console.WriteLine($"执行{nameof(FunctionFallback)}");
        }
    }
    class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }
    }
}
