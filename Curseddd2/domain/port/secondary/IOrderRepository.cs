namespace Curseddd2.domain.port.secondary;

using domain.model;


public interface IOrderRepository
{
    void Save(SupplierOrder order);
    SupplierOrder? Get(Guid id);
}
