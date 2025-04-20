namespace Curseddd2.adapter.primary;


using domain.port.primary;
using domain.model;

public class ConsoleAdapter
{
    private readonly IOrderUseCase _useCase;

    public ConsoleAdapter(IOrderUseCase useCase) => _useCase = useCase;

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n--- Система заказов поставщикам ---");
            Console.WriteLine("1. Создать заказ");
            Console.WriteLine("2. Отправить заказ");
            Console.WriteLine("3. Подтвердить заказ");
            Console.WriteLine("4. Принять поставку");
            Console.WriteLine("0. Выход");
            Console.Write("Выбор: ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Введите позиции (формат: наименование:кол-во, через запятую): ");
                        var input = Console.ReadLine()!;
                        var requests = input
                            .Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Select(pair =>
                            {
                                var a = pair.Split(':');
                                if (a.Length != 2 || !int.TryParse(a[1], out int quantity))
                                    throw new FormatException("Неверный формат ввода.");

                                return new ProductRequest(a[0].Trim(), quantity);
                            });
                        var id = _useCase.CreateOrder(requests);
                        Console.WriteLine($"Заказ {id} создан.");
                        break;

                    case "2":
                        Console.Write("ID заказа: ");
                        _useCase.SendOrder(Guid.Parse(Console.ReadLine()!));
                        Console.WriteLine("Заказ отправлен.");
                        break;

                    case "3":
                        Console.Write("ID заказа: ");
                        _useCase.ConfirmOrder(Guid.Parse(Console.ReadLine()!));
                        Console.WriteLine("Заказ подтверждён.");
                        break;

                    case "4":
                        Console.Write("ID заказа: ");
                        _useCase.ReceiveShipment(Guid.Parse(Console.ReadLine()!));
                        Console.WriteLine("Поставка принята.");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Неверная опция.");
                        break;
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Ошибка ввода: {fe.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
