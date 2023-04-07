using SimpleAPI.Domain;

namespace SimpleAPI.Dto.Products;

public class CreateProductDto
{
    public string Name { get; set; }
    public int Cost { get; set; }
    public Supplier Supplier { get; set; }
}
