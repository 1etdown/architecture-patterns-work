namespace Curseddd2.domain.model;

using domain.model;

public class SupplierOrder
{
    public Guid Id { get; } = Guid.NewGuid();
    public List<ProductRequest> Items { get; } = new();
    public OrderStatus Status { get; private set; } = OrderStatus.Created;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? ConfirmedAt { get; private set; }
    public DateTime? ShippedAt { get; private set; }
    public DateTime? ReceivedAt { get; private set; }
    public string? ReturnReason { get; private set; }

    public SupplierOrder(IEnumerable<ProductRequest> items)
    {
        Items.AddRange(items);
    }

    public void Confirm()
    {
        if (Status != OrderStatus.Created)
            throw new InvalidOperationException("Cannot confirm in current state.");
        Status = OrderStatus.Confirmed;
        ConfirmedAt = DateTime.UtcNow;
    }

    public void Ship()
    {
        if (Status != OrderStatus.Confirmed)
            throw new InvalidOperationException("Cannot ship in current state.");
        Status = OrderStatus.Shipped;
        ShippedAt = DateTime.UtcNow;
    }

    public void Receive(bool qualityOk)
    {
        if (Status != OrderStatus.Shipped)
            throw new InvalidOperationException("Cannot receive in current state.");

        if (qualityOk)
        {
            Status = OrderStatus.Received;
            ReceivedAt = DateTime.UtcNow;
        }
        else
        {
            Status = OrderStatus.Returned;
            ReturnReason = "Quality issue";
        }
    }
}
