using Curseddd3.common.myevent;

namespace Curseddd3.api.facade;

using command.command;
using command.handler;
using command.repository;
using query.service;
using query.repository;

public class OrderFacade
{
    private readonly CreateOrderHandler _createHandler;
    private readonly AddItemHandler _addHandler;
    private readonly ChangeOrderHandler _changeHandler;
    private readonly CompleteOrderHandler _completeHandler;
    private readonly QueryService _query;

    public OrderFacade()
    {
        var cmdRepo  = new InMemoryOrderRepository();
        var readRepo = new InMemoryOrderReadRepository();
        EventBus.Subscribe(readRepo);

        _createHandler   = new CreateOrderHandler(cmdRepo);
        _addHandler      = new AddItemHandler(cmdRepo);
        _changeHandler   = new ChangeOrderHandler(cmdRepo);
        _completeHandler = new CompleteOrderHandler(cmdRepo);
        _query           = new QueryService(readRepo);
    }

    public void CreateOrder()
    {
        Console.Write("Имя клиента: ");
        var customer = Console.ReadLine()!;
        var cmd = new CreateOrderCommand(customer);
        var id = _createHandler.Handle(cmd);
        Console.WriteLine($"Заказ {id} создан.");
    }

    public void AddItem()
    {
        Console.Write("ID заказа: "); var id = Guid.Parse(Console.ReadLine()!);
        Console.Write("Блюдо: ");     var item = Console.ReadLine()!;
        Console.Write("Кол-во: ");     var qty = int.Parse(Console.ReadLine()!);
        _addHandler.Handle(new AddItemCommand(id, item, qty));
        Console.WriteLine("Блюдо добавлено.");
    }

    public void ChangeOrder()
    {
        Console.Write("ID заказа: ");         var id   = Guid.Parse(Console.ReadLine()!);
        Console.Write("Новое описание: ");    var desc = Console.ReadLine()!;
        _changeHandler.Handle(new ChangeOrderCommand(id, desc));
        Console.WriteLine("Заказ изменён.");
    }

    public void ViewStatus()
    {
        Console.Write("ID заказа: "); var id = Guid.Parse(Console.ReadLine()!);
        var dto = _query.GetOrderStatus(id);
        Console.WriteLine($"Статус: {dto.Status}");
    }

    public void CompleteOrder()
    {
        Console.Write("ID заказа: "); var id = Guid.Parse(Console.ReadLine()!);
        _completeHandler.Handle(new CompleteOrderCommand(id));
        Console.WriteLine("Заказ завершён.");
    }

    public void ViewHistory()
    {
        var list = _query.GetOrderHistory();
        foreach (var dto in list)
            Console.WriteLine($"{dto.Id}: {dto.Customer}, Статус={dto.Status}");
    }

    public void ViewStatistics()
    {
        var stats = _query.GetStatistics();
        Console.WriteLine($"Всего заказов: {stats.TotalOrders}, Завершённых: {stats.CompletedOrders}");
    }
}
