using Grpc.Core;
using GrpcDemoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class AggregatorService : Aggregator.AggregatorBase
    {
        private readonly Greeter.GreeterClient _greeterClient;
        public AggregatorService(Greeter.GreeterClient greeterClient)
        {
            _greeterClient = greeterClient;
        }

        public override async Task SayHellos(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            // Forward the call on to the greeter service
            using (var call = _greeterClient.SayHellos(request))
            {
                await foreach (var reply in call.ResponseStream.ReadAllAsync())
                {
                    await responseStream.WriteAsync(reply);
                }
            }
        }
    }
}
