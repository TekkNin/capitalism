using System;

namespace Capitalism.SharedKernel.Events
{
    public interface IDomainEvent
    {
        string EventType { get; }
        DateTime DateTimeEventOccurred { get; }
    }
}
