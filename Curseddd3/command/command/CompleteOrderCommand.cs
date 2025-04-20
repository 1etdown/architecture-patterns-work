namespace Curseddd3.command.command;

public class CompleteOrderCommand
{
    public Guid OrderId { get; }
    public CompleteOrderCommand(Guid id) => OrderId = id;
}
