using Curseddd3.command.model;
using Curseddd3.common.myevent;
using Curseddd3.query.dto;

namespace Curseddd3.command.repository;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, Order> _orders = new();

    public void Save(Order order)
    {
        _orders[order.Id] = order;
    }

    public Order? Get(Guid id)
    {
        _orders.TryGetValue(id, out var order);
        return order;
    }
  

}
