namespace Curseddd2.domain.model;

public class ProductRequest
{
    public string Name { get; }
    public int Quantity { get; }

    public ProductRequest(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}
