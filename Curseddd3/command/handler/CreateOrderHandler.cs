using Curseddd3.command.command;
using Curseddd3.command.model;
using Curseddd3.command.repository;
using Curseddd3.common.myevent;

namespace Curseddd3.command.handler;



public class CreateOrderHandler
{
    private readonly IOrderRepository _repo;
    public CreateOrderHandler(IOrderRepository repo) => _repo = repo;

    public Guid Handle(CreateOrderCommand cmd)
    {
        var order = new Order(cmd.OrderId, cmd.Customer);
        _repo.Save(order);
        EventBus.Publish(new OrderCreatedEvent(order.Id, order.Customer, order.Status));

        return order.Id;
    }
}
