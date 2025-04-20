using Curseddd.Application;
using Curseddd.Infrastructure;
using Curseddd.Presentation;


class Program
{
    static void Main(string[] args)
    {
        var repository = new InMemoryInventoryRepository();
        var service = new InventoryService(repository);
        var ui = new InventoryUI(service);
        ui.Run();
    }
}