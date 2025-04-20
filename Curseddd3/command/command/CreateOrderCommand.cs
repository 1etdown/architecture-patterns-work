namespace Curseddd3.command.command;

public class CreateOrderCommand
{
    public Guid OrderId { get; } = Guid.NewGuid();
    public string Customer { get; }
    public CreateOrderCommand(string customer) => Customer = customer;
}
