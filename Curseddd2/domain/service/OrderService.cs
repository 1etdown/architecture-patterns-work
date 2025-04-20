namespace Curseddd2.domain.service;

using model;
using port.primary;
using port.secondary;

public class OrderService : IOrderUseCase
{
    private readonly IOrderRepository _repo;
    private readonly ISupplierClient _client;
    private readonly IQualityControlService _qc;

    public OrderService(
        IOrderRepository repo,
        ISupplierClient client,
        IQualityControlService qc)
    {
        _repo = repo;
        _client = client;
        _qc = qc;
    }

    public Guid CreateOrder(IEnumerable<ProductRequest> forecast)
    {
        var order = new SupplierOrder(forecast);
        _repo.Save(order);
        return order.Id;
    }

    public void SendOrder(Guid orderId)
    {
        var order = _repo.Get(orderId) ?? throw new KeyNotFoundException();
        _client.SendOrder(order);
        _repo.Save(order);
    }

    public void ConfirmOrder(Guid orderId)
    {
        var order = _repo.Get(orderId) ?? throw new KeyNotFoundException();
        if (_client.GetConfirmation(orderId))
        {
            order.Confirm();
            _repo.Save(order);
        }
    }

    public void ReceiveShipment(Guid orderId)
    {
        var order = _repo.Get(orderId) ?? throw new KeyNotFoundException();
        order.Ship();
        _repo.Save(order);

        var ok = _qc.Inspect(order);
        order.Receive(ok);
        _repo.Save(order);
    }
}
