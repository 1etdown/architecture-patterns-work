namespace Curseddd3.query.repository;

using query.model;

public interface IOrderReadRepository
{
    void HandleEvent(object ev);
    List<OrderReadModel> GetAll();
    OrderReadModel? Get(Guid id);
}
