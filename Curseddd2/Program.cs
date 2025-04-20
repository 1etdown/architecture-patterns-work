using Curseddd2.adapter.primary;
using Curseddd2.adapter.secondary;
using Curseddd2.domain.port.primary;
using Curseddd2.domain.service;


class Program
{
    static void Main()
    {
        IOrderUseCase useCase = new OrderService(
            new InMemoryOrderRepository(),
            new MockSupplierClient(),
            new MockQualityControlService()
        );

        var ui = new ConsoleAdapter(useCase);
        ui.Run();
    }
}