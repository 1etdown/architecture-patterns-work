using Curseddd3.command.command;
using Curseddd3.command.repository;
using Curseddd3.common.myevent;

namespace Curseddd3.command.handler;

using common.exception;

public class ChangeOrderHandler
{
    private readonly IOrderRepository _repo;
    public ChangeOrderHandler(IOrderRepository repo) => _repo = repo;

    public void Handle(ChangeOrderCommand cmd)
    {
        var order = _repo.Get(cmd.OrderId)
                    ?? throw new OrderNotFoundException();
        order.ChangeDescription(cmd.NewDescription);
        _repo.Save(order);
        EventBus.Publish(new OrderChangedEvent(order.Id, cmd.NewDescription));
    }
}
