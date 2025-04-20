namespace Curseddd2.domain.port.primary;

using domain.model;

public interface IOrderUseCase
{
    Guid CreateOrder(IEnumerable<ProductRequest> forecast);
    void SendOrder(Guid orderId);
    void ConfirmOrder(Guid orderId);
    void ReceiveShipment(Guid orderId);
}
