namespace Curseddd3.common.myevent;

public class ItemAddedEvent : IEvent
{
    public Guid OrderId { get; }
    public string Item { get; }
    public int Quantity { get; }
    public ItemAddedEvent(Guid id, string item, int qty)
    {
        OrderId = id;
        Item = item;
        Quantity = qty;
    }
}
