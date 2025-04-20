namespace Curseddd3.common.myevent;

public class OrderCreatedEvent : IEvent
{
    public Guid OrderId { get; }
    public string Customer { get; }
    public OrderCreatedEvent(Guid id, string customer)
    {
        OrderId = id;
        Customer = customer;
    }
}
