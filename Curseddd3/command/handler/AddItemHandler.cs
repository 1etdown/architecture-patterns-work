using Curseddd3.command.command;
using Curseddd3.command.repository;
using Curseddd3.common.myevent;

namespace Curseddd3.command.handler;

using common.exception;

public class AddItemHandler
{
    private readonly IOrderRepository _repo;
    public AddItemHandler(IOrderRepository repo) => _repo = repo;

    public void Handle(AddItemCommand cmd)
    {
        var order = _repo.Get(cmd.OrderId)
                    ?? throw new OrderNotFoundException();
        order.AddItem(cmd.Item, cmd.Quantity);
        _repo.Save(order);
        EventBus.Publish(new ItemAddedEvent(order.Id, cmd.Item, cmd.Quantity));
    }
}
