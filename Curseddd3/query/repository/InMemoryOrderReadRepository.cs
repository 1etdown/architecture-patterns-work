using Curseddd3.common.myevent;
using Curseddd3.query.dto;
using System.Collections.Concurrent;
using Curseddd3.query.model;

namespace Curseddd3.query.repository;

public class InMemoryOrderReadRepository : IOrderReadRepository
{
    private readonly ConcurrentDictionary<Guid, OrderReadModel> _store = new();

    public InMemoryOrderReadRepository() => EventBus.Subscribe(this);

    public void HandleEvent(object ev)
    {
        switch (ev)
        {
            case OrderCreatedEvent e:
                var m = new OrderReadModel();
                m.On(e);
                _store[e.OrderId] = m;
                break;

            case ItemAddedEvent _: // исправлено
                // не обрабатываем
                break;

            case OrderChangedEvent e when _store.TryGetValue(e.OrderId, out var om):
                om.On(e);
                break;

            case OrderCompletedEvent e when _store.TryGetValue(e.OrderId, out var cm):
                cm.On(e);
                break;
        }
    }

    public List<OrderReadModel> GetAll() => _store.Values.ToList();
    public OrderReadModel? Get(Guid id) => _store.TryGetValue(id, out var m) ? m : null;
}