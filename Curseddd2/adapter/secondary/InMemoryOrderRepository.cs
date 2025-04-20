using Curseddd2.domain.model;

namespace Curseddd2.adapter.secondary;

using System.Collections.Concurrent;
using domain.port.secondary;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly ConcurrentDictionary<Guid, SupplierOrder> _store = new();

    public void Save(SupplierOrder order) => _store[order.Id] = order;

    public SupplierOrder? Get(Guid id)
        => _store.TryGetValue(id, out var order) ? order : null;
}
