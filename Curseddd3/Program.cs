using Curseddd3.api.facade;

class Program
{
    static void Main()
    {
        var facade = new OrderFacade();

        while (true)
        {
            Console.WriteLine("\n1. Новый заказ\n2. Добавить блюдо\n3. Изменить заказ\n4. Завершить заказ\n5. Статус\n6. История\n7. Статистика\n0. Выход");
            Console.Write("Выбор: ");
            var key = Console.ReadLine();

            switch (key)
            {
                case "1": facade.CreateOrder(); break;
                case "2": facade.AddItem(); break;
                case "3": facade.ChangeOrder(); break;
                case "4": facade.CompleteOrder(); break;
                case "5": facade.ViewStatus(); break;
                case "6": facade.ViewHistory(); break;
                case "7": facade.ViewStatistics(); break;
                case "0": return;
                default: Console.WriteLine("Неверный выбор."); break;
            }
        }
    }
}