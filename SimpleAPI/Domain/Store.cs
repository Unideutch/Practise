using Microsoft.Extensions.Hosting;

namespace SimpleAPI.Domain;

public class Store
{
    public int Id { get; init; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}