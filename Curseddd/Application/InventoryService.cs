namespace Curseddd.Application;

using Domain.Interfaces;
using Domain.Models;

public class InventoryService
{
    private readonly IInventoryRepository _repository;

    public InventoryService(IInventoryRepository repository)
    {
        _repository = repository;
    }

    public void ReceiveProduct(string name, int quantity, DateTime expiration)
    {
        _repository.AddProduct(new Product { Name = name, Quantity = quantity, ExpirationDate = expiration });
    }

    public void UseProduct(string name, int quantity)
    {
        _repository.RemoveProduct(name, quantity);
    }

    public void RemoveExpired()
    {
        _repository.RemoveExpiredProducts();
    }

    public void ConductInventory(string name, int newQuantity)
    {
        _repository.AdjustQuantity(name, newQuantity);
    }

    public List<Product> GetAll() => _repository.GetAllProducts();

    public List<Product> GetCritical(int threshold) => _repository.GetCriticalProducts(threshold);
}
