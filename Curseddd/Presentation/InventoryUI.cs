namespace Curseddd.Presentation;

using Application;


public class InventoryUI
{
    private readonly InventoryService _service;

    public InventoryUI(InventoryService service)
    {
        _service = service;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n1. Приёмка продукта\n2. Использование продукта\n3. Удалить просрочку\n4. Провести инвентаризацию\n5. Отчёт по запасам\n6. Критические запасы\n0. Выход");
            Console.Write("Выбор: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Название: ");
                    string name = Console.ReadLine();
                    Console.Write("Кол-во: ");
                    int qty = int.Parse(Console.ReadLine());
                    Console.Write("Годен до (гггг-мм-дд): ");
                    DateTime exp = DateTime.Parse(Console.ReadLine());
                    _service.ReceiveProduct(name, qty, exp);
                    break;

                case "2":
                    Console.Write("Название: ");
                    string nameUse = Console.ReadLine();
                    Console.Write("Кол-во: ");
                    int qtyUse = int.Parse(Console.ReadLine());
                    _service.UseProduct(nameUse, qtyUse);
                    break;

                case "3":
                    _service.RemoveExpired();
                    Console.WriteLine("Просроченные продукты удалены.");
                    break;

                case "4":
                    Console.Write("Название: ");
                    string nameInv = Console.ReadLine();
                    Console.Write("Новое кол-во: ");
                    int newQty = int.Parse(Console.ReadLine());
                    _service.ConductInventory(nameInv, newQty);
                    break;

                case "5":
                    var all = _service.GetAll();
                    Console.WriteLine("Запасы:");
                    foreach (var p in all)
                        Console.WriteLine($"{p.Name} — {p.Quantity} шт. (до {p.ExpirationDate:yyyy-MM-dd})");
                    break;

                case "6":
                    Console.Write("Порог: ");
                    int threshold = int.Parse(Console.ReadLine());
                    var crit = _service.GetCritical(threshold);
                    Console.WriteLine("Критические запасы:");
                    foreach (var p in crit)
                        Console.WriteLine($"{p.Name} — {p.Quantity} шт.");
                    break;

                case "0":
                    return;
            }
        }
    }
}
