using Client.Domain.Common;
using Client.Domain.Entities;

namespace Client.Domain.Events;

public class CustomerCreatedEvent : BaseEvent
{
    public CustomerCreatedEvent(Customer entity)
    {
        Entity = entity;
    }

    public Customer Entity { get; }
}
