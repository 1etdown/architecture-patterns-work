namespace Curseddd.Domain.Models;

public class Product
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }

    public bool IsExpired() => ExpirationDate < DateTime.Today;
}
