namespace Curseddd3.api.console;

using api.facade;

public class ConsoleAdapter
{
    private readonly OrderFacade _facade;
    public ConsoleAdapter(OrderFacade facade) => _facade = facade;

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n--- Система управления заказами (CQRS) ---");
            Console.WriteLine("1. Создать заказ");
            Console.WriteLine("2. Добавить блюдо в заказ");
            Console.WriteLine("3. Изменить заказ");
            Console.WriteLine("4. Отслеживать статус заказа");
            Console.WriteLine("5. Завершить заказ");
            Console.WriteLine("6. История заказов");
            Console.WriteLine("7. Статистика");
            Console.WriteLine("0. Выход");
            Console.Write("Выбор: ");
            var choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "1": _facade.CreateOrder(); break;
                    case "2": _facade.AddItem(); break;
                    case "3": _facade.ChangeOrder(); break;
                    case "4": _facade.ViewStatus(); break;
                    case "5": _facade.CompleteOrder(); break;
                    case "6": _facade.ViewHistory(); break;
                    case "7": _facade.ViewStatistics(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверная опция."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
