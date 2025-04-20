namespace Curseddd.Domain.Interfaces;

using Domain.Models;

public interface IInventoryRepository
{
    void AddProduct(Product product);
    void RemoveProduct(string name, int quantity);
    void RemoveExpiredProducts();
    void AdjustQuantity(string name, int newQuantity);
    List<Product> GetAllProducts();
    List<Product> GetCriticalProducts(int threshold);
}
