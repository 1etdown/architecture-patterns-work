namespace Curseddd3.command.model;

public class OrderItem
{
    public string Name { get; }
    public int Quantity { get; }
    public OrderItem(string name, int qty)
    {
        Name = name;
        Quantity = qty;
    }
}
