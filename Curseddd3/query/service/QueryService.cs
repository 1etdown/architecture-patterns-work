namespace Curseddd3.query.service;

using query.dto;
using query.repository;

public class QueryService
{
    private readonly IOrderReadRepository _readRepo;
    public QueryService(IOrderReadRepository repo) => _readRepo = repo;

    public OrderDto GetOrderStatus(Guid id)
    {
        var m = _readRepo.Get(id) ?? throw new KeyNotFoundException();
        return new OrderDto(m.Id, m.Customer, m.Status, m.Description);
    }

    public List<OrderHistoryDto> GetOrderHistory()
        => _readRepo.GetAll()
            .Select(m => new OrderHistoryDto(m.Id, m.Customer, m.Status))
            .ToList();

    public StatisticsDto GetStatistics()
    {
        var all = _readRepo.GetAll();
        return new StatisticsDto(all.Count,
            all.Count(m => m.Status == "Completed"));
    }
}
