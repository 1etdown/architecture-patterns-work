namespace Curseddd3.command.model;

using common.exception;

public class Order
{
    public Guid Id { get; }
    public string Customer { get; private set; }
    public List<OrderItem> Items { get; } = new();
    public string Description { get; private set; } = string.Empty;
    public bool IsCompleted { get; private set; }

    public Order(Guid id, string customer)
    {
        Id = id;
        Customer = customer;
    }

    public void AddItem(string name, int qty)
    {
        if (IsCompleted) throw new InvalidOrderOperationException();
        Items.Add(new OrderItem(name, qty));
    }

    public void ChangeDescription(string desc)
    {
        if (IsCompleted) throw new InvalidOrderOperationException();
        Description = desc;
    }

    public void Complete()
    {
        if (IsCompleted) throw new InvalidOrderOperationException();
        IsCompleted = true;
    }
}
