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
        var cmdRepo = new InMemoryOrderRepository();
        var readRepo = new InMemoryOrderReadRepository();
        EventBus.Subscribe(readRepo);

        _createHandler = new CreateOrderHandler(cmdRepo);
        _addHandler = new AddItemHandler(cmdRepo);
        _changeHandler = new ChangeOrderHandler(cmdRepo);
        _completeHandler = new CompleteOrderHandler(cmdRepo);
        _query = new QueryService(readRepo);
    }

    public void CreateOrder()
    {
        try
        {
            Console.Write("Имя клиента: ");
            var customer = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(customer))
                throw new ArgumentException("Имя клиента не может быть пустым.");

            var cmd = new CreateOrderCommand(customer);
            var id = _createHandler.Handle(cmd);
            Console.WriteLine($"Заказ {id} создан.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании заказа: {ex.Message}");
        }
    }

    public void AddItem()
    {
        try
        {
            Console.Write("ID заказа: ");
            if (!Guid.TryParse(Console.ReadLine(), out var id))
                throw new ArgumentException("Неверный формат ID.");

            Console.Write("Блюдо: ");
            var item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentException("Название блюда не может быть пустым.");

            Console.Write("Кол-во: ");
            if (!int.TryParse(Console.ReadLine(), out var qty) || qty <= 0)
                throw new ArgumentException("Количество должно быть положительным числом.");

            _addHandler.Handle(new AddItemCommand(id, item, qty));
            Console.WriteLine("Блюдо добавлено.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при добавлении блюда: {ex.Message}");
        }
    }

    public void ChangeOrder()
    {
        try
        {
            Console.Write("ID заказа: ");
            if (!Guid.TryParse(Console.ReadLine(), out var id))
                throw new ArgumentException("Неверный формат ID.");

            Console.Write("Новое описание: ");
            var desc = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(desc))
                throw new ArgumentException("Описание не может быть пустым.");

            _changeHandler.Handle(new ChangeOrderCommand(id, desc));
            Console.WriteLine("Заказ изменён.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при изменении заказа: {ex.Message}");
        }
    }

    public void ViewStatus()
    {
        try
        {
            Console.Write("ID заказа: ");
            if (!Guid.TryParse(Console.ReadLine(), out var id))
                throw new ArgumentException("Неверный формат ID.");

            var dto = _query.GetOrderStatus(id);
            Console.WriteLine($"Статус: {dto.Status}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении статуса: {ex.Message}");
        }
    }

    public void CompleteOrder()
    {
        try
        {
            Console.Write("ID заказа: ");
            if (!Guid.TryParse(Console.ReadLine(), out var id))
                throw new ArgumentException("Неверный формат ID.");

            _completeHandler.Handle(new CompleteOrderCommand(id));
            Console.WriteLine("Заказ завершён.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при завершении заказа: {ex.Message}");
        }
    }

    public void ViewHistory()
    {
        try
        {
            var list = _query.GetOrderHistory();
            if (list.Count == 0)
            {
                Console.WriteLine("История заказов пуста.");
                return;
            }

            foreach (var dto in list)
                Console.WriteLine($"{dto.Id}: {dto.Customer}, Статус={dto.Status}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении истории: {ex.Message}");
        }
    }

    public void ViewStatistics()
    {
        try
        {
            var stats = _query.GetStatistics();
            Console.WriteLine($"Всего заказов: {stats.TotalOrders}, Завершённых: {stats.CompletedOrders}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении статистики: {ex.Message}");
        }
    }
}
