namespace Curseddd3.common.myevent;

public class OrderCompletedEvent : IEvent
{
    public Guid OrderId { get; }
    public OrderCompletedEvent(Guid id) => OrderId = id;
}
