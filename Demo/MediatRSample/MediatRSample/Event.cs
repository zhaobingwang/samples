using MediatR;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRSample
{
    public class Ping : INotification
    {
    }
    public class Pong1 : INotificationHandler<Ping>
    {
        public Task Handle(Ping notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Pong 1");
            return Task.CompletedTask;
        }
    }

    public class Pong2 : INotificationHandler<Ping>
    {
        public Task Handle(Ping notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Pong 2");
            return Task.CompletedTask;
        }
    }

    public class Calculator : IRequest<double>
    {
        public string Operator { get; set; } = "+";
        public double Num1 { get; set; }
        public double Num2 { get; set; }
    }

    public class CalculatorHandler : IRequestHandler<Calculator, double>
    {
        public Task<double> Handle(Calculator request, CancellationToken cancellationToken)
        {
            double result = 0;
            switch (request.Operator)
            {
                case "+":
                    result = request.Num1 + request.Num2;
                    break;
                default:
                    break;
            }
            return Task.FromResult(result);
        }
    }
}
