namespace Curseddd3.common.myevent;

public class OrderCreatedEvent : IEvent
{
    public Guid OrderId { get; }
    public string Customer { get; }
    public string Status { get; }

    public OrderCreatedEvent(Guid orderId, string customer, string status)
    {
        OrderId = orderId;
        Customer = customer;
        Status = status;
    }
}