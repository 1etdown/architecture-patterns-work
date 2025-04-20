namespace Curseddd2.domain.port.secondary;

using domain.model;


public interface ISupplierClient
{
    void SendOrder(SupplierOrder order);
    bool GetConfirmation(Guid orderId);
}
