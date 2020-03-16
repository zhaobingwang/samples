using Grpc.Core;
using Grpc.Net.Client;
using GrpcDemoServices;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static Random RNG = new Random();
        private static readonly TimeSpan RaceDuration = TimeSpan.FromSeconds(1);
        static async Task Main(string[] args)
        {
            // 为客户端配置选项
            // 更多配置见：https://docs.microsoft.com/zh-cn/aspnet/core/grpc/configuration?view=aspnetcore-3.0#configure-client-options
            var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
            {
                MaxReceiveMessageSize = 5 * 1024 * 1024,    // 5MB
                MaxSendMessageSize = 2 * 1024 * 1024    // 2MB
            });


            var clientGreeter = new Greeter.GreeterClient(channel);
            var clientCounter = new Counter.CounterClient(channel);
            //var clientRacer = new Racer.RacerClient(channel);
            var clientAggregator = new Aggregator.AggregatorClient(channel);

            //await UnaryStreamCallExample(clientGreeter);
            //await ServerStreamingCallExample(clientGreeter);
            //await ClientStreamingCallExample(clientCounter);
            //await BidirectionalStreamingExample(clientRacer);
            await AggregatorServerStreamingCallExample(clientAggregator);

            Console.ReadLine();
        }

        #region gRPC的四种调用方式
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

        /// <summary>
        /// 双向流式调用
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private static async Task BidirectionalStreamingExample(Racer.RacerClient client)
        {
            var headers = new Metadata { new Metadata.Entry("race-duration", RaceDuration.ToString()) };

            Console.WriteLine("Ready, set, go!");
            using (var call = client.ReadySetGo(new CallOptions(headers)))
            {

                // Read incoming messages in a background task
                RaceMessage? lastMessageReceived = null;
                var readTask = Task.Run(async () =>
                {
                    await foreach (var message in call.ResponseStream.ReadAllAsync())
                    {
                        lastMessageReceived = message;
                    }
                });

                // Write outgoing messages until timer is complete
                var sw = Stopwatch.StartNew();
                var sent = 0;
                while (sw.Elapsed < RaceDuration)
                {
                    await call.RequestStream.WriteAsync(new RaceMessage { Count = ++sent });
                }

                // Finish call and report results
                await call.RequestStream.CompleteAsync();
                await readTask;

                Console.WriteLine($"Messages sent: {sent}");
                Console.WriteLine($"Messages received: {lastMessageReceived?.Count ?? 0}");
            }
        }
        #endregion

        public static async Task AggregatorServerStreamingCallExample(Aggregator.AggregatorClient client)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(3.0));

            using (var replies = client.SayHellos(new HelloRequest { Name = "张三" }, cancellationToken: cts.Token))
            {
                try
                {
                    await foreach (var reply in replies.ResponseStream.ReadAllAsync())
                    {
                        Console.WriteLine($"Greeting:{reply.Message}");
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
