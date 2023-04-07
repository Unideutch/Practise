using SimpleAPI.Domain;

namespace SimpleAPI.Dto.Stores;

public class CreateStoreDto
{
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}
