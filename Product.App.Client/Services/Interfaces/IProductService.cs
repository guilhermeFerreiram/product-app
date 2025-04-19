using Product.App.Client.Models;

namespace Product.App.Client.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductDto>> GetAllProductsAsync();
    Task<ProductDto> GetProductByIdAsync(int productId);
}
