namespace Curseddd3.command.command;

public class AddItemCommand
{
    public Guid OrderId { get; }
    public string Item { get; }
    public int Quantity { get; }
    public AddItemCommand(Guid orderId, string item, int qty)
    {
        OrderId = orderId;
        Item    = item;
        Quantity= qty;
    }
}
