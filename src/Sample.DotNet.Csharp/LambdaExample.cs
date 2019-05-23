using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DotNet.Csharp
{
    /// <summary>
    /// 参见：https://www.cnblogs.com/jesse2013/p/happylambda.html#b01
    /// http://www.cnblogs.com/jesse2013/p/happylambda-part2.html
    /// </summary>
    public class LambdaExample
    {
        public void HelloWorld()
        {
            Action dummyLambda = () => { Console.WriteLine("Hello World from a Lambda expression!"); };
            var result1 = dummyLambda;
            result1();  // output:Hello World from a Lambda expression!

            Func<double, double> square = x => x * x;
            var result2 = square(10);
            Console.WriteLine(result2); // output:100

            Func<double, double, double> product = (x, y) => x * y;
            var result3 = product(3, 4);
            Console.WriteLine(result3); // output:12

            Action<double, double> printProduct = (x, y) => { Console.WriteLine(x * y); };
            var result4 = printProduct;
            result4(5, 6);  // output:30

            Func<double[], double[], double> dotProduct = (x, y) =>
            {
                var dim = Math.Min(x.Length, y.Length);
                var sum = 0.0;
                for (int i = 0; i < dim; i++)
                {
                    sum += x[i] + y[i];
                }
                return sum;
            };
            var result5 = dotProduct(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 });
            Console.WriteLine(result5); // output:21

            Func<string, Task<int>> getContentLengthAsync = async (requestUri) =>
             {
                 HttpClient httpClient = new HttpClient();
                 var result = await httpClient.GetStringAsync(requestUri);
                 return result.Length;
             };
            var result6 = getContentLengthAsync("https://docs.microsoft.com/zh-cn/");
            Console.WriteLine(result6.Result);
        }

        /// <summary>
        /// 闭包
        /// </summary>
        public void Closure()
        {
            List<Func<int>> funcs = new List<Func<int>>();
            for (int i = 0; i < 10; i++)
            {
                int index = i;
                //funcs.Add(() => i);
                funcs.Add(() => index);
            }

            foreach (var item in funcs)
            {
                Console.WriteLine(item());
            }
        }

        public void PrintNumber()
        {
            Console.WriteLine("start print");
            DoSomeStuff(() =>
            {
                Console.WriteLine("print finish.you can do something here");
            });
        }

        void DoSomeStuff(Action callback)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            callback();
        }


    }

    /// <summary>
    /// 返回方法
    /// </summary>
    public class ExcuteFunction
    {
        readonly Dictionary<int, Func<string, string>> excuteFunctions = new Dictionary<int, Func<string, string>>();
        public ExcuteFunction()
        {
            excuteFunctions.Add(1, reqeust => Func1(reqeust));
            excuteFunctions.Add(2, reqeust => Func2(reqeust));
            excuteFunctions.Add(3, reqeust => Func3(reqeust));
            //for (int i = 4; i <= 1000*1000; i++)
            //{
            //    excuteFunctions.Add(i, reqeust => Func1(reqeust));
            //}
        }

        public Func<string, string> Excute(int op)
        {
            return excuteFunctions[op];
        }

        string Func1(string reqeust)
        {
            return $"request params is {reqeust},response from {nameof(Func1)}";
        }
        string Func2(string reqeust)
        {
            return $"request params is {reqeust},response from {nameof(Func2)}";
        }
        string Func3(string reqeust)
        {
            return $"request params is {reqeust},response from {nameof(Func3)}";
        }
    }
}
