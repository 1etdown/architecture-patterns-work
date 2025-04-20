namespace Curseddd.Infrastructure;

using Domain.Interfaces;
using Domain.Models;


public class InMemoryInventoryRepository : IInventoryRepository
{
    private readonly List<Product> _products = new();

    public void AddProduct(Product product)
    {
        var existing = _products.FirstOrDefault(p => p.Name == product.Name);
        if (existing != null)
            existing.Quantity += product.Quantity;
        else
            _products.Add(product);
    }

    public void RemoveProduct(string name, int quantity)
    {
        var product = _products.FirstOrDefault(p => p.Name == name);
        if (product != null)
        {
            product.Quantity -= quantity;
            if (product.Quantity <= 0)
                _products.Remove(product);
        }
    }

    public void RemoveExpiredProducts()
    {
        _products.RemoveAll(p => p.IsExpired());
    }

    public void AdjustQuantity(string name, int newQuantity)
    {
        var product = _products.FirstOrDefault(p => p.Name == name);
        if (product != null)
            product.Quantity = newQuantity;
    }

    public List<Product> GetAllProducts() => _products;

    public List<Product> GetCriticalProducts(int threshold) =>
        _products.Where(p => p.Quantity <= threshold).ToList();
}
