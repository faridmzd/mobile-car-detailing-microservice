using Client.Domain.Common;
using Client.Domain.Entities;

namespace Client.Domain.Events;

public class CustomerDeletedEvent : BaseEvent
{
    public CustomerDeletedEvent(Customer entity)
    {
        Entity = entity;
    }

    public Customer Entity { get; }
}
