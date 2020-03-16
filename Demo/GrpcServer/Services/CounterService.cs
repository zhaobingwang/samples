using Grpc.Core;
using GrpcDemoServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class CounterService : Counter.CounterBase
    {
        private readonly ILogger _logger;
        private readonly IncrementingCounter _counter;

        public CounterService(IncrementingCounter counter, ILoggerFactory loggerFactory)
        {
            _counter = counter;
            _logger = loggerFactory.CreateLogger<CounterService>();
        }

        public override async Task<CounterReply> AccumulateCount(IAsyncStreamReader<CounterRequest> requestStream, ServerCallContext context)
        {
            await foreach (var request in requestStream.ReadAllAsync())
            {
                _logger.LogInformation($"Incrementing count by {request.Count}");
                _counter.Increment(request.Count);
            }
            return new CounterReply { Count = _counter.Count };
        }
    }
}
