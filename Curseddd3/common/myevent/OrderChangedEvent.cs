namespace Curseddd3.common.myevent;

public class OrderChangedEvent : IEvent
{
    public Guid OrderId { get; }
    public string NewDescription { get; }
    public OrderChangedEvent(Guid id, string desc)
    {
        OrderId = id;
        NewDescription = desc;
    }
}
