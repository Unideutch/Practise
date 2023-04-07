using SimpleAPI.Domain;

namespace SimpleAPI.Dto.Stores;

public class ChangeStoreDto
{
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}
