using Client.Domain.Common;
using Client.Domain.Entities;

namespace Client.Domain.Events;

public class ClientEntityCreatedEvent : BaseEvent
{
    public ClientEntityCreatedEvent(ClientEntity entity)
    {
        Entity = entity;
    }

    public ClientEntity Entity { get; }
}
