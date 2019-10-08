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
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            await UnaryStreamCallExample(client);
            await ServerStreamingCallExample(client);
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

            using (var call = client.SayHellos(new HelloRequest { Name = "张三" }))
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
    }
}
