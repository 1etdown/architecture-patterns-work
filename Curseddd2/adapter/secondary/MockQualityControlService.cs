using Curseddd2.domain.model;

namespace Curseddd2.adapter.secondary;

using domain.port.secondary;

public class MockQualityControlService : IQualityControlService
{
    public bool Inspect(SupplierOrder order)
    {
        Console.WriteLine($"[QualityControl] Inspecting order {order.Id}... OK.");
        return true;
    }
}

