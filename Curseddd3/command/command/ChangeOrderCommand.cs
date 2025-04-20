namespace Curseddd3.command.command;

public class ChangeOrderCommand
{
    public Guid OrderId { get; }
    public string NewDescription { get; }
    public ChangeOrderCommand(Guid id, string desc)
    {
        OrderId        = id;
        NewDescription = desc;
    }
}
