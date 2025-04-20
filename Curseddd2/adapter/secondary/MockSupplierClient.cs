using Curseddd2.domain.model;

namespace Curseddd2.adapter.secondary;

using domain.port.secondary;


public class MockSupplierClient : ISupplierClient
{
    public void SendOrder(SupplierOrder order)
        => Console.WriteLine($"[SupplierClient] Order {order.Id} sent.");

    public bool GetConfirmation(Guid orderId)
    {
        Console.WriteLine($"[SupplierClient] Confirmation received for {orderId}.");
        return true;
    }
}
