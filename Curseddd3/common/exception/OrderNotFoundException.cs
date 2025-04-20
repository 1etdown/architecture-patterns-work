namespace Curseddd3.common.exception;

public class OrderNotFoundException : Exception
{
    public OrderNotFoundException() : base("Заказ не найден.") { }
}
