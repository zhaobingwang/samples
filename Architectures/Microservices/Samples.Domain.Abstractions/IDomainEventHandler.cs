using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.Domain.Abstractions
{
    public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
    }
}
