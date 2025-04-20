using Curseddd3.command.model;

namespace Curseddd3.command.repository;


public interface IOrderRepository
{
    void Save(Order order);
    Order? Get(Guid id);
}
