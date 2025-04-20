using Curseddd3.command.command;
using Curseddd3.command.repository;
using Curseddd3.common.myevent;

namespace Curseddd3.command.handler;


using common.exception;

public class CompleteOrderHandler
{
    private readonly IOrderRepository _repo;
    public CompleteOrderHandler(IOrderRepository repo) => _repo = repo;

    public void Handle(CompleteOrderCommand cmd)
    {
        var order = _repo.Get(cmd.OrderId)
                    ?? throw new OrderNotFoundException();
        order.Complete();
        _repo.Save(order);
        EventBus.Publish(new OrderCompletedEvent(order.Id));
    }
}
