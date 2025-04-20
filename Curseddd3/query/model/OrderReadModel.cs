using Curseddd3.common.myevent;

namespace Curseddd3.query.model;


public class OrderReadModel
{
    public Guid Id { get; set; }
    public string Customer { get; set; } = "";
    public string Status { get; set; } = "";
    public string Description { get; set; } = "";

    public void On(OrderCreatedEvent e)
    {
        Id = e.OrderId;
        Customer = e.Customer;
        Status = "Created";
    }
    public void On(ItemAddedEvent e) { /* ничего не меняется */ }
    public void On(OrderChangedEvent e) => Description = e.NewDescription;
    public void On(OrderCompletedEvent e)  => Status = "Completed";
}
