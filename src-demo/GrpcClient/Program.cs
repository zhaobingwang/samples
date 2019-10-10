using Grpc.Core;
using Grpc.Net.Client;
using GrpcDemoServices;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static Random RNG = new Random();
        static async Task Main(string[] args)
        {
            //var channelGreeter = GrpcChannel.ForAddress("https://localhost:5001");
            //var clientGreeter = new Greeter.GreeterClient(channelGreeter);

            var channelCounter = GrpcChannel.ForAddress("https://localhost:5001");
            var clientCounter = new Counter.CounterClient(channelCounter);

            //await UnaryStreamCallExample(clientGreeter);
            //await ServerStreamingCallExample(clientGreeter);
            await ClientStreamingCallExample(clientCounter);

            Console.Read();
        }

        /// <summary>
        /// 一元调用
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private static async Task UnaryStreamCallExample(Greeter.GreeterClient client)
        {
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "张三" });
            Console.WriteLine(reply.Message);
        }

        /// <summary>
        /// 服务端流式调用
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private static async Task ServerStreamingCallExample(Greeter.GreeterClient client)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(3.0));

            using (var call = client.SayHellos(new HelloRequest { Name = "张三" }, cancellationToken: cts.Token))
            {
                try
                {
                    await foreach (var response in call.ResponseStream.ReadAllAsync())
                    {
                        Console.WriteLine($"reply:{response.Message}");
                    }
                }
                catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled)
                {
                    Console.WriteLine("Stream cancelled.");
                }
            }
        }

        /// <summary>
        /// 客户端流式调用
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private static async Task ClientStreamingCallExample(Counter.CounterClient client)
        {
            using (var call = client.AccumulateCount())
            {
                for (int i = 0; i < 3; i++)
                {
                    var count = RNG.Next(5);
                    Console.WriteLine($"Accumulating with {count}");
                    await call.RequestStream.WriteAsync(new CounterRequest { Count = count });
                    await Task.Delay(2000);
                }
                await call.RequestStream.CompleteAsync();

                var response = await call;
                Console.WriteLine($"Count:{response.Count}");
            }
        }
    }
}
