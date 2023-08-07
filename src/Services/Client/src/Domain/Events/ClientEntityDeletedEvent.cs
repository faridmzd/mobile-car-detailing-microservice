using Client.Domain.Common;
using Client.Domain.Entities;

namespace Client.Domain.Events;

public class ClientEntityDeletedEvent : BaseEvent
{
    public ClientEntityDeletedEvent(ClientEntity entity)
    {
        Entity = entity;
    }

    public ClientEntity Entity { get; }
}
