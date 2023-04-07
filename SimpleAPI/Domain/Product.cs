namespace SimpleAPI.Domain;

public class Product
{
    public int Id { get; init; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public Supplier Supplier { get; set; }
}
