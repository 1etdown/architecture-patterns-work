namespace Curseddd3.common.exception;

public class InvalidOrderOperationException : Exception
{
    public InvalidOrderOperationException()
        : base("Невозможная операция для этого заказа.") { }
}
