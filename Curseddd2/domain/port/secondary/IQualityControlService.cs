namespace Curseddd2.domain.port.secondary;

using domain.model;

public interface IQualityControlService
{
    bool Inspect(SupplierOrder order);
}
