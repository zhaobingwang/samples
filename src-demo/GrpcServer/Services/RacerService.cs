using Grpc.Core;
using GrpcDemoServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class RacerService : Racer.RacerBase
    {
        public override async Task ReadySetGo(IAsyncStreamReader<RaceMessage> requestStream, IServerStreamWriter<RaceMessage> responseStream, ServerCallContext context)
        {
            var raceDuration = TimeSpan.Parse(context.RequestHeaders.Single(h => h.Key == "race-duration").Value);

            // Read incoming messages in a background task
            RaceMessage? lastMessageReceived = null;
            var readTask = Task.Run(async () =>
            {
                await foreach (var message in requestStream.ReadAllAsync())
                {
                    lastMessageReceived = message;
                }
            });

            // Write outgoing messages until timer is complete
            var sw = Stopwatch.StartNew();
            var sent = 0;
            while (sw.Elapsed < raceDuration)
            {
                await responseStream.WriteAsync(new RaceMessage { Count = ++sent });
            }

            await readTask;
        }
    }
}